using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using MyConsoleApp.Entities;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyConsoleApp.DB
{
    public class DatabaseContext : DbContext    
    {
        readonly IConfiguration _configuration = new ConfigurationBuilder().AddJsonFile("appsettings.json", false, true).Build();

        public DatabaseContext()
        {
        }

        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            optionsBuilder.UseNpgsql(_configuration.GetConnectionString("DefaultConnectionString"));
        }

        public DbSet<Course> Courses { get; set; }
        public DbSet<Topic> Topics { get; set; }
        public DbSet<Learner> Learners { get; set; }
        public DbSet<LearnerCourse> LearnersCourses { get; set; }
        public DbSet<LearnerCourseTopic> LearnersCoursesTopics { get; set; }

        protected override void OnModelCreating(ModelBuilder mb)
        {
            base.OnModelCreating(mb);

            mb.Entity<Course>(course =>
            {
                course.ToTable("courses");
                course.HasKey(c => c.Id);

                course.HasMany(c => c.Topics).WithOne(t => t.Course);
                course.HasMany(c => c.LearnersCourses).WithOne(lc => lc.Course);

                course.HasIndex(c => c.Name).IsUnique();

                course.Property(c => c.Id).HasColumnName("id");
                course.Property(c => c.Name).HasColumnName("name").IsRequired();
                course.Property(c => c.Price).HasColumnName("price");
            });

            mb.Entity<Topic>(topic =>
            {
                topic.ToTable("topics");
                topic.HasKey(t => t.Id);

                topic.Property(t => t.Id).HasColumnName("id");
                topic.Property(t => t.Name).HasColumnName("name").IsRequired();
                topic.Property(t => t.CourseId).HasColumnName("course_id").IsRequired();
            });

            mb.Entity<Learner>(learner =>
            {
                learner.ToTable("learners");
                learner.HasKey(l => l.Id);

                learner.HasMany(l => l.Courses).WithOne(sc => sc.Learner);

                learner.Property(l => l.Id).HasColumnName("id");
                learner.Property(l => l.Name).HasColumnName("name").IsRequired();
            });

            mb.Entity<LearnerCourse>(learnercourse =>
            {
                learnercourse.ToTable("learners_courses");
                learnercourse.HasKey(lc => lc.Id);

                learnercourse.HasMany(lc => lc.LearnersCoursesTopics).WithOne(lct => lct.LearnerCourse);

                learnercourse.Property(lc => lc.Id).HasColumnName("id");
                learnercourse.Property(lc => lc.CourseId).HasColumnName("course_id").IsRequired();
                learnercourse.Property(lc => lc.LearnerId).HasColumnName("learner_id").IsRequired();
            });

            mb.Entity<LearnerCourseTopic>(learnercoursetopic =>
            {
                learnercoursetopic.ToTable("learnerscourses_topics");
                learnercoursetopic.HasKey(lct => lct.Id);

                learnercoursetopic.HasOne(lct => lct.Topic).WithMany(t => t.LearnersTopics);

                learnercoursetopic.Property(lct => lct.Id).HasColumnName("id");
                learnercoursetopic.Property(lct => lct.LearnerCourseId).HasColumnName("learner_course_id").IsRequired();
                learnercoursetopic.Property(lct => lct.TopicId).HasColumnName("topic_id").IsRequired();
                learnercoursetopic.Property(lct => lct.Points).HasColumnName("points");
            });
        }
    }
}

using MyConsoleApp.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyConsoleApp.Entities
{
    public class LearnerCourse : IEntity<int>
    {
        public int Id { get; set; }
        public int LearnerId { get; set; }
        public int CourseId { get; set; }
        public virtual Learner Learner { get; set; }
        public virtual Course Course { get; set; }
        public virtual List<LearnerCourseTopic> LearnersCoursesTopics { get; set; }
    }
}

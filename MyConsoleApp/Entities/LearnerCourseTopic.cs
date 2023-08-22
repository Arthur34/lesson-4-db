using MyConsoleApp.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyConsoleApp.Entities
{
    public class LearnerCourseTopic : IEntity<int>
    {
        public int Id { get; set; }
        public int LearnerCourseId { get; set; }
        public int TopicId { get; set; }
        public int? Points { get; set; }
        public virtual Topic Topic { get; set; }
        public virtual LearnerCourse LearnerCourse { get; set; }
    }
}

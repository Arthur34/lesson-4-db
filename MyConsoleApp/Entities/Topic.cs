using MyConsoleApp.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyConsoleApp.Entities
{
    public class Topic : IEntity<int>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int CourseId { get; set; }
        public virtual Course Course { get; set; }
        public virtual List<LearnerCourseTopic> LearnersTopics { get; set; }
    }
}

using MyConsoleApp.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyConsoleApp.Entities
{
    public class Course : IEntity<int>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal? Price { get; set; }
        public virtual List<Topic> Topics { get; set; }
        public virtual List<LearnerCourse> LearnersCourses { get; set; }
    }
}

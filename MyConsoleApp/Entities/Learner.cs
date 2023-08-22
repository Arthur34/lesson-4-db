using MyConsoleApp.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyConsoleApp.Entities
{
    public class Learner : IEntity<int>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual List<LearnerCourse> Courses { get; set; }
    }
}

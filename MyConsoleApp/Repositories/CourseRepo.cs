using Microsoft.EntityFrameworkCore;
using MyConsoleApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyConsoleApp.Repositories
{
    public class CourseRepo : Repo<Course, int>
    {
        public CourseRepo(DbContext context) : base(context)
        {
        }
    }
}

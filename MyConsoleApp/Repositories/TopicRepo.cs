using Microsoft.EntityFrameworkCore;
using MyConsoleApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyConsoleApp.Repositories
{
    public class TopicRepo : Repo<Topic, int>
    {
        public TopicRepo(DbContext context) : base(context)
        {
        }
    }
}

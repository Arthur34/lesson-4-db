using Microsoft.EntityFrameworkCore;
using MyConsoleApp.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyConsoleApp.Repositories
{
    public class ReadRepo<T, TKey> : IReadRepo<T, TKey> where T : class, IEntity<TKey>
    {
        protected readonly DbContext _context;
        protected DbSet<T> _collection;

        protected ReadRepo(DbContext context)
        {
            _context = context;
            _collection = _context.Set<T>();
        }

        public IEnumerable<T> GetAll()
        {
            return _collection;
        }
    }
}

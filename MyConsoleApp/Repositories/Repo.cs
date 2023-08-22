using Microsoft.EntityFrameworkCore;
using MyConsoleApp.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyConsoleApp.Repositories
{
    public class Repo<T, Tkey> : ReadRepo<T, Tkey>, IRepo<T, Tkey> where T : class, IEntity<Tkey>
    {
        public Repo(DbContext context) : base(context)
        {
        }

        public void Add(T entity)
        {
            _collection.Add(entity);
        }

        public async Task AddAsync(T entity)
        {
            await _collection.AddAsync(entity);
        }

        public bool SaveChanges()
        {
            return _context.SaveChanges() > 0;
        }
    }
}

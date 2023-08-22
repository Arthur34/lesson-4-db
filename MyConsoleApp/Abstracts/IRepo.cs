using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyConsoleApp.Abstracts
{
    public interface IRepo<T, TKey> : IReadRepo<T, TKey> where T : IEntity<TKey>
    {
        void Add(T entity);
        Task AddAsync(T entity);
        bool SaveChanges();
    }
}

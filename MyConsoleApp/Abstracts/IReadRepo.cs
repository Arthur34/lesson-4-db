using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyConsoleApp.Abstracts
{
    public interface IReadRepo<T, TKey> : IBaseRepo where T : IEntity<TKey>
    {
        IEnumerable<T> GetAll();
    }
}

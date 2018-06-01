using System;
using System.Linq;
using System.Linq.Expressions;

namespace MySMA.Repositories
{
    public interface IRepository<T> : IDisposable where T : class
    {
        IQueryable<T> All { get; }
        IQueryable<T> AllIncluding(params Expression<Func<T, object>>[] includeProperties);
        T Find(Guid id, params Expression<Func<T, object>>[] includeProperties);
        void Insert(T T);
        void Update(T T);
        void Save();
        void Delete(Guid id);
        void Delete(T T);
    }
}
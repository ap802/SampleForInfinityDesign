using System;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using MySMA.Models;

namespace MySMA.Repositories
{
    public class Repository<T> : IRepository<T> where T : EntityBase 
    {
        protected readonly IDbContext _context;
        private readonly IDbSet<T> _dbSet;

        // If you are using Dependency Injection, you can delete the following constructor
        public Repository()
            : this(new AppContext())
        {
        }

        public Repository(IDbContext context)
        {
            _context = context;

            // Retrieve the DbSet based on the type for which this repository is being used.
            _dbSet = _context.Set<T>();
        }

        public IQueryable<T> All
        {
            get { return _dbSet; }
        }

        public IQueryable<T> AllIncluding(params Expression<Func<T, object>>[] includeProperties)
        {
            IQueryable<T> query = All;

            foreach (var includeProperty in includeProperties)
            {
                query = query.Include(includeProperty);
            }

            return query;
        }

        public T Find(Guid id, params Expression<Func<T, object>>[] includeProperties)
        {
            if (includeProperties.Length == 0)
            {
                return All.FirstOrDefault(a => a.Id == id);
            }
            else
            {
                IQueryable<T> query = All;

                foreach (var includeProperty in includeProperties)
                {
                    query = query.Include(includeProperty);
                }

                return query.FirstOrDefault();
            }

        }

        public void Insert(T entity)
        {
            if (entity.Id != default(System.Guid))
            {
                throw new InvalidOperationException("Object has a non-default value for Id. Only new entities can be provided to this method.");
            }

            // Assign a new Guid to the Id
            entity.Id = Guid.NewGuid();

            _dbSet.Add(entity);
        }
        public void Update(T entity)
        {
            if (entity.Id == default(Guid))
            {
                throw new InvalidOperationException("Entity has a default value for Id. Only existing entities can be provided to this method.");
            }

            _context.SetModified(entity);
        }

        public void Delete(Guid id)
        {
            var entity = Find(id);
            if (entity != null)
            { 
                _context.Set<T>().Remove(entity);
            }
            
        }

        public void Delete(T T)
        {
            Delete(T.Id); 
        }


        public void Save()
        {
            _context.SaveChanges();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        
        protected virtual void Dispose(bool disposing)
        {
            _context.Dispose();
        }

    }
}
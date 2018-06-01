using MySMA.Models;
using MySMA.Repositories;
using System;
using System.Collections.Generic;
using System.Data.Entity;

namespace MySMA.Tests.Mocks
{
    public abstract class FakeDbContextBase : IDbContext
    {
        
        protected IDictionary<Type, object> _dbSets;

        protected FakeDbContextBase()
        {
            // Configure _dbSets
            AddFakeDbSetsToDictionary();
        }

        /// <summary>
        /// Note to inheritors: Implement code to populate _dbSets with instances of FakeDbSet required for
        /// your unit tests. Provide public properties accessors for any FakeDbSet objects you need to access
        /// in your tests, for example to set the ExceptionToThrow property.
        /// </summary>
        protected abstract void AddFakeDbSetsToDictionary();

        public IDbSet<T> Set<T>() where T : class
        {
            return (IDbSet<T>)_dbSets[typeof(T)];
        }

        public void SetModified<T>(T entity) where T : EntityBase
        {
            // To simulate an update, we'll just remove then re-add the entity to the collection
            var set = (FakeDbSet<T>)Set<T>();

            // Detach (remove) the entity from the in-memory collection
            set.Detach(entity);

            // Attach (add) the entity to the in-memory collection
            set.Attach(entity);
        }

        public void Remove<T>(T entity) where T : EntityBase
        {
            var set = (FakeDbSet<T>)Set<T>();

            // Detach (remove) the entity from the in-memory collection
            set.Detach(entity);
        }

        public int SaveChanges()
        {
            throw new NotImplementedException();
        }

        public bool AutoDetectChangesEnabled { get; set; }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}

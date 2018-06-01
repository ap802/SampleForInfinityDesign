using System;
using System.Data.Entity;
using MySMA.Models;

namespace MySMA.Repositories
{
    /// <summary>
    /// Allows us to utilize dependency injection and mocks for testing the repository. (EF doesn't support this out of the box.)
    /// </summary>
    public interface IDbContext : IDisposable
    {
        IDbSet<T> Set<T>() where T : class;
        void SetModified<T>(T entity) where T : EntityBase;
        void Remove<T>(T entity) where T : EntityBase;
        int SaveChanges();
        bool AutoDetectChangesEnabled { get; set; }
    }
}
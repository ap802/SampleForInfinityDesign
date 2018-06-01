using MySMA.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Linq;
using System.Reflection;

namespace MySMA.Tests.Mocks
{
    /// <summary>
    /// Provides an in-memory representation of a DbSet for unit testing repositories.
    /// </summary>
    /// <typeparam name="T">The type of elements in the DbSet</typeparam>
    public class FakeDbSet<T> : IDbSet<T>
        where T : EntityBase
    {
        readonly ObservableCollection<T> _data;
        readonly IQueryable _query;

        public FakeDbSet()
        {
            _data = new ObservableCollection<T>();
            _query = _data.AsQueryable();
        }

        /// <summary>
        /// Finds element with the provided key value. (Or key values, if there is a composite primary key.)
        /// </summary>
        /// <exception cref="InvalidOperationException">Thrown if there is more than one element found with the specified primary key</exception>
        /// <param name="keyValues">Primary key value(s) to find.</param>
        /// <returns>Element with the matching primary key.</returns>
        public virtual T Find(params object[] keyValues)
        {
            var entity = _data.SingleOrDefault(x => x.Id == (Guid)keyValues.Single());
            if (entity != null)
                return DeepClone(entity);
            else
                return null;
        }

        public T Add(T item)
        {
            if (ExceptionToThrow != null)
            {
                throw ExceptionToThrow;
            }

            _data.Add(DeepClone(item));
            return item;
        }

        public T Remove(T item)
        {
            if (ExceptionToThrow != null)
            {
                throw ExceptionToThrow;
            }

            _data.Remove(_data.FirstOrDefault(a => a.Id == item.Id));
            return item;
        }

        public T Attach(T item)
        {
            if (ExceptionToThrow != null)
            {
                throw ExceptionToThrow;
            }

            _data.Add(DeepClone(item));
            return item;
        }

        public T Detach(T item)
        {
            if (ExceptionToThrow != null)
            {
                throw ExceptionToThrow;
            }

            _data.Remove(_data.FirstOrDefault(a => a.Id == item.Id));
            return item;
        }

        public T Create()
        {
            if (ExceptionToThrow != null)
            {
                throw ExceptionToThrow;
            }

            return Activator.CreateInstance<T>();
        }

        public TDerivedEntity Create<TDerivedEntity>() where TDerivedEntity : class, T
        {
            if (ExceptionToThrow != null)
            {
                throw ExceptionToThrow;
            }

            return Activator.CreateInstance<TDerivedEntity>();
        }

        public ObservableCollection<T> Local
        {
            get { return _data; }
        }

        Type IQueryable.ElementType
        {
            get { return _query.ElementType; }
        }

        System.Linq.Expressions.Expression IQueryable.Expression
        {
            get { return _query.Expression; }
        }

        IQueryProvider IQueryable.Provider
        {
            get { return _query.Provider; }
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            if (ExceptionToThrow != null)
            {
                throw ExceptionToThrow;
            }

            return _data.GetEnumerator();
        }

        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            if (ExceptionToThrow != null)
            {
                throw ExceptionToThrow;
            }

            return _data.GetEnumerator();
        }

        /// <summary>
        /// If set, will throw this exception for any method that's called. (Not thrown for properties on this class.)
        /// </summary>
        public Exception ExceptionToThrow { get; set; }


        public T DeepClone(T obj)
        {
            Type t = obj.GetType();
            var fields = t.GetProperties(BindingFlags.FlattenHierarchy | BindingFlags.Public | BindingFlags.Instance);
            var copy = Activator.CreateInstance(t);

            for (int i = 0; i < fields.Length; i++)
                if (fields[i].CanWrite)
                    fields[i].SetValue(copy, fields[i].GetValue(obj));

            return (T)copy;
        }
    }
}

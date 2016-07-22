using System;
using System.Collections.Generic;

namespace ContactManager.Services
{
    public interface IRepository<T> where T : class
    {
        Guid Add(T entity);

        void Update(T entity);

        void DeleteByKey(Guid id);

        IEnumerable<T> FindAll();

        T FindByKey(Guid id);

        int Count { get; }
    }
}

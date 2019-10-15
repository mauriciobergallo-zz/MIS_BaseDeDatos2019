using System;
using System.Collections.Generic;

namespace SchoolApp.Repositories
{
    public interface IRepository<T> where T : Models.IEntity
    {
        IEnumerable<T> Get();
        T Get(Guid id);
        T Add(T entity);
        T Update(T entity);
        void Delete(Guid id);
    }
}
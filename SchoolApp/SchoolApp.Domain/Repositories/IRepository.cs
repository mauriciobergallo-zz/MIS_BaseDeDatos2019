using System;
using System.Collections.Generic;

namespace SchoolApp.Domain.Repositories
{
    public interface IRepository<T> where T : Entities.IEntity
    {
        IEnumerable<T> Get(string includeProperties = "");
        T Get(Guid id, string includeProperties = "");
        T Add(T entity);
        T Update(T entity);
        void Delete(Guid id);
    }
}
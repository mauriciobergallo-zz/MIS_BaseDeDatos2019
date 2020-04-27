using System;
using SchoolApp.Domain.Entities;
using SchoolApp.Domain.Repositories;

namespace SchoolApp.Repository.Models.Mappers.Helpers
{
    public class ObtainDependantEntity<T> where T : IEntity
    {
        private readonly IRepository<T> _repository;

        public ObtainDependantEntity(IRepository<T> repository)
        {
            _repository = repository;
        }
        
        public T ObtainEntityById(Guid id)
        {
            return _repository.Get(id);
        }
    }
}
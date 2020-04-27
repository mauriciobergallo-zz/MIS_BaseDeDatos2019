using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SchoolApp.Domain.Repositories;
using SchoolApp.Repository.Contexts;
using SchoolApp.Repository.Models;

namespace SchoolApp.Repository.Implementations
{
    public class EntityFrameworkRepository<T, TY> : IRepository<T>
        where T : Domain.Entities.IEntity 
        where TY : class, IEntityDto
    {
        private readonly IMapper _mapper;
        private readonly ISchoolAppDbContext _context;

        protected EntityFrameworkRepository(IMapper mapper, ISchoolAppDbContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        public IEnumerable<T> Get(string includeProperties = "")
        {
            IQueryable<TY> dtos = _context.Set<TY>();

            if (!string.IsNullOrEmpty(includeProperties))
            {
                foreach (string includeProperty in includeProperties.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    dtos = dtos.Include(includeProperty);
                }
            }

            return dtos.Select(dto => _mapper.Map<T>(dto)).ToList();
        }

        public T Get(Guid id, string includeProperties = "")
        {
            IQueryable<TY> dto = _context.Set<TY>();
            
            if (!string.IsNullOrEmpty(includeProperties))
            {
                foreach (string includeProperty in includeProperties.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    dto = dto.Include(includeProperty);
                }
            }

            var data = dto.FirstOrDefault(x => x.id == id);
            
            return _mapper.Map<T>(data);
        }

        public T Add(T entity)
        {
            var dto = _mapper.Map<TY>(entity);
            var createdEntity = _context.Set<TY>().Add(dto).Entity;
            _context.SaveChanges();

            return _mapper.Map<T>(createdEntity);
        }

        public T Update(T entity)
        {
            // var dto = _mapper.Map<TY>(entity);
            // var updatedEntity = _context.Set<TY>().Update(dto).Entity;
            // _context.SaveChanges();
            //
            // return _mapper.Map<T>(updatedEntity);
            var entityMapped = _mapper.Map<TY>(entity);

            var local = _context.Set<TY>().Local.FirstOrDefault(x => x.id == entity.Id);
            if (local != null)
            {
                _context.Entry(local).State = EntityState.Detached;
            }

            _context.Set<TY>().Attach(entityMapped);
            _context.Entry(entityMapped).State = EntityState.Modified;
            _context.SaveChanges();

            return _mapper.Map<T>(entityMapped);
        }

        public void Delete(Guid id)
        {
            try
            {
                _context.Set<TY>().Remove(_context.Set<TY>().First(x => x.id == id));
                _context.SaveChanges();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}
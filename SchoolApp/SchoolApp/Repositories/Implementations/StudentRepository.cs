using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using SchoolApp.Models;
using SchoolApp.Repositories.DTO;

namespace SchoolApp.Repositories.Implementations
{
    public class StudentRepository : IStudentRepository
    {
        private readonly IMapper _mapper;
        private readonly DataAccess.SchoolAppDbContext _context;
        
        public StudentRepository(DataAccess.SchoolAppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public IEnumerable<Student> Get()
        {
            var dtos = _context.Students.ToList();
            return dtos.Select(dto => _mapper.Map<Student>(dto)).ToList();
        }

        public Student Get(Guid id)
        {
            var dto = _context.Students.FirstOrDefault(x => x.id == id);
            return dto == null ? null : _mapper.Map<Student>(dto);
        }

        public Student Add(Student entity)
        {
            var dto = _mapper.Map<StudentDto>(entity);
            var createdEntity = _context.Students.Add(dto).Entity;
            _context.SaveChanges();

            return _mapper.Map<Student>(createdEntity);
        }

        public Student Update(Student entity)
        {
            var dto = _mapper.Map<StudentDto>(entity);
            var updatedEntity = _context.Students.Update(dto).Entity;
            _context.SaveChanges();

            return _mapper.Map<Student>(updatedEntity);
        }

        public void Delete(Guid id)
        {
            _context.Students.Remove(_context.Students.First(x => x.id == id));
            _context.SaveChanges();
        }
    }
}
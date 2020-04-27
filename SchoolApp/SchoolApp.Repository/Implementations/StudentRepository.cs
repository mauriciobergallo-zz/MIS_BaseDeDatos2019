using AutoMapper;
using SchoolApp.Domain.Entities;
using SchoolApp.Domain.Repositories;
using SchoolApp.Repository.Contexts;
using SchoolApp.Repository.Models;

namespace SchoolApp.Repository.Implementations
{
    public class StudentRepository : EntityFrameworkRepository<Student, StudentDto>, IStudentRepository
    {
        public StudentRepository(IMapper mapper, SchoolAppDbContext context)  : base(mapper, context)
        {
        }
    }
}
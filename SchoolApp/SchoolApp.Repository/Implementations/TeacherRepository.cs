using AutoMapper;
using SchoolApp.Domain.Entities;
using SchoolApp.Domain.Repositories;
using SchoolApp.Repository.Contexts;
using SchoolApp.Repository.Models;

namespace SchoolApp.Repository.Implementations
{
    public class TeacherRepository : EntityFrameworkRepository<Teacher, TeacherDto>, ITeacherRepository
    {
        public TeacherRepository(IMapper mapper, SchoolAppDbContext context) : base(mapper, context)
        {
        }
    }
}
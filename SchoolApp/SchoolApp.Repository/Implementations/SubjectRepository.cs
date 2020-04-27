using AutoMapper;
using SchoolApp.Domain.Entities;
using SchoolApp.Repositories;
using SchoolApp.Repository.Contexts;
using SchoolApp.Repository.Models;

namespace SchoolApp.Repository.Implementations
{
    public class SubjectRepository : EntityFrameworkRepository<Subject, SubjectDto>, ISubjectRepository
    {
        public SubjectRepository(IMapper mapper, SchoolAppDbContext context) : base(mapper, context)
        {
        }
    }
}
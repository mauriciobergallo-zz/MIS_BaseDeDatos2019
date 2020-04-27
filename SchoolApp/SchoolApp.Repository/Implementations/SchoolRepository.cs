using AutoMapper;
using SchoolApp.Domain.Entities;
using SchoolApp.Domain.Repositories;
using SchoolApp.Repository.Contexts;
using SchoolApp.Repository.Models;

namespace SchoolApp.Repository.Implementations
{
    public class SchoolRepository : EntityFrameworkRepository<School, SchoolDto>, ISchoolRepository
    {
        public SchoolRepository(IMapper mapper, ISchoolAppDbContext context) : base(mapper, context)
        {
        }
    }
}
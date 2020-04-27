using AutoMapper;
using SchoolApp.Domain.Entities;
using SchoolApp.Domain.Repositories;
using SchoolApp.Repository.Contexts;
using SchoolApp.Repository.Models;

namespace SchoolApp.Repository.Implementations
{
    public class EnrollmentRepository : EntityFrameworkRepository<Enrollment, EnrollmentDto>, IEnrollmentRepository
    {
        public EnrollmentRepository(IMapper mapper, ISchoolAppDbContext context) : base(mapper, context)
        {
        }
    }
}
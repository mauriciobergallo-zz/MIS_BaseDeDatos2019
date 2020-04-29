using AutoMapper;
using SchoolApp.Domain.Entities;
using SchoolApp.Domain.Repositories;
using SchoolApp.Repository.Contexts;
using SchoolApp.Repository.Models;

namespace SchoolApp.Repository.Implementations
{
    public class StudentEnrolledInCourseRepository : EntityFrameworkRepository<StudentEnrolledInCourse, StudentEnrolledInCourseDto>, IStudentEnrolledInCourseRepository
    {
        public StudentEnrolledInCourseRepository(IMapper mapper, ISchoolAppDbContext context) : base(mapper, context)
        {
            
        }
    }
}
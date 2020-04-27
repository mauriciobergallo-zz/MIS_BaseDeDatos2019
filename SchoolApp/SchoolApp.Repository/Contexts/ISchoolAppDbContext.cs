using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace SchoolApp.Repository.Contexts
{
    public interface ISchoolAppDbContext
    {
        DbSet<Models.StudentDto> Students { get; set; }
        DbSet<Models.TeacherDto> Teachers { get; set; }
        DbSet<Models.SubjectDto> Subjects { get; set; }
        DbSet<Models.StudyPlanDto> StudyPlans { get; set; }
        DbSet<Models.StudyPlanDetailDto> StudyPlanDetails { get; set; }
        DbSet<Models.EnrollmentDto> Enrollments { get; set; }
        DbSet<Models.CourseDto> Courses { get; set; }
        DbSet<Models.SchoolDto> Schools { get; set; }
        DbSet<Models.CourseSecondaryTeacherDto> CourseSecondaryTeachers { get; set; }
        DbSet<Models.StudentEnrolledInCourseDto> StudentEnrolledInCourseDto { get; set; }
        DbSet<TEntity> Set<TEntity>() where TEntity : class;
        int SaveChanges();
        Task<int> SaveChangesAsync();
        EntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class;
    }
}
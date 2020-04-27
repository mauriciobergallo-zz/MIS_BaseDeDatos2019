using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Design;
using SchoolApp.Repository.Models;

namespace SchoolApp.Repository.Contexts
{
    public class SchoolAppDbContext : DbContext, ISchoolAppDbContext
    {
        public DbSet<StudentDto> Students { get; set; }
        public DbSet<TeacherDto> Teachers { get; set; }
        public DbSet<SubjectDto> Subjects { get; set; }
        public DbSet<StudyPlanDto> StudyPlans { get; set; }
        public DbSet<StudyPlanDetailDto> StudyPlanDetails { get; set; }
        public DbSet<EnrollmentDto> Enrollments { get; set; }
        public DbSet<CourseDto> Courses { get; set; }
        public DbSet<SchoolDto> Schools { get; set; }
        public DbSet<CourseSecondaryTeacherDto> CourseSecondaryTeachers { get; set; }
        public DbSet<StudentEnrolledInCourseDto> StudentEnrolledInCourseDto { get; set; }

        public async Task<int> SaveChangesAsync()
        {
            return await base.SaveChangesAsync();
        }

        public EntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class
        {
            return base.Entry<TEntity>(entity);
        }

        public SchoolAppDbContext()
        {
        }

        public SchoolAppDbContext(DbContextOptions<SchoolAppDbContext> options)
            : base(options)
        {
            
        }
        
        public class ContextFactory : IDesignTimeDbContextFactory<SchoolAppDbContext>
        {
            public SchoolAppDbContext CreateDbContext(string[] args)
            {
                var optionsBuilder = new DbContextOptionsBuilder<SchoolAppDbContext>();
                //This is needed to create Migrations. This connection string is used only for Devs to add migrations.
                optionsBuilder.UseNpgsql("User ID=postgres;Password=postgres;Server=192.168.99.101;Port=5432;Database=school_app;");
                return new SchoolAppDbContext(optionsBuilder.Options);
            }
        }
    }
}
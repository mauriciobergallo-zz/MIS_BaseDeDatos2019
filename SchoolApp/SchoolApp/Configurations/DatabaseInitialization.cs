using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SchoolApp.Repository.Contexts;

namespace SchoolApp.Configurations
{
    /// <summary>
    /// Helper class to initialize the DataBase and ensure the migrations.
    /// </summary>
    public static class DatabaseInitialization
    {
        /// <summary>
        /// Helper method used to Initialize the DataBase
        /// </summary>
        /// <param name="app"></param>
        /// <param name="configuration"></param>
        public static async void InitializeDatabase(this IApplicationBuilder app, IConfiguration configuration)
        {
            if (configuration["RunMigrations"] == "False") return;
            
            using var serviceScope = app.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope();
            var dbDataContext = serviceScope.ServiceProvider.GetRequiredService<SchoolAppDbContext>();

            // Ensure that the database exists and all pending migrations are applied.
            dbDataContext.Database.Migrate();
            await Repository.Seeds.SeedSchool.Seed(dbDataContext);
            await Repository.Seeds.SeedTeachers.Seed(dbDataContext);
            await Repository.Seeds.SeedStudents.Seed(dbDataContext);
            await Repository.Seeds.SeedSubjects.Seed(dbDataContext);
            await Repository.Seeds.SeedStudyPlans.Seed(dbDataContext);
            await Repository.Seeds.SeedStudyPlanDetails.Seed(dbDataContext);
            await Repository.Seeds.SeedEnrollments.Seed(dbDataContext);
            await Repository.Seeds.SeedCourses.Seed(dbDataContext);
            await Repository.Seeds.SeedCourseSecondaryTeachers.Seed(dbDataContext);
            await Repository.Seeds.SeedCourseStudentsEnrolled.Seed(dbDataContext);
        }
    }
}
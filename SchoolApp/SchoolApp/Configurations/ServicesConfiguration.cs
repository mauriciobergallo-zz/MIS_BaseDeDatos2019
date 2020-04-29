using Microsoft.Extensions.DependencyInjection;
using SchoolApp.Domain.Repositories;
using SchoolApp.Domain.Services;
using SchoolApp.Repositories;
using SchoolApp.Repository.Implementations;
using SchoolApp.Services.Implementations;

namespace SchoolApp.Configurations
{
    /// <summary>
    /// Helper class to configure the DI
    /// </summary>
    public static class ServicesConfiguration
    {
        /// <summary>
        /// Helper method to add all the Dependency Injection of the project
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            // DI of repositories
            services.AddScoped<ICourseRepository, CourseRepository>();
            services.AddScoped<IEnrollmentRepository, EnrollmentRepository>();
            services.AddScoped<ISchoolRepository, SchoolRepository>();
            // services.AddScoped<IStudentEnrolledInCourseRepository, StudentEnrolledInCourseRepository>();
            services.AddScoped<IStudentRepository, StudentRepository>();
            services.AddScoped<IStudyPlanDetailRepository, StudyPlanDetailRepository>();
            services.AddScoped<IStudyPlanRepository, StudyPlanRepository>();
            services.AddScoped<ISubjectRepository, SubjectRepository>();
            services.AddScoped<ITeacherRepository, TeacherRepository>();
            services.AddScoped<IStudentEnrolledInCourseRepository, StudentEnrolledInCourseRepository>();

            // DI of Services
            services.AddScoped<IStudyPlanService, StudyPlanService>();
            services.AddScoped<ICourseService, CourseService>();
            services.AddScoped<ICourseGenerationService, CourseGenerationService>();
            services.AddScoped<IEnrollmentService, EnrollmentService>();
            services
                .AddScoped<IRegistrationAndEnrollmentInStudyPlanOfStudentService,
                    RegistrationAndEnrollmentInStudyPlanOfStudentService>();
            services.AddScoped<IStudentEnrollmentInCourseService, StudentEnrollmentInCourseService>();
            
            return services;
        }
    }
}
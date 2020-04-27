using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SchoolApp.Repository.Contexts;

namespace SchoolApp.Configurations
{
    /// <summary>
    /// Helper class to configure the Repository / DataAccess 
    /// </summary>
    public static class RepositoriesConfiguration
    {
        /// <summary>
        /// Helper method to add the current DbContext for the project
        /// </summary>
        /// <param name="services"></param>
        /// <param name="configuration"></param>
        /// <returns></returns>
        public static IServiceCollection AddDbContext(this IServiceCollection services, IConfiguration configuration)
        {
            // var engine = RepositoryEngineFactory.CreateEngineFromConnectionName(configuration.GetValue<string>("SelectedConnection"));
            // engine.AddDbContext(configuration.GetConnectionString(configuration.GetValue<string>("SelectedConnection")), services);
            //
            // services.AddTransient<DbContext, MachineBridgeContext>();
            services.AddDbContext<SchoolAppDbContext>(opts =>
                opts.UseNpgsql(configuration.GetValue<string>("DataBase:ConnectionString")));
            
            services.AddScoped<ISchoolAppDbContext, SchoolAppDbContext>();
            
            return services;
        }
    }
}
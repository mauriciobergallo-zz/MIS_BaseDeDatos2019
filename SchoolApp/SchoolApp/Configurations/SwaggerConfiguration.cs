using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace SchoolApp.Configurations
{
    /// <summary>
    /// Helper for setting up the configuration for Swagger Library
    /// </summary>
    public static class SwaggerConfiguration
    {
        /// <summary>
        /// SetUp Method for Swagger used in Startup.ConfigureServices()
        /// </summary>
        /// <param name="services"></param>
        public static void SetupSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "School API", Version = "v1" });
            });
        }
        
        /// <summary>
        /// Method used in Startup.Configure() in order to start the using of Swagger
        /// </summary>
        /// <param name="app"></param>
        /// <param name="configuration"></param>
        /// <param name="env"></param>
        public static void UseSwaggerConfig(this IApplicationBuilder app, IConfiguration configuration, IWebHostEnvironment env)
        {
            app.UseSwagger();
            app.UseSwaggerUI(c => { c.SwaggerEndpoint("/swagger/v1/swagger.json", "School API v1"); });
        }
    }
}
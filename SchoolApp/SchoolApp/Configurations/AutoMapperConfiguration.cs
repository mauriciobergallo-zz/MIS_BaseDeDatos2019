using AutoMapper;
using Microsoft.Extensions.DependencyInjection;

namespace SchoolApp.Configurations
{
    /// <summary>
    /// Helper class to add AutoMapper configuration.
    /// </summary>
    public static class AutoMapperConfiguration
    {
        /// <summary>
        /// Helper method called in Startup.ConfigureServices() class used to set the profiles of AutoMapper
        /// </summary>
        /// <param name="services"></param>
        public static void SetupAutoMapper(this IServiceCollection services)
        {
            // Infra Services
            var mappingConfig = new MapperConfiguration(x =>
            {
                x.AddProfile(new Repository.Models.Mappers.EntitiesToDto());
                x.AddProfile(new Controllers.DTO.Mappers.EntitiesToWebDtos());
            });
            services.AddSingleton(mappingConfig.CreateMapper());
        }
    }
}
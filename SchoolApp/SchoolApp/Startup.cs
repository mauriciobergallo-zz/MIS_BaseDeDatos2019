using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SchoolApp.Configurations;

namespace SchoolApp
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public virtual void ConfigureServices(IServiceCollection services)
        {
            AddDbContext(services);
            services.AddServices();
            
            services.AddControllers(options => options.EnableEndpointRouting = false);

            services.SetupAutoMapper();
            services.SetupSwagger();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.InitializeDatabase(Configuration);
            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseMvc();
            app.UseSwaggerConfig(Configuration, env);
        }
        
        protected virtual void AddDbContext(IServiceCollection services)
        {
            services.AddDbContext(Configuration);
        }
    }
}

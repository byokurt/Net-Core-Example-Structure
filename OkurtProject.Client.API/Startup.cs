using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using OkurtProject.Client.API.Bootstrapper;
using OkurtProject.Client.API.Middleware;
using OkurtProject.Utils;

namespace OkurtProject.Client.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            var connectionString = Configuration.GetConnectionString("PostgreSQLConnection");
            var appSettingsSection = Configuration.GetSection("AppSettings");


            services.RegisterSwager();
            services.AddControllers();
            services.RegisterDBContext(connectionString);
            services.RegisterRepositories();
            services.RegisterBusinessServices();
            services.RegisterBusinessOperator();
            services.RegisterCorsPolicy();
            services.Configure<Appsettings>(appSettingsSection);
            services.RegisterAuthentication(appSettingsSection);
            services.RegisterHttpHelpers();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors("DefaultPolicy");
            app.UseHttpsRedirection();
            app.UseSwaggerConfiguration();
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseMiddleware(typeof(ApiResponseMiddleware));

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}

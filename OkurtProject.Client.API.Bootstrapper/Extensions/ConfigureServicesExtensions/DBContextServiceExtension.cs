using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using OkurtProject.Data;
using OkurtProject.Data.Contracts;

namespace OkurtProject.Client.API.Bootstrapper
{
    public static class DBContextServiceExtension
    {
        public static IServiceCollection RegisterDBContext(this IServiceCollection services, string connectionString)
        {
            services.AddTransient<IPostgreSQLDbContext, PostgreSQLDbContext>();
            services.AddTransient<BaseDataContext, PostgreSQLDbContext>();
            services.AddDbContext<PostgreSQLDbContext>(item => item.UseNpgsql(connectionString));

            return services;
        }
    }
}

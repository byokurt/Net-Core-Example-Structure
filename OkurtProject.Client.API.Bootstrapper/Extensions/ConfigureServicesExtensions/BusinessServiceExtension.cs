using Microsoft.Extensions.DependencyInjection;
using OkurtProject.Business;
using OkurtProject.Business.Contracts;

namespace OkurtProject.Client.API.Bootstrapper
{
    public static class BusinessServiceExtension
    {
        public static IServiceCollection RegisterBusinessServices(this IServiceCollection services)
        {
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<IMaintenanceService, MaintenanceService>();
            return services;
        }
    }
}

using Microsoft.Extensions.DependencyInjection;
using OkurtProject.Data;
using OkurtProject.Data.Contracts;

namespace OkurtProject.Client.API.Bootstrapper
{
    public static class RepositoryServiceExtension
    {
        public static IServiceCollection RegisterRepositories(this IServiceCollection services)
        {
            services.AddTransient<BaseDataContext, PostgreSQLDbContext>();
            services.AddTransient<IMaintenanceRepository, MaintenanceRepository>();
            services.AddTransient<IActionTypeRepository, ActionTypeRepository>();
            services.AddTransient<IMaintenanceHistoryRepository, MaintenanceHistoryRepository>();
            services.AddTransient<IPictureGroupRepository, PictureGroupRepository>();
            services.AddTransient<IStatusRepository, StatusRepository>();
            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<IVehicleRepository, VehicleRepository>();
            services.AddTransient<IVehicleTypeRepository, VehicleTypeRepository>();

            return services;
        }
    }
}

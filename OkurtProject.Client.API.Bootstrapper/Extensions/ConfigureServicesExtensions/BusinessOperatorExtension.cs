using Microsoft.Extensions.DependencyInjection;

namespace OkurtProject.Client.API.Bootstrapper
{
    public static class BusinessOperatorExtension
    {
        public static IServiceCollection RegisterBusinessOperator(this IServiceCollection services)
        {
            //services.AddTransient<,>();
            return services;
        }
    }
}

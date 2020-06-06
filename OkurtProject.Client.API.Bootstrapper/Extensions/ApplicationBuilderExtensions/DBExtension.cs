using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using OkurtProject.Data;
using System;

namespace OkurtProject.Client.API.Bootstrapper
{
    public static class DBExtension
    {
        public static IApplicationBuilder EnsureDBCreated(this IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope())
            {
                try
                {
                    var context = serviceScope.ServiceProvider.GetRequiredService<BaseDataContext>();
                    context.Database.EnsureCreated();
                }
                catch (Exception ex)
                {
                    throw ex;
                }

            }

            return app;
        }
    }
}

using Microsoft.AspNetCore.Builder;

namespace OkurtProject.Client.API.Bootstrapper
{
    public static class SwaggerExtension
    {
        public static IApplicationBuilder UseSwaggerConfiguration(this IApplicationBuilder app)
        {
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "OkurtProject API V1");
            });
            return app;
        }
    }
}

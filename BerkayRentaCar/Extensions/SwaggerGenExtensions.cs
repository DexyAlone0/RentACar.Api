using Microsoft.AspNetCore.Builder;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace BerkayRentaCar.Extensions;

public static class SwaggerGenExtensions
{
    public static IServiceCollection AddSwagger(this IServiceCollection services, IWebHostEnvironment env)
    {
        services.AddSwaggerGen(c => c.SwaggerGenSetup(env.EnvironmentName, env.ApplicationName))
            .AddSwaggerGenNewtonsoftSupport();

        return services;
    }

    public static IApplicationBuilder UseSwaggerWithUi(this IApplicationBuilder app, IWebHostEnvironment env)
    {
        app.UseSwagger()
            .UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", $"{env.ApplicationName} V1");
                c.RoutePrefix = string.Empty;
                c.DocumentTitle = $"{env.ApplicationName} ({env.EnvironmentName})";
            });
        return app;
    }

    public static void SwaggerGenSetup(this SwaggerGenOptions c, string environmentName, string applicationName)
    {
        c.SwaggerDoc(
            "v1",
            new OpenApiInfo
            {
                Title = $"{applicationName} ({environmentName})",
                Version = "v1",
            });
        c.DescribeAllParametersInCamelCase();
    }

   
}
using eHospitalServer.Application;
using eHospitalServer.Infrastructure.Utilities;
using eHospitalServer.Persistance;
using eHospitalServer.Presentation.Middlewares;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace eHospitalServer.Presentation;
public static class DependencyInjection
{
    public static IServiceCollection AddPresentation(
        this IServiceCollection services,
        IConfiguration configuration,
        IWebHostEnvironment webHostEnvironment
        )
    {
        services.AddCors(cfr =>
        {
            cfr.AddDefaultPolicy(policy =>
            {
                policy.AllowAnyHeader();
                policy.AllowAnyMethod();
                policy.AllowAnyOrigin();
            });
        });

        services.AddExceptionHandler<ExceptionMiddleware>();
        services.AddProblemDetails();

        services.AddApplication(configuration);

        services.AddPersistance(configuration, webHostEnvironment);

        //ServiceTool
        services.CreateServiceTool();
        //ServiceTool

        services.AddTransient<ExceptionMiddleware>();

        return services;
    }
}

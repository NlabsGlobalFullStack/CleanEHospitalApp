using eHospitalServer.Application;
using eHospitalServer.Persistance;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace eHospitalServer.Presentation;
public static class DependencyInjection
{
    public static IServiceCollection AddPresentation(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddCors(cfr =>
        {
            cfr.AddDefaultPolicy(policy =>
            {
                policy.AllowAnyHeader();
                policy.AllowAnyMethod();
                policy.AllowCredentials();
                policy.SetIsOriginAllowed(policy => true);
            });
        });

        services.AddApplication();
        services.AddPersistance(configuration);

        return services;
    }
}

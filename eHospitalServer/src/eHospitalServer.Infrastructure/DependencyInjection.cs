using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace eHospitalServer.Infrastructure;
public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        //BackgroundServices
        //services.AddHostedService<AnnouncementBackgroundService>();
        //BackgroundServices

        return services;
    }
}

using eHospitalServer.Application.Behaviors;
using eHospitalServer.Infrastructure.Options;
using FluentValidation;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Nlabs.FileService;

namespace eHospitalServer.Application;
public static class DependencyInjection
{
    public static IServiceCollection AddApplication(
        this IServiceCollection services,
        IConfiguration configuration,
        string path)
    {
        services.AddValidatorsFromAssembly(typeof(DependencyInjection).Assembly);

        services.AddMediatR(configuration =>
        {
            configuration.RegisterServicesFromAssemblies(AppDomain.CurrentDomain.GetAssemblies());
            configuration.AddOpenBehavior(typeof(ValidationBehavior<,>));
        });

        services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

        var emailOptions = services.BuildServiceProvider().GetService<IOptions<EmailOptions>>()!.Value;

        var emailSection = configuration.GetSection("Email");

        services.Configure<EmailOptions>(options =>
        {
            options.Smtp = Convert.ToString(emailSection["Smtp"]!);
            options.Port = Convert.ToInt16(emailSection["Port"]!);
            options.Email = Convert.ToString(emailSection["Email"]!);
            options.Password = Convert.ToString(emailSection["Password"]!);
        });

        services.AddSingleton<EmailOptions>();

        services.AddFileService(path);

        return services;
    }
}

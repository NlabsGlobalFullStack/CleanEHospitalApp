using eHospitalServer.Domain.Entities;
using eHospitalServer.Domain.Repositories.CustomRepositories;
using eHospitalServer.Domain.Repositories.DefaultRepositories;
using eHospitalServer.Persistance.Authentication;
using eHospitalServer.Persistance.Context;
using eHospitalServer.Persistance.Repositories.CustomRepositories;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Scrutor;
using System.Text;

namespace eHospitalServer.Persistance;
public static class DependencyInjection
{
    public static IServiceCollection AddPersistance(
        this IServiceCollection services,
        IConfiguration configuration,
        IWebHostEnvironment webHostEnvironment)
    {
        var connectionString = configuration.GetConnectionString("SqlServer");
        services.AddDbContext<AppDbContext>(options =>
        {
            options.UseSqlServer(connectionString);
        });


        services.AddIdentity<AppUser, AppRole>(options =>
        {
            options.Password.RequireNonAlphanumeric = true;
            options.Password.RequireUppercase = true;
            options.Password.RequireLowercase = true;
            options.Password.RequireDigit = true;
            options.Password.RequiredLength = 6;
        }).AddEntityFrameworkStores<AppDbContext>()
        .AddDefaultTokenProviders();

        services.Configure<JwtOptions>(configuration.GetSection("Jwt"));

        services.AddScoped<IUnitOfWork>(srv => srv.GetRequiredService<AppDbContext>());

        services.Scan(action =>
        {
            action
            .FromAssemblies(typeof(DependencyInjection).Assembly)
            .AddClasses(publicOnly: false)
            .UsingRegistrationStrategy(registrationStrategy: RegistrationStrategy.Skip)
            .AsImplementedInterfaces()
            .WithScopedLifetime();
        });

        var jwtConfiguration = services.BuildServiceProvider().GetRequiredService<IOptions<JwtOptions>>().Value;

        var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtConfiguration.SecretKey ?? string.Empty));

        services.AddAuthentication().AddJwtBearer(options =>
        {
            options.TokenValidationParameters = new()
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateIssuerSigningKey = true,
                ValidateLifetime = true,
                ValidIssuer = jwtConfiguration.Issuer,
                ValidAudience = jwtConfiguration.Audience,
                IssuerSigningKey = securityKey
            };
        });

        var myHostEnvironment = new MyHostEnvironment
        {
            WebRootPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot"),
            WebRootFileProvider = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot")),
            EnvironmentName = webHostEnvironment.EnvironmentName,
            ApplicationName = webHostEnvironment.ApplicationName,
            ContentRootPath = webHostEnvironment.ContentRootPath,
            ContentRootFileProvider = webHostEnvironment.ContentRootFileProvider
        };

        services.AddSingleton<IMyHostEnvironment>(myHostEnvironment);


        return services;
    }
}

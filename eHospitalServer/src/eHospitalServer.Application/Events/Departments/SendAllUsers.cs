using eHospitalServer.Domain.Entities;
using eHospitalServer.Domain.Repositories;
using eHospitalServer.Infrastructure.Options;
using eHospitalServer.Infrastructure.Utilities;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System.Net;
using System.Net.Mail;

namespace eHospitalServer.Application.Events.Departments;
internal sealed class SendAllUsers : INotificationHandler<DepartmentDomain>
{
    private readonly EmailOptions _emailOptions;
    private readonly ILogger _logger;
    private readonly IServiceScopeFactory _serviceScopeFactory;

    public SendAllUsers(IOptions<EmailOptions> emailOptions, ILogger<DepartmentDomain> logger, IServiceScopeFactory serviceScopeFactory)
    {
        _emailOptions = emailOptions.Value;
        _logger = logger;
        _serviceScopeFactory = serviceScopeFactory;
    }
    public async Task Handle(DepartmentDomain notification, CancellationToken cancellationToken)
    {
        Console.WriteLine("Background service is working...");

        var userManager = ServiceTool.ServiceProvider!.GetRequiredService<UserManager<AppUser>>();
        var departmentRepository = ServiceTool.ServiceProvider!.GetRequiredService<IDepartmentRepository>();
        using (var scope = _serviceScopeFactory.CreateScope())
        {
            var users = await userManager.Users.Where(p => p.EmailConfirmed == true).ToListAsync(cancellationToken);

            foreach (var item in users)
            {
                var department = await departmentRepository.GetByExpressionAsync(p => p.Id == notification._department.Id, cancellationToken);
                if (department is null)
                {
                    _logger.LogError($"Department not found");
                    return;
                }
                try
                {
                    using (MailMessage mail = new MailMessage())
                    {
                        mail.From = new MailAddress(_emailOptions!.Email);
                        mail.To.Add(item.Email ?? "");
                        mail.Subject = notification._subject;
                        mail.Body = notification._body;
                        mail.IsBodyHtml = _emailOptions.HTML;

                        using (var smtp = new SmtpClient(_emailOptions.Smtp, _emailOptions.Port))
                        {
                            smtp.UseDefaultCredentials = false;
                            smtp.Credentials = new NetworkCredential(_emailOptions.Email, _emailOptions.Password);
                            smtp.EnableSsl = _emailOptions.SSL;
                            smtp.Port = _emailOptions.Port;
                            await smtp.SendMailAsync(mail);
                        }
                    }
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex.Message, $"Error sending email to {item.Email} for announcement ");
                }
            }
        }


        await Task.CompletedTask;
    }
}

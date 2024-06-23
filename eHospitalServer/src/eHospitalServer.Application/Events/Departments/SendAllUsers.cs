using eHospitalServer.Domain.Entities;
using eHospitalServer.Infrastructure.Options;
using eHospitalServer.Infrastructure.Utilities;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using System.Net;
using System.Net.Mail;

namespace eHospitalServer.Application.Events.Departments;
internal sealed class SendAllUsers : INotificationHandler<DepartmentDomain>
{
    private readonly EmailOptions _emailOptions;

    public SendAllUsers(IOptions<EmailOptions> emailOptions)
    {
        _emailOptions = emailOptions.Value;
    }
    public async Task Handle(DepartmentDomain notification, CancellationToken cancellationToken)
    {
        var userManager = ServiceTool.ServiceProvider!.GetRequiredService<UserManager<AppUser>>();
        var users = await userManager.Users.Where(p => p.EmailConfirmed == true).ToListAsync(cancellationToken);

        foreach (var item in users)
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

        await Task.CompletedTask;
    }
}

using eHospitalServer.Infrastructure.Options;
using MediatR;
using Microsoft.Extensions.Options;
using System.Net;
using System.Net.Mail;

namespace eHospitalServer.Application.Events.Users.ForgotPassword;

public sealed class SendForgotPasswordEmailDomainEvent : INotificationHandler<ForgotPasswordDomainEvent>
{
    private readonly EmailOptions _options;

    public SendForgotPasswordEmailDomainEvent(IOptions<EmailOptions> options)
    {
        _options = options.Value;
    }

    public async Task Handle(ForgotPasswordDomainEvent notification, CancellationToken cancellationToken)
    {
        using (MailMessage mail = new MailMessage())
        {
            mail.From = new MailAddress(_options!.Email);
            mail.To.Add(notification._user.Email ?? string.Empty);
            mail.Subject = notification._subject;
            mail.Body = notification._body;
            mail.IsBodyHtml = true;

            using (var smtp = new SmtpClient(_options.Smtp, _options.Port))
            {
                smtp.UseDefaultCredentials = false;
                smtp.Credentials = new NetworkCredential(_options.Email, _options.Password);
                smtp.EnableSsl = _options.SSL;
                smtp.Port = _options.Port;
                await smtp.SendMailAsync(mail);
            }
        }
    }
}

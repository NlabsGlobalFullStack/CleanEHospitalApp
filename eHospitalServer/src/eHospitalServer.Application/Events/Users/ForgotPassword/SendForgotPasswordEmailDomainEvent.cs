using eHospitalServer.Infrastructure.Options;
using MediatR;
using Microsoft.Extensions.Options;
using System.Net;
using System.Net.Mail;

namespace eHospitalServer.Application.Events.Users.ForgotPassword;

public sealed class SendForgotPasswordEmailDomainEvent : INotificationHandler<ForgotPasswordDomainEvent>
{
    private readonly IOptions<EmailOptions> _options;

    public SendForgotPasswordEmailDomainEvent(IOptions<EmailOptions> options)
    {
        _options = options;
    }

    public async Task Handle(ForgotPasswordDomainEvent notification, CancellationToken cancellationToken)
    {
        var emailOptions = _options.Value;

        using (MailMessage mail = new MailMessage())
        {
            mail.From = new MailAddress(emailOptions!.Email);
            mail.To.Add(notification._user.Email ?? string.Empty);
            mail.Subject = notification._subject;
            mail.Body = notification._body;
            mail.IsBodyHtml = true;

            using (var smtp = new SmtpClient(emailOptions.Smtp, emailOptions.Port))
            {
                smtp.UseDefaultCredentials = false;
                smtp.Credentials = new NetworkCredential(emailOptions.Email, emailOptions.Password);
                smtp.EnableSsl = emailOptions.SSL;
                smtp.Port = emailOptions.Port;
                await smtp.SendMailAsync(mail);
            }
        }
    }
}

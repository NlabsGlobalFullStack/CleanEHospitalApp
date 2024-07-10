using eHospitalServer.Domain.Entities;
using eHospitalServer.Domain.Repositories;
using eHospitalServer.Infrastructure.Options;
using eHospitalServer.Infrastructure.Utilities;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System.Net;
using System.Net.Mail;

namespace eHospitalServer.Application.Events.Announcements;

internal sealed class SendQuequePatients : INotificationHandler<AnnouncementDomain>
{
    private readonly ILogger<SendQuequePatients> _logger;
    private readonly IServiceScopeFactory _serviceScopeFactory;
    private readonly EmailOptions _options;

    public SendQuequePatients(ILogger<SendQuequePatients> logger, IServiceScopeFactory serviceScopeFactory, IOptions<EmailOptions> options)
    {
        _logger = logger;
        _serviceScopeFactory = serviceScopeFactory;
        _options = options.Value;
    }

    public async Task Handle(AnnouncementDomain notification, CancellationToken cancellationToken)
    {
        Console.WriteLine("Background service is working...");

        var userManager = ServiceTool.ServiceProvider!.GetRequiredService<UserManager<AppUser>>();
        var announcementRepository = ServiceTool.ServiceProvider!.GetRequiredService<IAnnouncementRepository>();

        using (var scope = _serviceScopeFactory.CreateScope())
        {
            var announcement = await announcementRepository.GetByExpressionAsync(p => p.Id == notification._announcement.Id, cancellationToken);
            if (announcement is null)
            {
                _logger.LogError($"Announcement not found");
                return;
            }

            var users = userManager.Users.ToList();

            foreach (var user in users)
            {
                try
                {
                    using (MailMessage mail = new MailMessage())
                    {
                        mail.From = new MailAddress(_options!.Email);
                        mail.To.Add(user.Email ?? "");
                        mail.Subject = notification._subject;
                        mail.Body = notification._body;
                        mail.IsBodyHtml = _options.HTML;

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
                catch (Exception ex)
                {
                    _logger.LogError(ex.Message, $"Error sending email to {user.Email} for announcement ");
                }
            }
        }



        #region Old Code
        //var userManager = ServiceTool.ServiceProvider!.GetRequiredService<UserManager<AppUser>>();

        //var factory = new ConnectionFactory { HostName = "localhost" };
        //using var connection = factory.CreateConnection();
        //using var channel = connection.CreateModel();

        //channel.QueueDeclare(
        //            queue: "announcements",
        //            exclusive: false,
        //            autoDelete: false,
        //            arguments: null
        //        );

        //var users = await userManager.Users.Where(p => p.EmailConfirmed == true).ToListAsync(cancellationToken);
        //foreach (var user in users)
        //{
        //    var data = new
        //    {
        //        Email = user.Email,
        //        AnnouncementId = notification.announcementId
        //    };

        //    var message = JsonSerializer.Serialize(data);
        //    var body = Encoding.UTF8.GetBytes(message);
        //    channel.BasicPublish(exchange: string.Empty, routingKey: "announcements", basicProperties: null, body: body);
        //    await Console.Out.WriteLineAsync($" [x] {user.Email} sended queue");
        //}
        #endregion

        await Task.CompletedTask;
    }
}

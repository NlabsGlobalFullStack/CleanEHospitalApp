using eHospitalServer.Domain.Repositories;
using eHospitalServer.Infrastructure.DTOs;
using eHospitalServer.Infrastructure.Options;
using eHospitalServer.Infrastructure.Utilities;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Text.Json;

namespace eHospitalServer.Infrastructure.BackgroundServices;
public sealed class AnnouncementBackgroundService : BackgroundService
{
    private readonly IOptions<EmailOptions> _options;

    public AnnouncementBackgroundService(IOptions<EmailOptions> options)
    {
        _options = options;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        Console.WriteLine("Background service is working...");

        var announcementRepository = ServiceTool.ServiceProvider?.GetRequiredService<IAnnouncementRepository>();

        var factory = new ConnectionFactory { HostName = "localhost" };
        using var connection = factory.CreateConnection();
        using var channel = connection.CreateModel();

        channel.QueueDeclare(
            queue: "announcements",
            exclusive: false,
            autoDelete: false,
            arguments: null
            );

        Console.WriteLine(" [*] Waiting for messages...");

        var consumer = new EventingBasicConsumer(channel);
        consumer.Received += async (model, ea) =>
        {
            var emailOptions = _options.Value;
            var body = ea.Body.ToArray();
            var message = Encoding.UTF8.GetString(body);
            var response = JsonSerializer.Deserialize<AnnouncementDto>(message);
            if (response is null)
            {
                await Console.Out.WriteLineAsync("Response is empty or null");
            }

            var announcement = announcementRepository!.GetByExpression(a => a.Id == response!.AnnouncementId);

            if (announcement is null)
            {
                await Console.Out.WriteLineAsync("Announcement not found");
            }

            try
            {
                using (MailMessage mail = new MailMessage())
                {
                    mail.From = new MailAddress(emailOptions!.Email);
                    mail.To.Add(response!.Email ?? string.Empty);
                    mail.Subject = announcement!.Title;
                    mail.Body = announcement!.Content;
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
                Console.WriteLine($" [*] {response.Email} announcements sended");

            }
            catch (Exception ex)
            {
                await Console.Out.WriteLineAsync($"Error Email could not be sent!  error: {ex.Message}");
            }

            channel.BasicConsume(queue: "announcements", autoAck: true, consumer: consumer);

            while (!stoppingToken.IsCancellationRequested)
            {
                await Task.Delay(1000, stoppingToken);
            }
        };

        await Task.CompletedTask;
    }
}

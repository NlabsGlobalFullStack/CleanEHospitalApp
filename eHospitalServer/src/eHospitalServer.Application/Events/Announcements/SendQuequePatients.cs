using eHospitalServer.Domain.Entities;
using eHospitalServer.Infrastructure.Utilities;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using RabbitMQ.Client;
using System.Text;
using System.Text.Json;

namespace eHospitalServer.Application.Events.Announcements;

internal sealed class SendQuequePatients() : INotificationHandler<AnnouncementDomain>
{
    public async Task Handle(AnnouncementDomain notification, CancellationToken cancellationToken)
    {

        Console.WriteLine("Background service is working...");

        var userManager = ServiceTool.ServiceProvider!.GetRequiredService<UserManager<AppUser>>();

        var factory = new ConnectionFactory { HostName = "localhost" };
        using var connection = factory.CreateConnection();
        using var channel = connection.CreateModel();

        channel.QueueDeclare(
                    queue: "announcements",
                    exclusive: false,
                    autoDelete: false,
                    arguments: null
                );

        var users = await userManager.Users.Where(p => p.EmailConfirmed == true).ToListAsync(cancellationToken);
        foreach (var user in users)
        {
            var data = new
            {
                Email = user.Email,
                AnnouncementId = notification.announcementId
            };

            var message = JsonSerializer.Serialize(data);
            var body = Encoding.UTF8.GetBytes(message);
            channel.BasicPublish(exchange: string.Empty, routingKey: "announcements", basicProperties: null, body: body);
            await Console.Out.WriteLineAsync($" [x] {user.Email} sended queue");
        }
        await Task.CompletedTask;
    }
}

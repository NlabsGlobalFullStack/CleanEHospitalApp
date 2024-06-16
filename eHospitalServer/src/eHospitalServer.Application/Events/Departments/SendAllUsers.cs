using eHospitalServer.Domain.Entities;
using eHospitalServer.Infrastructure.Utilities;
using MediatR;
using Microsoft.AspNetCore.Identity;
using RabbitMQ.Client;
using System.Text.Json;
using System.Text;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;

namespace eHospitalServer.Application.Events.Departments;
internal sealed class SendAllUsers() : INotificationHandler<DepartmentDomain>
{
    public async Task Handle(DepartmentDomain notification, CancellationToken cancellationToken)
    {
        Console.WriteLine("Background service is working...");

        var userManager = ServiceTool.ServiceProvider!.GetRequiredService<UserManager<AppUser>>();

        var factory = new ConnectionFactory { HostName = "localhost" };
        using var connection = factory.CreateConnection();
        using var channel = connection.CreateModel();

        channel.QueueDeclare(
                    queue: "users",
                    exclusive: false,
                    autoDelete: false,
                    arguments: null
                );

        var emails = await userManager.Users.Where(p => p.EmailConfirmed == true).ToListAsync(cancellationToken);
        foreach (var email in emails)
        {
            var data = new
            {
                Email = email,
                AnnouncementId = notification.departmentId
            };

            var message = JsonSerializer.Serialize(data);
            var body = Encoding.UTF8.GetBytes(message);
            channel.BasicPublish(exchange: string.Empty, routingKey: "users", basicProperties: null, body: body);
            await Console.Out.WriteLineAsync($" [x] {email} sended queue");
        }
        await Task.CompletedTask;
    }
}

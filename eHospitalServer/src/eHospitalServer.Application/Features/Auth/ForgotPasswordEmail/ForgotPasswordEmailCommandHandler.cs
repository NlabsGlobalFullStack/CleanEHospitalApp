using eHospitalServer.Application.Events.Users.ForgotPassword;
using eHospitalServer.Domain.Entities;
using eHospitalServer.Infrastructure.Extensions;
using eHospitalServer.Infrastructure.Results;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace eHospitalServer.Application.Features.Auth.ForgotPasswordEmail;

internal sealed class ForgotPasswordEmailCommandHandler(UserManager<AppUser> userManager, IMediator mediator) : IRequestHandler<ForgotPasswordEmailCommand, Result<string>>
{
    public async Task<Result<string>> Handle(ForgotPasswordEmailCommand request, CancellationToken cancellationToken)
    {
        var user = await userManager.Users.FirstOrDefaultAsync(p => p.Email == request.UserNameOrEmail || p.UserName == request.UserNameOrEmail, cancellationToken);
        if (user is null)
        {
            return Result<string>.Failure( "User not found!");
        }

        Random random = new();
        bool isForgotPasswordCodeExists = true;
        int forgotPasswordCode = 0;
        while (isForgotPasswordCodeExists)
        {
            forgotPasswordCode = random.Next(111111, 999999);
            isForgotPasswordCodeExists = await userManager.Users.AnyAsync(p => p.ForgotPasswordCode == forgotPasswordCode, cancellationToken);
        }

        user.ForgotPasswordCode = forgotPasswordCode;
        user.ForgotPasswordCodeSendDate = DateTime.UtcNow.AddMinutes(5);

        await userManager.UpdateAsync(user);

        var minute = 3;
        var subject = "Reset your password";
        var body = EmailBodies.CreateConfirmEmailBody(forgotPasswordCode.ToString(), minute);
        await mediator.Publish(new ForgotPasswordDomainEvent(user, subject, body));
        var email = EmailBodies.MaskEmail(user.Email ?? "");

        return Result<string>.Succeed($"Password recovery code is sent to your {email} email address");
    }
}

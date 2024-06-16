using eHospitalServer.Domain.Entities;
using eHospitalServer.Infrastructure.Results;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace eHospitalServer.Application.Features.Auth.ChangePasswordWithForgotPasswordCode;

internal sealed class ChangePasswordWithForgotPasswordCodeCommandHandler(UserManager<AppUser> userManager) : IRequestHandler<ChangePasswordWithForgotPasswordCodeCommand, Result<string>>
{
    public async Task<Result<string>> Handle(ChangePasswordWithForgotPasswordCodeCommand request, CancellationToken cancellationToken)
    {
        var user = await userManager.Users.FirstOrDefaultAsync(p => p.ForgotPasswordCode == request.ForgotPasswordCode, cancellationToken);

        if (user is null)
        {
            return Result<string>.Failure( "Your recovery password code is invalid");
        }

        if (user.ForgotPasswordCodeSendDate < DateTime.Now)
        {
            return Result<string>.Failure( "Your recovery password code is invalid");
        }
        var token = await userManager.GeneratePasswordResetTokenAsync(user);

        var result = await userManager.ResetPasswordAsync(user, token, request.NewPassword);

        if (request.ReNewPassword != request.NewPassword)
        {
            return Result<string>.Failure("Passwords do not match, please try again!");
        }

        if (!result.Succeeded)
        {
            return Result<string>.Failure(result.Errors.Select(s => s.Description).ToList());
        }

        user.ForgotPasswordCode = null;
        user.ForgotPasswordCodeSendDate = null;

        result = await userManager.UpdateAsync(user);

        if (!result.Succeeded)
        {
            return Result<string>.Failure(result.Errors.Select(s => s.Description).ToList());
        }

        return "Your password is changed. You can sign in using new password";
    }
}

using eHospitalServer.Domain.Entities;
using eHospitalServer.Infrastructure.Results;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace eHospitalServer.Application.Features.Auth.ConfirmEmail;

internal sealed class ConfirmEmailCommandHandler(UserManager<AppUser> userManager) : IRequestHandler<ConfirmEmailCommand, Result<string>>
{
    public async Task<Result<string>> Handle(ConfirmEmailCommand request, CancellationToken cancellationToken)
    {
        var user = await userManager.Users.FirstOrDefaultAsync(p => p.EmailConfirmCode == request.EmailConfirmCode, cancellationToken);
        if (user is null)
        {
            return Result<string>.Failure( "Email confirm code is not available");
        }

        if (user.EmailConfirmed)
        {
            return Result<string>.Failure( "User email already confirmed");
        }

        user.EmailConfirmed = true;
        await userManager.UpdateAsync(user);

        return Result<string>.Succeed("Email verification is succeed");
    }
}

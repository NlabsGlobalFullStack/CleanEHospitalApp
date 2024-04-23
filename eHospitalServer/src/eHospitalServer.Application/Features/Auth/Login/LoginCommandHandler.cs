using eHospitalServer.Domain.Entities;
using eHospitalServer.Domain.Repositories.Jwt;
using eHospitalServer.Infrastructure.Results;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace eHospitalServer.Application.Features.Auth.Login;

internal sealed class LoginCommandHandler(
    UserManager<AppUser> userManager,
    SignInManager<AppUser> signInManager,
    IJwtProvider jwtProvider
) : IRequestHandler<LoginCommand, Result<LoginCommandResponse>>
{
    public async Task<Result<LoginCommandResponse>> Handle(LoginCommand request, CancellationToken cancellationToken)
    {
        var UserNameOrEmail = request.IdentityNumberOrUserNameOrEmail.ToUpper();
        var user = await userManager.Users.
            FirstOrDefaultAsync(p => p.UserName == UserNameOrEmail || p.Email == UserNameOrEmail, cancellationToken);
        var message = "";
        if (user is null)
        {
            message = "User not found!";
            return Result<LoginCommandResponse>.Failure(message);
        }

        var signinResult = await signInManager.CheckPasswordSignInAsync(user, request.Password, true);
        if (signinResult.IsLockedOut)
        {
            var timeSpan = user.LockoutEnd - DateTime.Now;
            if (timeSpan is not null)
            {
                message = $"Your user has been locked for {Math.Ceiling(timeSpan.Value.TotalMinutes)} minutes due to entering the wrong password 3 times.";
                return Result<LoginCommandResponse>.Failure(message);
            }
            else
            {
                message = "Your user has been locked out for 5 minutes due to entering the wrong password 3 times.";
                return Result<LoginCommandResponse>.Failure(message);
            }
        }

        if (signinResult.IsNotAllowed)
        {
            message = "Your e-mail address is not confirmed";
            return Result<LoginCommandResponse>.Failure(message);
        }

        if (!signinResult.Succeeded)
        {
            message = "Password is wrong";
            return Result<LoginCommandResponse>.Failure(message);
        }

        //var isPasswordCorrect = await userManager.CheckPasswordAsync(user, request.Password);
        //if (!isPasswordCorrect)
        //{
        //    return Result<LoginCommandResponse>.Failure("Password is wrong");
        //}

        var token = await jwtProvider.CreateTokenAsync(user, request.RememberMe);

        return Result<LoginCommandResponse>.Succeed(token);
    }
}

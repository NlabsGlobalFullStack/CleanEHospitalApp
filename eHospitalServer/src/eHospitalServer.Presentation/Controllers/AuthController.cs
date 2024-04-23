using eHospitalServer.Application.Features.Auth.ChangePasswordWithForgotPasswordCode;
using eHospitalServer.Application.Features.Auth.ConfirmEmail;
using eHospitalServer.Application.Features.Auth.ForgotPasswordEmail;
using eHospitalServer.Application.Features.Auth.Login;
using eHospitalServer.Presentation.Abstraction;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace eHospitalServer.Presentation.Controllers;

[AllowAnonymous]
public sealed class AuthController : ApiController
{
    public AuthController(IMediator mediator) : base(mediator) {}

    //Login işlemi
    [HttpPost]
    public async Task<IActionResult> Login(LoginCommand request, CancellationToken cancellationToken = default)
    {
        var response = await _mediator.Send(request, cancellationToken);
        return StatusCode(response.StatusCode, response);
    }

    //kayıt yapılan kullanıcı bilgilerini dogrulamak için bu kısımda email adresine gelen kodu girer ve dogrulama işlemi gerçekleşir login olabilir
    [HttpPost]
    public async Task<IActionResult> SendConfirmEmail(ConfirmEmailCommand request, CancellationToken cancellationToken)
    {
        var response = await _mediator.Send(request, cancellationToken);
        return StatusCode(response.StatusCode, response);
    }

    //Parola sıfırlama istegi işlemi bu kısımda istekte bulunulur ve email adresine bir kod gider
    [HttpPost]
    public async Task<IActionResult> SendForgotPasswordEmail(ForgotPasswordEmailCommand request, CancellationToken cancellationToken)
    {
        var response = await _mediator.Send(request, cancellationToken);
        return StatusCode(response.StatusCode, response);
    }
    
    //Parola sıfırlamak için bilgiler ve sıfırlama komutu gelen emailkodu ve yeni şifre ve tekrarı girilir
    [HttpPost]
    public async Task<IActionResult> ChangePasswordWithForgotPasswordCode(ChangePasswordWithForgotPasswordCodeCommand request, CancellationToken cancellationToken)
    {
        var response = await _mediator.Send(request, cancellationToken);
        return StatusCode(response.StatusCode, response);
    }
}

using eHospitalServer.Application.Features.Users.Queries.Users.GetAllUsers;
using eHospitalServer.Presentation.Abstraction;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace eHospitalServer.Presentation.Controllers;
public sealed class UsersController : ApiController
{
    public UsersController(IMediator mediator) : base(mediator) {}

    [AllowAnonymous]
    [HttpPost]
    public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
    {
        var response = await _mediator.Send(new GetAllUsersQuery(), cancellationToken);
        return StatusCode(response.StatusCode, response);
    }
}

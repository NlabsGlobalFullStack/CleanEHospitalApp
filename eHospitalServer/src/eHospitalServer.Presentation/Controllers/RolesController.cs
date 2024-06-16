using eHospitalServer.Application.Features.Roles.RoleSync;
using eHospitalServer.Presentation.Abstraction;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace eHospitalServer.Presentation.Controllers;
public sealed class RolesController : ApiController
{
    public RolesController(IMediator mediator) : base(mediator) {}

    [HttpPost]
    public async Task<IActionResult> Sync(CancellationToken cancellationToken)
    {
        var response = await _mediator.Send(new RoleSyncCommand(), cancellationToken);
        return StatusCode(response.StatusCode, response);
    }
}

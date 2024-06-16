using eHospitalServer.Application.Features.Users.Queries.GetByUserId;
using eHospitalServer.Presentation.Abstraction;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace eHospitalServer.Presentation.Controllers;
public sealed class DashboardController : ApiController
{
    public DashboardController(IMediator mediator) : base(mediator)
    {
    }

    [HttpPost]
    public async Task<IActionResult> GetByUser(string Id, CancellationToken cancellationToken)
    {
        var response = await _mediator.Send(new GetByUserIdQuery(Id), cancellationToken);
        return StatusCode(response.StatusCode, response);
    }
}

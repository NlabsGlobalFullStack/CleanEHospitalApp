using eHospitalServer.Application.Features.Users.Queries.Nurses.GetAllNurses;
using eHospitalServer.Presentation.Abstraction;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace eHospitalServer.Presentation.Controllers;
internal class NursesController : ApiController
{
    public NursesController(IMediator mediator) : base(mediator) {}

    [HttpPost]
    public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
    {
        var response = await _mediator.Send(new GetAllNursesQuery(), cancellationToken);
        return StatusCode(response.StatusCode, response);
    }
}

using eHospitalServer.Application.Features.Vehicles.GetAllVehicles;
using eHospitalServer.Presentation.Abstraction;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace eHospitalServer.Presentation.Controllers;
public sealed class VehiclesController : ApiController
{
    public VehiclesController(IMediator mediator) : base(mediator) { }

    [AllowAnonymous]
    [HttpPost]
    public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
    {
        var response = await _mediator.Send(new GetAllVehiclesQuery(), cancellationToken);
        return StatusCode(response.StatusCode, response);
    }
}

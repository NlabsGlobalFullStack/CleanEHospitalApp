using eHospitalServer.Application.Features.Vehicles.CreateVehicle;
using eHospitalServer.Application.Features.Vehicles.DeleteByIdVehicle;
using eHospitalServer.Application.Features.Vehicles.GetAllVehicles;
using eHospitalServer.Application.Features.Vehicles.GetByIdVehicle;
using eHospitalServer.Application.Features.Vehicles.UpdateVehicle;
using eHospitalServer.Presentation.Abstraction;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace eHospitalServer.Presentation.Controllers;
public sealed class VehiclesController : ApiController
{
    public VehiclesController(IMediator mediator) : base(mediator) { }

    [HttpPost]
    public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
    {
        var response = await _mediator.Send(new GetAllVehiclesQuery(), cancellationToken);
        return StatusCode(response.StatusCode, response);
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateVehicleCommand request, CancellationToken cancellationToken)
    {
        var response = await _mediator.Send(request, cancellationToken);
        return StatusCode(response.StatusCode, response);
    }

    [HttpPost]
    public async Task<IActionResult> Update(UpdateVehicleCommand request, CancellationToken cancellationToken)
    {
        var response = await _mediator.Send(request, cancellationToken);
        return StatusCode(response.StatusCode, response);
    }

    [HttpPost]
    public async Task<IActionResult> GetById(string id, CancellationToken cancellationToken)
    {
        var response = await _mediator.Send(new GetByIdVehicleQuery(id), cancellationToken);
        return StatusCode(response.StatusCode, response);
    }

    [HttpPost]
    public async Task<IActionResult> DeleteBy(string id, CancellationToken cancellationToken)
    {
        var response = await _mediator.Send(new DeleteByIdVehicleCommand(id), cancellationToken);
        return StatusCode(response.StatusCode, response);
    }
}

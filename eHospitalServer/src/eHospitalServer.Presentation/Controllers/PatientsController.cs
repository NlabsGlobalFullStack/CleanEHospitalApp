using eHospitalServer.Application.Features.Users.Queries.Patients.GetAllPatients;
using eHospitalServer.Presentation.Abstraction;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace eHospitalServer.Presentation.Controllers;
public sealed class PatientsController : ApiController
{
    public PatientsController(IMediator mediator) : base(mediator) { }

    [AllowAnonymous]
    [HttpPost]
    public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
    {
        var response = await _mediator.Send(new GetAllPatientsQuery(), cancellationToken);
        return StatusCode(response.StatusCode, response);
    }
}

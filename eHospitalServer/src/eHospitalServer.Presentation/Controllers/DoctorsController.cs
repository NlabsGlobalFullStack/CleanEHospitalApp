using eHospitalServer.Application.Features.Users.Queries.Doctors.GetAllDoctors;
using eHospitalServer.Presentation.Abstraction;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace eHospitalServer.Presentation.Controllers;
public sealed class DoctorsController : ApiController
{
    public DoctorsController(IMediator mediator) : base(mediator) {}

    [AllowAnonymous]
    [HttpPost]
    public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
    {
        var response = await _mediator.Send(new GetAllDoctorsQuery(), cancellationToken);
        return StatusCode(response.StatusCode, response);
    }
}

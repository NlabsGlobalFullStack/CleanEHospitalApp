using eHospitalServer.Application.Features.Users.Queries.Employees.GetAllEmployees;
using eHospitalServer.Presentation.Abstraction;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace eHospitalServer.Presentation.Controllers;
public sealed class EmployeesController : ApiController
{
    public EmployeesController(IMediator mediator) : base(mediator) { }

    [AllowAnonymous]
    [HttpPost]
    public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
    {
        var response = await _mediator.Send(new GetAllEmployeesQuery(), cancellationToken);
        return StatusCode(response.StatusCode, response);
    }
}

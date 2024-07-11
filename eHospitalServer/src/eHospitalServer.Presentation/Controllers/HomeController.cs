using eHospitalServer.Application.Features.Home.GetAllAnnouncements;
using eHospitalServer.Application.Features.Home.GetAllDepartments;
using eHospitalServer.Application.Features.Home.GetAllDoctors;
using eHospitalServer.Application.Features.Home.GetAllFaqs;
using eHospitalServer.Application.Features.Home.GetAllServices;
using eHospitalServer.Application.Features.Home.GetAllSliders;
using eHospitalServer.Application.Features.Home.GetByIdAnnouncement;
using eHospitalServer.Application.Features.Home.GetSettings;
using eHospitalServer.Presentation.Abstraction;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace eHospitalServer.Presentation.Controllers;

[AllowAnonymous]
public sealed class HomeController : ApiController
{
    public HomeController(IMediator mediator) : base(mediator) { }


    [HttpPost]
    public async Task<IActionResult> GetSettings(GetSettingsQuery request, CancellationToken cancellationToken)
    {
        var response = await _mediator.Send(request, cancellationToken);
        return StatusCode(response.StatusCode, response);
    }

    [HttpPost]
    public async Task<IActionResult> GetSliders(GetAllSlidersQuery request, CancellationToken cancellationToken)
    {
        var response = await _mediator.Send(request, cancellationToken);
        return StatusCode(response.StatusCode, response);
    }

    [HttpPost]
    public async Task<IActionResult> GetDoctors(GetAllDoctorsQuery request, CancellationToken cancellationToken)
    {
        var response = await _mediator.Send(request, cancellationToken);
        return StatusCode(response.StatusCode, response);
    }

    [HttpPost]
    public async Task<IActionResult> GetDepartments(GetAllDepartmentsQuery request, CancellationToken cancellationToken)
    {
        var response = await _mediator.Send(request, cancellationToken);
        return StatusCode(response.StatusCode, response);
    }

    [HttpPost]
    public async Task<IActionResult> GetServices(GetAllServicesQuery request, CancellationToken cancellationToken)
    {
        var response = await _mediator.Send(request, cancellationToken);
        return StatusCode(response.StatusCode, response);
    }

    [HttpPost]
    public async Task<IActionResult> GetFaqs(GetAllFaqsQuery request, CancellationToken cancellationToken)
    {
        var response = await _mediator.Send(request, cancellationToken);
        return StatusCode(response.StatusCode, response);
    }

    [HttpPost]
    public async Task<IActionResult> GetAnnouncmenets(GetAllAnnouncementsQuery request, CancellationToken cancellationToken)
    {
        var response = await _mediator.Send(request, cancellationToken);
        return StatusCode(response.StatusCode, response);
    }

    [HttpPost]
    public async Task<IActionResult> GetByAnnouncement(string id, CancellationToken cancellationToken)
    {
        var response = await _mediator.Send(new GetByIdAnnouncementQuery(id), cancellationToken);
        return StatusCode(response.StatusCode, response);
    }
}

using eHospitalServer.Application.Features.Announcements.GetByIdAnnouncement;
using eHospitalServer.Application.Features.Home.GetAllAnnouncements;
using eHospitalServer.Application.Features.Home.GetAllDepartments;
using eHospitalServer.Application.Features.Home.GetAllDoctors;
using eHospitalServer.Application.Features.Home.GetAllFaqs;
using eHospitalServer.Application.Features.Home.GetAllServices;
using eHospitalServer.Application.Features.Home.GetAllSliders;
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
    public async Task<IActionResult> GetSettings(CancellationToken cancellationToken)
    {
        var response = await _mediator.Send(new GetSettingsQuery(), cancellationToken);
        return StatusCode(response.StatusCode, response);
    }

    [HttpPost]
    public async Task<IActionResult> GetSliders(CancellationToken cancellationToken)
    {
        var response = await _mediator.Send(new GetAllSlidersQuery(), cancellationToken);
        return StatusCode(response.StatusCode, response);
    }

    [HttpPost]
    public async Task<IActionResult> GetDoctors(CancellationToken cancellationToken)
    {
        var response = await _mediator.Send(new GetAllDoctorsQuery(), cancellationToken);
        return StatusCode(response.StatusCode, response);
    }

    [HttpPost]
    public async Task<IActionResult> GetDepartments(CancellationToken cancellationToken)
    {
        var response = await _mediator.Send(new GetAllDepartmentsQuery(), cancellationToken);
        return StatusCode(response.StatusCode, response);
    }

    [HttpPost]
    public async Task<IActionResult> GetServices(CancellationToken cancellationToken)
    {
        var response = await _mediator.Send(new GetAllServicesQuery(), cancellationToken);
        return StatusCode(response.StatusCode, response);
    }

    [HttpPost]
    public async Task<IActionResult> GetFaqs(CancellationToken cancellationToken)
    {
        var response = await _mediator.Send(new GetAllFaqsQuery(), cancellationToken);
        return StatusCode(response.StatusCode, response);
    }

    [HttpPost]
    public async Task<IActionResult> GetAnnouncmenets(CancellationToken cancellationToken)
    {
        var response = await _mediator.Send(new GetAllAnnountcementsQuery(), cancellationToken);
        return StatusCode(response.StatusCode, response);
    }

    [HttpPost]
    public async Task<IActionResult> GetByAnnouncement(string id, CancellationToken cancellationToken)
    {
        var response = await _mediator.Send(new GetByIdAnnouncementQuery(id), cancellationToken);
        return StatusCode(response.StatusCode, response);
    }
}

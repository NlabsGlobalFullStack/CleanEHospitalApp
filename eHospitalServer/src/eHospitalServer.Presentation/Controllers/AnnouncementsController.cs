using eHospitalServer.Application.Features.Announcements.GetAllAnnouncements;
using eHospitalServer.Application.Features.Announcements.GetByIdAnnouncement;
using eHospitalServer.Application.Features.Announcements.CreateAnnouncement;
using eHospitalServer.Application.Features.Announcements.UpdateAnnouncement;
using eHospitalServer.Application.Features.Announcements.ChangeStatusAnnouncement;
using eHospitalServer.Application.Features.Announcements.SoftDeleteByIdAnnouncement;
using eHospitalServer.Application.Features.Announcements.DeleteByIdAnnouncement;
using eHospitalServer.Presentation.Abstraction;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace eHospitalServer.Presentation.Controllers;
public sealed class AnnouncementsController : ApiController
{
    public AnnouncementsController(IMediator mediator) : base(mediator) {}

    [HttpGet]
    public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
    {
        var response = await _mediator.Send(new GetAllAnnountcementsQuery(), cancellationToken);
        return StatusCode(response.StatusCode, response);
    }

    [HttpGet]
    public async Task<IActionResult> GetById(GetByIdAnnouncementQuery request, CancellationToken cancellationToken)
    {
        var response = await _mediator.Send(request, cancellationToken);
        return StatusCode(response.StatusCode, response);
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateAnnouncementCommand request, CancellationToken cancellationToken)
    {
        var response = await _mediator.Send(request, cancellationToken);
        return StatusCode(response.StatusCode, response);
    }

    [HttpPost]
    public async Task<IActionResult> Update(UpdateAnnouncementCommand request, CancellationToken cancellationToken)
    {
        var response = await _mediator.Send(request, cancellationToken);
        return StatusCode(response.StatusCode, response);
    }

    [HttpPost]
    public async Task<IActionResult> ChangeStatus(ChangeStatusCommand request, CancellationToken cancellationToken)
    {
        var response = await _mediator.Send(request, cancellationToken);
        return StatusCode(response.StatusCode, response);
    }

    [HttpPost]
    public async Task<IActionResult> SoftDeleteById(string Id, CancellationToken cancellationToken)
    {
        var response = await _mediator.Send(new SoftDeleteByIdAnnouncementCommand(Id), cancellationToken);
        return StatusCode(response.StatusCode, response);
    }

    [HttpPost]
    public async Task<IActionResult> DeleteById(string Id, CancellationToken cancellationToken)
    {
        var response = await _mediator.Send(new DeleteByIdAnnouncementCommand(Id), cancellationToken);
        return StatusCode(response.StatusCode, response);
    }
}

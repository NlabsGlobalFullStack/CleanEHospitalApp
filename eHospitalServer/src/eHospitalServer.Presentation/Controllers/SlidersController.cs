using eHospitalServer.Application.Features.Sliders.CreateSlider;
using eHospitalServer.Application.Features.Sliders.DeleteByIdSlider;
using eHospitalServer.Application.Features.Sliders.GetAllSliders;
using eHospitalServer.Application.Features.Sliders.GetByIdSlider;
using eHospitalServer.Application.Features.Sliders.UpdateSlider;
using eHospitalServer.Presentation.Abstraction;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace eHospitalServer.Presentation.Controllers;
public sealed class SlidersController : ApiController
{
    public SlidersController(IMediator mediator) : base(mediator) { }

    [HttpPost]
    public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
    {
        var response = await _mediator.Send(new GetAllSlidersQuery(), cancellationToken);
        return StatusCode(response.StatusCode, response);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromForm] CreateSliderCommand request, CancellationToken cancellationToken)
    {
        var response = await _mediator.Send(request, cancellationToken);
        return StatusCode(response.StatusCode, response);
    }

    [HttpPost]
    public async Task<IActionResult> Update([FromForm] UpdateSliderCommand request, CancellationToken cancellationToken)
    {
        var response = await _mediator.Send(request, cancellationToken);
        return StatusCode(response.StatusCode, response);
    }

    [HttpPost]
    public async Task<IActionResult> GetById(string id, CancellationToken cancellationToken)
    {
        var response = await _mediator.Send(new GetByIdSliderCommand(id), cancellationToken);
        return StatusCode(response.StatusCode, response);
    }

    [HttpPost]
    public async Task<IActionResult> DeleteBy(string id, CancellationToken cancellationToken)
    {
        var response = await _mediator.Send(new DeleteByIdSliderCommand(id), cancellationToken);
        return StatusCode(response.StatusCode, response);
    }
}

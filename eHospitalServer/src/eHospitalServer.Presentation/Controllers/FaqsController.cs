using eHospitalServer.Application.Features.Faqs.CreateFaq;
using eHospitalServer.Application.Features.Faqs.DeleteByIdFaq;
using eHospitalServer.Application.Features.Faqs.GetAllFaqs;
using eHospitalServer.Application.Features.Faqs.GetByIdFaq;
using eHospitalServer.Application.Features.Faqs.UpdateFaq;
using eHospitalServer.Presentation.Abstraction;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace eHospitalServer.Presentation.Controllers;
public sealed class FaqsController : ApiController
{
    public FaqsController(IMediator mediator) : base(mediator) { }

    [HttpPost]
    public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
    {
        var response = await _mediator.Send(new GetAllFaqsQuery(), cancellationToken);
        return StatusCode(response.StatusCode, response);
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateFaqCommand request, CancellationToken cancellationToken)
    {
        var response = await _mediator.Send(request, cancellationToken);
        return StatusCode(response.StatusCode, response);
    }

    [HttpPost]
    public async Task<IActionResult> Update(UpdateFaqCommand request, CancellationToken cancellationToken)
    {
        var response = await _mediator.Send(request, cancellationToken);
        return StatusCode(response.StatusCode, response);
    }

    [HttpPost]
    public async Task<IActionResult> GetById(string id, CancellationToken cancellationToken)
    {
        var response = await _mediator.Send(new GetByIdFaqQommand(id), cancellationToken);
        return StatusCode(response.StatusCode, response);
    }

    [HttpPost]
    public async Task<IActionResult> DeleteById(string id, CancellationToken cancellationToken)
    {
        var response = await _mediator.Send(new DeleteByIdFaqCommand(id), cancellationToken);
        return StatusCode(response.StatusCode, response);
    }
}

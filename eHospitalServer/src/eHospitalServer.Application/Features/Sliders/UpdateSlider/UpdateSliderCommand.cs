using eHospitalServer.Infrastructure.Results;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace eHospitalServer.Application.Features.Sliders.UpdateSlider;
public sealed record UpdateSliderCommand
(
    string Id,
    string Title,
    string Description,
    IFormFile? File
) : IRequest<Result<string>>;

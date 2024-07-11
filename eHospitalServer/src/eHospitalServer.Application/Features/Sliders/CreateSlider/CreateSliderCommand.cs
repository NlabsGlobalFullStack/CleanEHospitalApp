using eHospitalServer.Infrastructure.Results;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace eHospitalServer.Application.Features.Sliders.CreateSlider;
public sealed record CreateSliderCommand
(
    string Title,
    string Description,
    IFormFile File
) : IRequest<Result<string>>;

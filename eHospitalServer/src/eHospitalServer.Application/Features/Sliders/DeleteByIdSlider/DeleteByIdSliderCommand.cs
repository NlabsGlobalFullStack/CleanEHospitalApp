using eHospitalServer.Infrastructure.Results;
using MediatR;

namespace eHospitalServer.Application.Features.Sliders.DeleteByIdSlider;
public sealed record DeleteByIdSliderCommand(
    string Id
    ) : IRequest<Result<string>>;

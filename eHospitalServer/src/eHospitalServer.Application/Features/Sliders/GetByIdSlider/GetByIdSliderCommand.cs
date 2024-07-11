using eHospitalServer.Infrastructure.Results;
using MediatR;

namespace eHospitalServer.Application.Features.Sliders.GetByIdSlider;
public sealed record GetByIdSliderCommand(string id) : IRequest<Result<GetByIdSliderCommandResponse>>;

using eHospitalServer.Infrastructure.Results;
using MediatR;

namespace eHospitalServer.Application.Features.Sliders.GetAllSliders;
public sealed record GetAllSlidersQuery : IRequest<Result<List<GetAllSlidersResponse>>>;

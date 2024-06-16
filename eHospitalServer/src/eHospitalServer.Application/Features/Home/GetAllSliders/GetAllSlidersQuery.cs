using eHospitalServer.Domain.Entities;
using eHospitalServer.Infrastructure.Results;
using MediatR;

namespace eHospitalServer.Application.Features.Home.GetAllSliders;
public sealed record GetAllSlidersQuery : IRequest<Result<List<Slider>>>;

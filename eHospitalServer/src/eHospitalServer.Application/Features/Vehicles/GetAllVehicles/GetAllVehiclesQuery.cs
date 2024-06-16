using eHospitalServer.Infrastructure.Results;
using MediatR;

namespace eHospitalServer.Application.Features.Vehicles.GetAllVehicles;
public sealed record GetAllVehiclesQuery : IRequest<Result<List<GetAllVehiclesQueryResponse>>>;

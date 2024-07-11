using eHospitalServer.Infrastructure.Results;
using MediatR;

namespace eHospitalServer.Application.Features.Vehicles.DeleteByIdVehicle;
public sealed record DeleteByIdVehicleCommand(string Id) : IRequest<Result<string>>;

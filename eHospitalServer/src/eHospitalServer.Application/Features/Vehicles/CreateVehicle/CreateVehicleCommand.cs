using eHospitalServer.Infrastructure.Results;
using MediatR;

namespace eHospitalServer.Application.Features.Vehicles.CreateVehicle;
public sealed record CreateVehicleCommand
(
    string Plate,
    byte VehicleTypeValue,
    byte Capacity
) : IRequest<Result<string>>;

using eHospitalServer.Infrastructure.Results;
using MediatR;

namespace eHospitalServer.Application.Features.Vehicles.UpdateVehicle;
public sealed record UpdateVehicleCommand
(
    string Id,
    string Plate,
    byte VehicleTypeValue,
    byte Capacity
) : IRequest<Result<string>>;

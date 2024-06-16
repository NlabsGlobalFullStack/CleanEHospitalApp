using eHospitalServer.Domain.Repositories;
using eHospitalServer.Infrastructure.Results;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace eHospitalServer.Application.Features.Vehicles.GetAllVehicles;

internal sealed class GetAllVehiclesQueryHandler(
    IVehicleRepository vehicleRepository
) : IRequestHandler<GetAllVehiclesQuery, Result<List<GetAllVehiclesQueryResponse>>>
{
    public async Task<Result<List<GetAllVehiclesQueryResponse>>> Handle(GetAllVehiclesQuery request, CancellationToken cancellationToken)
    {
        var vehicles = await vehicleRepository.GetAll().ToListAsync(cancellationToken);
        var response = vehicles.Select(v => new GetAllVehiclesQueryResponse
        {
            Id = v.Id,
            Plate = v.Plate,
            VehicleType = v.VehicleType,
            Capacity = v.Capacity,
            IsDeleted = v.IsDeleted
        }).ToList();

        return response;
    }
}

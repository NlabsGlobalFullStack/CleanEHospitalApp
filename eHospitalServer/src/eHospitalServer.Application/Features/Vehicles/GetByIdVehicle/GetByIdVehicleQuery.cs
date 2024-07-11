using eHospitalServer.Domain.Repositories;
using eHospitalServer.Infrastructure.Results;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace eHospitalServer.Application.Features.Vehicles.GetByIdVehicle;
public sealed record GetByIdVehicleQuery(string Id) : IRequest<Result<GetByVehicleResponse>>;

internal sealed class GetByIdVehicleQueryHandler
    (
        IVehicleRepository vehicleRepository,
        IVehicleActionRepository vehicleActionRepository,
        IVehicleMissionRepository vehicleMissionRepository
    ) : IRequestHandler<GetByIdVehicleQuery, Result<GetByVehicleResponse>>
{
    public async Task<Result<GetByVehicleResponse>> Handle(GetByIdVehicleQuery request, CancellationToken cancellationToken)
    {
        var vehicle = await vehicleRepository.GetByExpressionAsync(p => p.Id == request.Id, cancellationToken);

        if (vehicle is null)
        {
            return Result<GetByVehicleResponse>.Failure("Vehicle not found!");
        }

        var vehicleActionResponseList = new List<GetByVehicleActionResponse>();
        var vehicleMissionResponseList = new List<GetByVehicleMissionResponse>();

        var vehicleActions = await vehicleActionRepository.GetAll().Where(p => p.VehicleId == vehicle.Id).ToListAsync(cancellationToken);

        var vehicleMissions = await vehicleMissionRepository.GetAll().Where(p => p.VehicleId == vehicle.Id).ToListAsync(cancellationToken);

        foreach (var action in vehicleActions)
        {
            var acRes = new GetByVehicleActionResponse()
            {
                Id = action.Id,
                VehicleId = vehicle.Id,
                Vehicle = vehicle,
                VehiclePlate = vehicle.Plate,
                VehicleOperation = action.VehicleOperation,
                Description = action.Description,
                CreatedUser = action.CreatedUser,
                CreatedDate = action.CreatedDate,
                IsUpdated = action.IsUpdated,
                UpdatedUser = action.UpdatedUser,
                UpdatedDate = action.UpdatedDate,
                IsDeleted = action.IsDeleted,
                DeletedUser = action.DeletedUser,
                DeletedDate = action.DeletedDate,
            };
            vehicleActionResponseList.Add(acRes);
        }

        foreach (var mission in vehicleMissions)
        {
            var misRes = new GetByVehicleMissionResponse()
            {
                Id = mission.Id,
                VehicleId = mission.VehicleId,
                Vehicle = vehicle,
                VehiclePlate = vehicle.Plate,
                EmployeeId = mission.EmployeeId,
                Employee = mission.Employee,
                EmployeeName = mission.Employee!.User!.FullName,
                DoctorId = mission.DoctorId,
                Doctor = mission.Doctor,
                DoctorName = mission.Doctor!.User!.FullName,
                PatientId = mission.PatientId,
                Patient = mission.Patient,
                PatientName = mission.Patient!.User!.FullName,
                PatientRelative = mission.PatientRelative,
                TraveledRouteInformation = mission.TraveledRouteInformation,
                Destination = mission.Destination,
                Comments = mission.Comments,
                MissionDate = mission.MissionDate,
                CreatedUser = mission.CreatedUser,
                CreatedDate = mission.CreatedDate,
                IsUpdated = mission.IsUpdated,
                UpdatedUser = mission.UpdatedUser,
                UpdatedDate = mission.UpdatedDate,
                IsDeleted = mission.IsDeleted,
                DeletedUser = mission.DeletedUser,
                DeletedDate = mission.DeletedDate
            };
            vehicleMissionResponseList.Add(misRes);
        }

        var response = new GetByVehicleResponse()
        {
            Id = vehicle.Id,
            Plate = vehicle.Plate,
            VehicleType = vehicle.VehicleType,
            Capacity = vehicle.Capacity,
            VehicleActions = vehicleActionResponseList,
            VehicleMissions = vehicleMissionResponseList
        };

        return response;
    }
}

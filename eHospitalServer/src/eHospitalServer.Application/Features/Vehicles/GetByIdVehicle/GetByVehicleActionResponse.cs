using eHospitalServer.Domain.Entities;
using eHospitalServer.Domain.Enums;

namespace eHospitalServer.Application.Features.Vehicles.GetByIdVehicle;

public sealed record GetByVehicleActionResponse
{
    public string Id { get; set; } = default!;
    public string EmployeeId { get; set; } = default!;
    public Employee? Employee { get; set; }
    public string VehicleId { get; set; } = default!;
    public Vehicle? Vehicle { get; set; }
    public string VehiclePlate { get; set; } = default!;
    public VehicleOperationTypeEnum VehicleOperation { get; set; } = VehicleOperationTypeEnum.Purchased;
    public string Description { get; set; } = default!;
    public string? CreatedUser { get; set; } = default;
    public DateTime CreatedDate { get; set; } = default;
    public string? UpdatedUser { get; set; } = default;
    public DateTime? UpdatedDate { get; set; } = default;
    public bool IsUpdated { get; set; }
    public string? DeletedUser { get; set; } = default;
    public DateTime? DeletedDate { get; set; } = default;
    public bool IsDeleted { get; set; }
}

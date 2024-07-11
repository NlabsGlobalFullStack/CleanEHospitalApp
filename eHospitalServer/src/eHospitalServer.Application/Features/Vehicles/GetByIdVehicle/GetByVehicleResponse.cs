using eHospitalServer.Domain.Enums;

namespace eHospitalServer.Application.Features.Vehicles.GetByIdVehicle;

public sealed record GetByVehicleResponse
{
    public string Id { get; set; } = default!;
    public string Plate { get; set; } = string.Empty;
    public VehicleTypeEnum VehicleType { get; set; } = VehicleTypeEnum.Official;
    public byte Capacity { get; set; } = 4;

    public List<GetByVehicleActionResponse>? VehicleActions { get; set; }
    public List<GetByVehicleMissionResponse>? VehicleMissions { get; set; }

    public string? CreatedUser { get; set; } = default;
    public DateTime CreatedDate { get; set; } = default;
    public string? UpdatedUser { get; set; } = default;
    public DateTime? UpdatedDate { get; set; } = default;
    public bool IsUpdated { get; set; }
    public string? DeletedUser { get; set; } = default;
    public DateTime? DeletedDate { get; set; } = default;
    public bool IsDeleted { get; set; }
}

using eHospitalServer.Domain.Enums;

namespace eHospitalServer.Application.Features.Vehicles.GetAllVehicles;

public sealed record GetAllVehiclesQueryResponse
{
    public string Id { get; set; } = default!;
    public string Plate { get; set; } = default!;
    public VehicleTypeEnum VehicleType { get; set; } = VehicleTypeEnum.Official;
    public int VehicleTypeValue { get; set; } = default!;
    public byte Capacity { get; set; } = 4;

    public string? CreatedUser { get; set; } = default;
    public DateTime CreatedDate { get; set; } = DateTime.Now;
    public string? UpdatedUser { get; set; } = default;
    public DateTime? UpdatedDate { get; set; } = default;
    public bool IsUpdated { get; set; } = false;
    public string? DeletedUser { get; set; } = default;
    public DateTime? DeletedDate { get; set; } = default;
    public bool IsDeleted { get; set; } = false;
}

using eHospitalServer.Domain.Enums;

namespace eHospitalServer.Application.Features.Vehicles.GetAllVehicles;

public sealed record GetAllVehiclesQueryResponse
{
    public string Id { get; set; } = default!;
    public string Plate { get; set; } = default!;
    public VehicleTypeEnum VehicleType { get; set; } = VehicleTypeEnum.Official;
    public int VehicleTypeValue { get; set; } = default!;
    public byte Capacity { get; set; } = 4;
    public bool IsDeleted { get; set; } = false;
}

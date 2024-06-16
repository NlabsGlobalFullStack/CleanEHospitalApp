using eHospitalServer.Domain.Enums;

namespace eHospitalServer.Application.Features.Vehicles.GetAllVehicles;

public sealed record GetAllVehiclesQueryResponse
{
    public string Id { get; set; } = string.Empty;
    public string Plate { get; set; } = string.Empty;
    public VehicleTypeEnum VehicleType { get; set; } = VehicleTypeEnum.Official;
    public byte Capacity { get; set; } = 4;
    public bool IsDeleted { get; set; } = false;
}

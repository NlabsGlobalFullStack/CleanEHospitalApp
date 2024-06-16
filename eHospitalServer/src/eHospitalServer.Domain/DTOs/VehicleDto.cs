using eHospitalServer.Domain.Enums;

namespace eHospitalServer.Domain.DTOs;
public sealed record VehicleDto
{
    public string Id { get; set; } = string.Empty;
    public string Plate { get; set; } = string.Empty;
    public VehicleTypeEnum VehicleType { get; set; } = VehicleTypeEnum.Official;
    public byte Capacity { get; set; } = 4;
    public bool IsActive { get; set; } = true;
    public bool IsDeleted { get; set; } = false;
}

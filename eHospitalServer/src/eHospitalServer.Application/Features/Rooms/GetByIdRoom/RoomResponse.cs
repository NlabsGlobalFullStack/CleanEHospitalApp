using eHospitalServer.Domain.Enums;

namespace eHospitalServer.Application.Features.Rooms.GetByIdRoom;

public sealed record RoomResponse
{
    public string Id { get; set; } = string.Empty;
    public string Number { get; set; } = string.Empty;
    public string Department { get; set; } = string.Empty;
    public RoomTypeEnum RoomType { get; set; } = RoomTypeEnum.PatientRoom;
    public byte Capacity { get; set; } = 1;
    public bool IsOccupied { get; set; } = false;
    public bool IsOutOfService { get; set; } = true;
    public bool IsDeleted { get; set; } = false;
}

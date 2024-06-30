using eHospitalServer.Domain.Enums;

namespace eHospitalServer.Application.Features.Rooms.GetAllRooms;

public sealed record GetAllRoomsQueryResponse
{
    public string Id { get; set; } = string.Empty;
    public string Number { get; set; } = string.Empty;
    public string Department { get; set; } = string.Empty;
    public RoomTypeEnum RoomType { get; set; } = RoomTypeEnum.PatientRoom;
    public byte Capacity { get; set; } = 1;
    public bool IsOccupied { get; set; } = false;
    public bool IsOutOfService { get; set; } = true;

    public string CreatedUser { get; set; } = default!;
    public DateTime CreatedDate { get; set; } = default;

    public string? UpdatedUser { get; set; } = default;
    public bool IsUpdated { get; set; } = default;
    public DateTime? UpdatedDate { get; set; } = default;

    public string? DeletedUser { get; set; } = default;
    public bool IsDeleted { get; set; } = false;
    public DateTime? DeletedDate { get; set; } = default;
}

using eHospitalServer.Domain.Abstraction;
using eHospitalServer.Domain.Enums;

namespace eHospitalServer.Domain.Entities;
public class Room : Entity
{
    public string Number { get; set; } = string.Empty;
    public string DepartmentId { get; set; } = string.Empty;
    public Department? Department { get; set; }
    public RoomTypeEnum RoomType { get; set; } = RoomTypeEnum.PatientRoom;
    public byte Capacity { get; set; } = 1;
    public bool IsOccupied { get; set; } = false;
    public bool IsOutOfService { get; set; } = true;

    public List<RoomAction>? RoomActions { get; set; }
}

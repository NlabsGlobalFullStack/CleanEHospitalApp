using eHospitalServer.Domain.Abstraction;
using eHospitalServer.Domain.Enums;

namespace eHospitalServer.Domain.Entities;
public class Room : Entity
{
    public string Number { get; set; } = string.Empty;
    public DepartmentEnum Department { get; set; } = DepartmentEnum.Emergency;
    public RoomTypeEnum RoomType { get; set; } = RoomTypeEnum.PatientRoom;
    public byte Capacity { get; set; } = 1;
    public bool IsOccupied { get; set; } = false;
    public bool IsOutOfService { get; set; } = true;
    public bool IsDeleted { get; set; } = false;

    public ICollection<RoomAction>? RoomActions { get; set; }
}

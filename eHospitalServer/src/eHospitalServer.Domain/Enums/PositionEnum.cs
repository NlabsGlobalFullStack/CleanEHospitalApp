using Ardalis.SmartEnum;

namespace eHospitalServer.Domain.Enums;
public sealed class PositionEnum : SmartEnum<PositionEnum>
{
    public static readonly PositionEnum Driver = new ("Driver Position", 1);
    public static readonly PositionEnum AmbulanceDriver = new("Ambulance Driver Position", 2);
    public static readonly PositionEnum Technician = new("Technician Position", 3);
    public static readonly PositionEnum Administrator = new("Administrator Position", 4);
    public static readonly PositionEnum Receptionist = new("Receptionist Position", 5);
    public static readonly PositionEnum Janitor = new("Janitor Position", 6);
    public static readonly PositionEnum SecurityGuard = new("Security Guard Position", 7);
    public static readonly PositionEnum Nurse = new("Nurse Position", 8);
    public static readonly PositionEnum DoctorSecretary = new("Doctor Secretary Position", 9);
    public static readonly PositionEnum Assistant = new("Assistant Position", 10);
    public static readonly PositionEnum Other = new("Other Position", 11);
    public PositionEnum(string name, int value) : base(name, value)
    {
    }
}

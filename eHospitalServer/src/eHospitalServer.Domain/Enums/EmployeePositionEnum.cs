using Ardalis.SmartEnum;

namespace eHospitalServer.Domain.Enums;
public sealed class EmployeePositionEnum : SmartEnum<EmployeePositionEnum>
{
    public static readonly EmployeePositionEnum Driver = new ("Driver Position", 1);
    public static readonly EmployeePositionEnum AmbulanceDriver = new("Ambulance Driver Position", 2);
    public static readonly EmployeePositionEnum Technician = new("Technician Position", 3);
    public static readonly EmployeePositionEnum Administrator = new("Administrator Position", 4);
    public static readonly EmployeePositionEnum Receptionist = new("Receptionist Position", 5);
    public static readonly EmployeePositionEnum Janitor = new("Janitor Position", 6);
    public static readonly EmployeePositionEnum SecurityGuard = new("Security Guard Position", 7);
    public static readonly EmployeePositionEnum Nurse = new("Nurse Position", 8);
    public static readonly EmployeePositionEnum DoctorSecretary = new("Doctor Secretary Position", 9);
    public static readonly EmployeePositionEnum Assistant = new("Assistant Position", 10);
    public static readonly EmployeePositionEnum Other = new("Other Position", 11);
    public EmployeePositionEnum(string name, int value) : base(name, value)
    {
    }
}

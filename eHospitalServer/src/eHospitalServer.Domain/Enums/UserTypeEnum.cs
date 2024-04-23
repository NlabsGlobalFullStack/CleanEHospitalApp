using Ardalis.SmartEnum;

namespace eHospitalServer.Domain.Enums;
public sealed class UserTypeEnum : SmartEnum<UserTypeEnum>
{
    public static readonly UserTypeEnum Admin = new("Admin", 1);
    public static readonly UserTypeEnum Doctor = new("Doctor", 2);
    public static readonly UserTypeEnum Nurse = new("Nurse", 3);
    public static readonly UserTypeEnum Employee = new("Employee", 4);
    public static readonly UserTypeEnum Patient = new("Patient", 5);
    public UserTypeEnum(string name, int value) : base(name, value)
    {
    }
}

using Ardalis.SmartEnum;

namespace eHospitalServer.Domain.Enums;
public sealed class ShiftEnum : SmartEnum<ShiftEnum>
{
    public static readonly ShiftEnum Morning = new("Morning", 1);
    public static readonly ShiftEnum Afternoon = new("Eve Afternoonning", 2);
    public static readonly ShiftEnum Night = new("Night", 3);
    public ShiftEnum(string name, int value) : base(name, value)
    {
    }
}

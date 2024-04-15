using Ardalis.SmartEnum;

namespace eHospitalServer.Domain.Enums;
public sealed class ShiftEnum : SmartEnum<ShiftEnum>
{
    /// <summary>
    /// Sabah Vardiası
    /// </summary>
    public static readonly ShiftEnum Morning = new("Morning", 1);

    /// <summary>
    /// Ögleden Sonra Vardiası
    /// </summary>
    public static readonly ShiftEnum Afternoon = new("EveAfternoonning", 2);

    /// <summary>
    /// Gece Vardiası
    /// </summary>
    public static readonly ShiftEnum Night = new("Night", 3);
    public ShiftEnum(string name, int value) : base(name, value)
    {
    }
}

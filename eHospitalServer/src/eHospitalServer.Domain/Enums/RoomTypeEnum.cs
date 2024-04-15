using Ardalis.SmartEnum;

namespace eHospitalServer.Domain.Enums;
public sealed class RoomTypeEnum : SmartEnum<RoomTypeEnum>
{
    /// <summary>
    /// Hasta odası
    /// </summary>
    public static readonly RoomTypeEnum PatientRoom = new("Patient Room", 1);

    /// <summary>
    /// Ameliyat odası
    /// </summary>
    public static readonly RoomTypeEnum OperatingRoom = new("Operating Room", 2);

    /// <summary>
    /// YogunBakım odası
    /// </summary>
    public static readonly RoomTypeEnum IntensiveCareRoom = new ("Intensive Care Room", 3);

    /// <summary>
    /// AcilServis odası
    /// </summary>
    public static readonly RoomTypeEnum EmergencyServiceRoom = new ("Emergency Service Room", 4);

    /// <summary>
    /// AcilServis odası
    /// </summary>
    public static readonly RoomTypeEnum OtherRoom = new("Other Room", 5);
    public RoomTypeEnum(string name, int value) : base(name, value)
    {
    }
}

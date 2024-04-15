using Ardalis.SmartEnum;

namespace eHospitalServer.Domain.Enums;
public sealed class EmployeePositionEnum : SmartEnum<EmployeePositionEnum>
{
    /// <summary>
    /// Şoför / Araç şoförü makam şoförü gibi
    /// </summary>
    public static readonly EmployeePositionEnum VehicleDriver = new ("Vehicle Driver Position", 1);

    /// <summary>
    /// Ambulans Şoförü
    /// </summary>
    public static readonly EmployeePositionEnum AmbulanceDriver = new("Ambulance Driver Position", 2);

    /// <summary>
    /// Teknisyen
    /// </summary>
    public static readonly EmployeePositionEnum Technician = new("Technician Position", 3);

    /// <summary>
    /// Yönetici
    /// </summary>
    public static readonly EmployeePositionEnum Administrator = new("Administrator Position", 4);

    /// <summary>
    /// Resepsiyonist
    /// </summary>
    public static readonly EmployeePositionEnum Receptionist = new("Receptionist Position", 5);

    /// <summary>
    /// Temizlik Görevlisi
    /// </summary>
    public static readonly EmployeePositionEnum Janitor = new("Janitor Position", 6);

    /// <summary>
    /// Güvenlik Görevlisi
    /// </summary>
    public static readonly EmployeePositionEnum SecurityGuard = new("SecurityGuard Position", 7);

    /// <summary>
    /// Diger
    /// </summary>
    public static readonly EmployeePositionEnum Other = new("Other Position", 8);
    public EmployeePositionEnum(string name, int value) : base(name, value)
    {
    }
}

using eHospitalServer.Domain.Abstraction;
using eHospitalServer.Domain.Enums;

namespace eHospitalServer.Domain.Entities;
public sealed class Room : Entity
{
    /// <summary>
    /// Oda Numarası
    /// </summary>
    public string Number { get; set; } = string.Empty;

    /// <summary>
    /// Hangi Departmana Ait
    /// </summary>
    public DepartmentEnum Department { get; set; } = DepartmentEnum.Emergency;

    /// <summary>
    /// Kapasitesi
    /// </summary>
    public int Capacity { get; set; } = 1;

    /// <summary>
    /// Dolu / Boş mu
    /// </summary>
    public bool IsOccupied { get; set; } = false;

    /// <summary>
    /// Hizmet Veriyor / Vermiyor mu
    /// </summary>
    public bool IsOutOfService { get; set; } = true;
}

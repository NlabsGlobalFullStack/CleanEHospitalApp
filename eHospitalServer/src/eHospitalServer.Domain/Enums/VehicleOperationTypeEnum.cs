using Ardalis.SmartEnum;

namespace eHospitalServer.Domain.Enums;
public sealed class VehicleOperationTypeEnum : SmartEnum<VehicleOperationTypeEnum>
{
    public static readonly VehicleOperationTypeEnum Purchased = new("Satın Alındı", 1);
    public static readonly VehicleOperationTypeEnum Sold = new("Satıldı", 2);
    public static readonly VehicleOperationTypeEnum WentForRepair = new ("Arızalandı", 3);
    public static readonly VehicleOperationTypeEnum CameFromRepair = new("Arızası Giderildi", 4);
    public static readonly VehicleOperationTypeEnum BecameUnusable = new("Kullanılamaz Halde", 5);
    public VehicleOperationTypeEnum(string name, int value) : base(name, value)
    {
    }
}

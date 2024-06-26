﻿using Ardalis.SmartEnum;

namespace eHospitalServer.Domain.Enums;
public sealed class VehicleTypeEnum : SmartEnum<VehicleTypeEnum>
{
    public static readonly VehicleTypeEnum Ambulance = new("Ambulance", 1);
    public static readonly VehicleTypeEnum Official = new("Official", 2);
    public static readonly VehicleTypeEnum Service = new("Service", 3);
    public VehicleTypeEnum(string name, int value) : base(name, value)
    {
    }
}

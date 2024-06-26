﻿using eHospitalServer.Domain.Abstraction;

namespace eHospitalServer.Domain.Entities;
public sealed class Department : Entity
{
    public string Name { get; set; } = string.Empty;
    public string Image { get; set; } = string.Empty;
    public string Description { get; set; } = default!;

    public List<Doctor>? Doctors { get; set; }
    public List<Nurse>? Nurses { get; set; }
    public List<Employee>? Employees { get; set; }
    public List<Room>? Rooms { get; set; }
}

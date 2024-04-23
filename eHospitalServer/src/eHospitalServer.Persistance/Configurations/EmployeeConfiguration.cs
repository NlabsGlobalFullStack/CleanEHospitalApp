using eHospitalServer.Domain.Entities;
using eHospitalServer.Domain.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace eHospitalServer.Persistance.Configurations;
internal class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
{
    public void Configure(EntityTypeBuilder<Employee> builder)
    {
        builder.Property(p => p.Department)
        .HasConversion(v => v.Value, v => DepartmentEnum.FromValue(v))
        .HasColumnName("Department");
        builder.Property(p => p.Position)
        .HasConversion(v => v.Value, v => EmployeePositionEnum.FromValue(v))
        .HasColumnName("Position");

        //builder.HasMany(p => p.RoomActions)
        //    .WithOne(p => p.Employee)
        //    .HasForeignKey(p => p.EmployeeId);

        //builder.HasMany(p => p.VehicleActions)
        //    .WithOne(p => p.Employee)
        //    .HasForeignKey(p => p.EmployeeId);

        //builder.HasMany(p => p.VehicleMissions)
        //    .WithOne(p => p.Employee)
        //    .HasForeignKey(p => p.EmployeeId);
    }
}

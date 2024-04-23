using eHospitalServer.Domain.Entities;
using eHospitalServer.Domain.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace eHospitalServer.Persistance.Configurations;
internal class NurseConfiguration : IEntityTypeConfiguration<Nurse>
{
    public void Configure(EntityTypeBuilder<Nurse> builder)
    {
        builder.Property(p => p.Department)
            .HasConversion(v => v.Value, v => DepartmentEnum.FromValue(v))
            .HasColumnName("Department");
        builder.Property(p => p.Shift)
            .HasConversion(v => v.Value, v => ShiftEnum.FromValue(v))
            .HasColumnName("Shift");

        builder.HasMany(p => p.VehicleMissions)
            .WithOne(p => p.Nurse)
            .HasForeignKey(p => p.NurseId);
    }
}

using eHospitalServer.Domain.Entities;
using eHospitalServer.Domain.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace eHospitalServer.Persistance.Configurations;
internal class NurseConfiguration : IEntityTypeConfiguration<Nurse>
{
    public void Configure(EntityTypeBuilder<Nurse> builder)
    {
        builder.Property(p => p.Shift)
            .HasConversion(v => v.Value, v => ShiftEnum.FromValue(v))
            .HasColumnName("Shift");

        builder.HasOne(p => p.Department)
            .WithMany(p => p.Nurses)
            .HasForeignKey(p => p.DepartmentId)
            .OnDelete(DeleteBehavior.Restrict);

        builder
            .HasOne(d => d.User)
            .WithOne(u => u.Nurse)
            .HasForeignKey<Nurse>(d => d.UserId);

        builder.HasMany(p => p.VehicleMissions)
            .WithOne(p => p.Nurse)
            .HasForeignKey(p => p.NurseId);

        builder.HasMany(p => p.RoomActions)
            .WithOne(p => p.Nurse)
            .HasForeignKey(p => p.NurseId);
    }
}

using eHospitalServer.Domain.Entities;
using eHospitalServer.Domain.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace eHospitalServer.Persistance.Configurations;
internal sealed class DoctorConfiguration : IEntityTypeConfiguration<Doctor>
{
    public void Configure(EntityTypeBuilder<Doctor> builder)
    {
        builder.Property(p => p.AppointmentPrice).HasColumnType("money");
        builder.Property(p => p.Department)
            .HasConversion(t => t.Value, v => DepartmentEnum.FromValue(v))
            .HasColumnName("Department");
        builder.Property(p => p.Specialty)
            .HasConversion(t => t.Value, v => DoctorSpecialtyEnum.FromValue(v))
            .HasColumnName("Specialty");

        //builder.HasMany(p => p.Appointments)
        //    .WithOne(p => p.Doctor)
        //    .HasForeignKey(p => p.DoctorId);

        //builder.HasMany(p => p.Appointments)
        //    .WithOne(p => p.Doctor)
        //    .HasForeignKey(p => p.DoctorId);

        //builder.HasMany(p => p.RoomActions)
        //    .WithOne(p => p.Doctor)
        //    .HasForeignKey(p => p.DoctorId);

        //builder.HasMany(p => p.RoomProcedures)
        //    .WithOne(p => p.Doctor)
        //    .HasForeignKey(p => p.DoctorId);

        //builder.HasMany(p => p.VehicleMissions)
        //    .WithOne(p => p.Doctor)
        //    .HasForeignKey(p => p.DoctorId);
    }
}

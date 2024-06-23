using eHospitalServer.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace eHospitalServer.Persistance.Configurations;
internal class PatientConfiguration : IEntityTypeConfiguration<Patient>
{
    public void Configure(EntityTypeBuilder<Patient> builder)
    {
        builder
            .HasOne(d => d.User)
            .WithOne(n => n.Patient)
            .HasForeignKey<Patient>(d => d.UserId)
            .OnDelete(DeleteBehavior.NoAction);

        builder.HasMany(p => p.Appointments)
            .WithOne(p => p.Patient)
            .HasForeignKey(p => p.PatientId)
            .OnDelete(DeleteBehavior.NoAction);

        builder.HasMany(p => p.RoomActions)
            .WithOne(p => p.Patient)
            .HasForeignKey(p => p.PatientId)
            .OnDelete(DeleteBehavior.NoAction);

        builder.HasMany(p => p.VehicleMissions)
            .WithOne(p => p.Patient)
            .HasForeignKey(p => p.PatientId)
            .OnDelete(DeleteBehavior.NoAction);
    }
}

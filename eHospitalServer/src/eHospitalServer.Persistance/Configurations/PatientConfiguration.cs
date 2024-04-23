using eHospitalServer.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace eHospitalServer.Persistance.Configurations;
internal class PatientConfiguration : IEntityTypeConfiguration<Patient>
{
    public void Configure(EntityTypeBuilder<Patient> builder)
    {
        //builder.HasMany(p => p.Appointments)
        //    .WithOne(p => p.Patient)
        //    .HasForeignKey(p => p.PatientId);

        //builder.HasMany(p => p.RoomActions)
        //    .WithOne(p => p.Patient)
        //    .HasForeignKey(p => p.PatientId);

        //builder.HasMany(p => p.VehicleMissions)
        //    .WithOne(p => p.Patient)
        //    .HasForeignKey(p => p.PatientId);
    }
}

using eHospitalServer.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace eHospitalServer.Persistance.Configurations;
internal sealed class AppointmentConfiguration : IEntityTypeConfiguration<Appointment>
{
    public void Configure(EntityTypeBuilder<Appointment> builder)
    {
        //builder.HasOne(p => p.Doctor)
        //    .WithMany()
        //    .HasForeignKey(p => p.DoctorId);

        //builder.HasOne(p => p.Patient)
        //    .WithMany()
        //    .HasForeignKey(p => p.PatientId);
    }
}

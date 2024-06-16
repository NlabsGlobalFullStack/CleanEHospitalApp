using eHospitalServer.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace eHospitalServer.Persistance.Configurations;
public sealed class RoomActionConfiguration : IEntityTypeConfiguration<RoomAction>
{
    public void Configure(EntityTypeBuilder<RoomAction> builder)
    {
        builder.Property(p => p.Title).HasColumnType("varchar(60)").HasMaxLength(60);
        builder.Property(p => p.Description).HasColumnType("varchar(500)").HasMaxLength(500);

        builder.HasOne(p => p.Room)
            .WithMany(p => p.RoomActions)
            .HasForeignKey(p => p.RoomId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(p => p.Nurse)
            .WithMany(p => p.RoomActions)
            .HasForeignKey(p => p.NurseId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(p => p.Patient)
            .WithMany(p => p.RoomActions)
            .HasForeignKey(p => p.PatientId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}

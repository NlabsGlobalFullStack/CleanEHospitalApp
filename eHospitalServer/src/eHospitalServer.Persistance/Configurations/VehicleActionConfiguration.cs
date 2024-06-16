using eHospitalServer.Domain.Entities;
using eHospitalServer.Domain.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace eHospitalServer.Persistance.Configurations;
public sealed class VehicleActionConfiguration : IEntityTypeConfiguration<VehicleAction>
{
    public void Configure(EntityTypeBuilder<VehicleAction> builder)
    {
        builder.Property(p => p.Description).HasColumnType("varchar(500)").HasMaxLength(500);

        builder.Property(p => p.VehicleOperation)
            .HasConversion(t => t.Value, v => VehicleOperationTypeEnum.FromValue(v))
            .HasColumnName("VehicleOperation");


        builder.HasOne(p => p.Vehicle)
            .WithMany(p => p.VehicleActions)
            .HasForeignKey(p => p.VehicleId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(p => p.Vehicle)
            .WithMany(p => p.VehicleActions)
            .HasForeignKey(p => p.EmployeeId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}

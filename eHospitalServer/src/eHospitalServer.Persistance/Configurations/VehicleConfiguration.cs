using eHospitalServer.Domain.Entities;
using eHospitalServer.Domain.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace eHospitalServer.Persistance.Configurations;
public sealed class VehicleConfiguration : IEntityTypeConfiguration<Vehicle>
{
    public void Configure(EntityTypeBuilder<Vehicle> builder)
    {
        builder.Property(p => p.Plate).HasColumnType("varchar(20)");

        builder.Property(p => p.Capacity).HasColumnType("tinyint");

        builder.Property(p => p.VehicleType)
            .HasConversion(v => v.Value, v => VehicleTypeEnum.FromValue(v))
            .HasColumnName("VehicleType");
    }
}

using eHospitalServer.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace eHospitalServer.Persistance.Configurations;
public sealed class VehicleMissionConfiguration : IEntityTypeConfiguration<VehicleMission>
{
    public void Configure(EntityTypeBuilder<VehicleMission> builder)
    {
        builder.Property(p => p.PatientRelative).HasColumnType("varchar(60)").HasMaxLength(60);
        builder.Property(p => p.TraveledRouteInformation).HasColumnType("varchar(260)").HasMaxLength(260);
        builder.Property(p => p.Destination).HasColumnType("varchar(260)").HasMaxLength(260);
        builder.Property(p => p.Comments).HasColumnType("varchar(500)").HasMaxLength(500);
    }
}

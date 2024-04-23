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
    }
}

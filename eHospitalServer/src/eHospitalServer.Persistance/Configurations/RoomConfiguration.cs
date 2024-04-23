using eHospitalServer.Domain.Entities;
using eHospitalServer.Domain.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace eHospitalServer.Persistance.Configurations;
public sealed class RoomConfiguration : IEntityTypeConfiguration<Room>
{
    public void Configure(EntityTypeBuilder<Room> builder)
    {
        builder.Property(p => p.Number).HasColumnType("varchar(40)");

        builder.Property(p => p.Capacity).HasColumnType("tinyint");

        builder.Property(p => p.Department)
            .HasConversion(v => v.Value, v => DepartmentEnum.FromValue(v))
            .HasColumnName("Department");

        builder.Property(p => p.RoomType)
            .HasConversion(v => v.Value, v => RoomTypeEnum.FromValue(v))
            .HasColumnName("RoomType");

        //builder.HasMany(p => p.RoomActions)
        //    .WithOne(p => p.Room)
        //    .HasForeignKey(p => p.RoomId);
    }
}

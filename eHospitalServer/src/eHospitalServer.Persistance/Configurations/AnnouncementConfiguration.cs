using eHospitalServer.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace eHospitalServer.Persistance.Configurations;
internal sealed class AnnouncementConfiguration : IEntityTypeConfiguration<Announcement>
{
    public void Configure(EntityTypeBuilder<Announcement> builder)
    {
        builder.HasIndex(p => p.Title).IsUnique();
        builder.Property(p => p.Image).HasColumnType("varchar(100)");
        builder.Property(p => p.Title).HasColumnType("varchar(100)");
        builder.Property(p => p.Summary).HasColumnType("varchar(400)");
        builder.Property(p => p.Content).HasColumnType("nvarchar(MAX)");
    }
}

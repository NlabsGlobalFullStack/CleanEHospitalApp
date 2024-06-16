using eHospitalServer.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace eHospitalServer.Persistance.Configurations;
internal sealed class SliderConfiguration : IEntityTypeConfiguration<Slider>
{
    public void Configure(EntityTypeBuilder<Slider> builder)
    {
        builder.Property(p => p.Title).HasColumnType("varchar(80)");
        builder.Property(p => p.Image).HasColumnType("varchar(250)");
        builder.Property(p => p.Description).HasColumnType("nvarchar(350)");
    }
}

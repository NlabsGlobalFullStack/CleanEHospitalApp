using eHospitalServer.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace eHospitalServer.Persistance.Configurations;
internal sealed class SettingConfiguration : IEntityTypeConfiguration<Setting>
{
    public void Configure(EntityTypeBuilder<Setting> builder)
    {
        builder.Property(p => p.Logo).HasColumnType("varchar(100)");
        builder.Property(p => p.Title).HasColumnType("varchar(100)");
        builder.Property(p => p.Author).HasColumnType("varchar(50)");
        builder.Property(p => p.PhoneNumber).HasColumnType("nvarchar(20)");
        builder.Property(p => p.Email).HasColumnType("varchar(50)");
        builder.Property(p => p.Address).HasColumnType("varchar(150)");
        builder.Property(p => p.Facebook).HasColumnType("varchar(50)");
        builder.Property(p => p.Instagram).HasColumnType("varchar(50)");
        builder.Property(p => p.Twitter).HasColumnType("varchar(50)");
        builder.Property(p => p.Linkedin).HasColumnType("varchar(50)");
        builder.Property(p => p.Youtube).HasColumnType("varchar(50)");

        builder.Property(p => p.Descriptions).HasColumnType("nvarchar(MAX)");
        builder.Property(p => p.Keywords).HasColumnType("nvarchar(MAX)");
        builder.Property(p => p.About).HasColumnType("nvarchar(MAX)");
        builder.Property(p => p.MapsCode).HasColumnType("nvarchar(650)");
    }
}

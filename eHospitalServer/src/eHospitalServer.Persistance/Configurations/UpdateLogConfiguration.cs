using eHospitalServer.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace eHospitalServer.Persistance.Configurations;
internal class UpdateLogConfiguration : IEntityTypeConfiguration<UpdateLog>
{
    public void Configure(EntityTypeBuilder<UpdateLog> builder)
    {
        builder.Property(p => p.UserId).HasColumnType("varchar(100)");
        builder.Property(p => p.Method).HasColumnType("varchar(10)");
        builder.Property(p => p.EndPoint).HasColumnType("varchar(200)");
        builder.Property(p => p.OriginalValues).HasColumnType("nvarchar(MAX)");
        builder.Property(p => p.CurrentValues).HasColumnType("nvarchar(MAX)");
    }
}

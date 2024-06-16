using eHospitalServer.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace eHospitalServer.Persistance.Configurations;

internal class DeleteLogConfiguration : IEntityTypeConfiguration<DeleteLog>
{
    public void Configure(EntityTypeBuilder<DeleteLog> builder)
    {
        builder.Property(p => p.UserId).HasColumnType("varchar(100)");
        builder.Property(p => p.Method).HasColumnType("varchar(10)");
        builder.Property(p => p.EndPoint).HasColumnType("varchar(200)");
        builder.Property(p => p.Object).HasColumnType("nvarchar(MAX)");
    }
}

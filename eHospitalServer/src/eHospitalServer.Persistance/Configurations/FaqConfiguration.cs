using eHospitalServer.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace eHospitalServer.Persistance.Configurations;
internal sealed class FaqConfiguration : IEntityTypeConfiguration<Faq>
{
    public void Configure(EntityTypeBuilder<Faq> builder)
    {
        builder.HasIndex(p => p.Question).IsUnique();
        builder.Property(p => p.Question).HasColumnType("varchar(150)");
        builder.Property(p => p.Answer).HasColumnType("nvarchar(MAX)");
    }
}

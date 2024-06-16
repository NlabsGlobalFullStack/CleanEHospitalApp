using eHospitalServer.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace eHospitalServer.Persistance.Configurations;
internal sealed class DepartmentConfiguration : IEntityTypeConfiguration<Department>
{
    public void Configure(EntityTypeBuilder<Department> builder)
    {
        builder.Property(p => p.Name).HasColumnType("varchar(60)");
        builder.Property(p => p.Icon).HasColumnType("varchar(100)");
        builder.Property(p => p.Description).HasColumnType("varchar(300)");


        builder.HasMany(p => p.Doctors)
            .WithOne(p => p.Department)
            .HasForeignKey(p => p.DepartmentId);

        builder.HasMany(p => p.Nurses)
            .WithOne(p => p.Department)
            .HasForeignKey(p => p.DepartmentId);

        builder.HasMany(p => p.Employees)
            .WithOne(p => p.Department)
            .HasForeignKey(p => p.DepartmentId);

        builder.HasMany(p => p.Rooms)
            .WithOne(p => p.Department)
            .HasForeignKey(p => p.DepartmentId);
    }
}

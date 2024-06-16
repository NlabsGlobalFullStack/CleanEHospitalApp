using eHospitalServer.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace eHospitalServer.Persistance.Configurations;
internal class AppUserConfiguration : IEntityTypeConfiguration<AppUser>
{
    public void Configure(EntityTypeBuilder<AppUser> builder)
    {
        builder.HasIndex(p => p.IdentityNumber).IsUnique();
        builder.HasIndex(p => p.UserName).IsUnique();
        builder.HasIndex(p => p.Email).IsUnique();

        builder.HasIndex(p => p.EmailConfirmCode).IsUnique();
        builder.HasIndex(p => p.ForgotPasswordCode).IsUnique();

        builder.Property(p => p.IdentityNumber).HasColumnType("varchar(11)").HasMaxLength(11);
        builder.Property(p => p.FirstName).HasColumnType("varchar(50)").HasMaxLength(50);
        builder.Property(p => p.LastName).HasColumnType("varchar(50)").HasMaxLength(50);
        builder.Property(p => p.Email).HasColumnType("varchar(40)").HasMaxLength(40);
        builder.Property(p => p.PhoneNumber).HasColumnType("varchar(14)").HasMaxLength(14);

        builder.Property(p => p.EmailConfirmCode).HasColumnType("int").HasMaxLength(9);
        builder.Property(p => p.ForgotPasswordCode).HasColumnType("int").HasMaxLength(9);
        builder.Property(p => p.BloodType).HasColumnType("varchar(10)").HasMaxLength(10);
        builder.Property(p => p.City).HasColumnType("varchar(40)").HasMaxLength(40);
        builder.Property(p => p.Town).HasColumnType("varchar(50)").HasMaxLength(50);
        builder.Property(p => p.FullAddress).HasColumnType("varchar(180)").HasMaxLength(180);
        builder.Property(p => p.RefreshToken).HasColumnType("varchar(70)").HasMaxLength(70);

        builder
            .HasOne(u => u.Doctor)
            .WithOne(d => d.User)
            .HasForeignKey<Doctor>(p => p.UserId);

        builder
            .HasOne(u => u.Nurse)
            .WithOne(n => n.User)
            .HasForeignKey<Nurse>(p => p.UserId);
        builder
            .HasOne(u => u.Employee)
            .WithOne(e => e.User)
            .HasForeignKey<Employee>(p => p.UserId);
        builder
            .HasOne(u => u.Patient)
            .WithOne(p => p.User)
            .HasForeignKey<Patient>(p => p.UserId);
    }
}

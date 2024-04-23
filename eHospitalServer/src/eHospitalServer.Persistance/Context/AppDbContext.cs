using eHospitalServer.Domain.Entities;
using eHospitalServer.Domain.Repositories.DefaultRepositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace eHospitalServer.Persistance.Context;
internal sealed class AppDbContext : IdentityDbContext<
    AppUser,
    AppRole,
    string,
    IdentityUserClaim<string>,
    AppUserRole,
    IdentityUserLogin<string>,
    IdentityRoleClaim<string>,
    IdentityUserToken<string>
    >, IUnitOfWork
{
    public AppDbContext(DbContextOptions options) : base(options) {}

    public DbSet<Announcement>? Announcements { get; set; }
    public DbSet<Appointment>? Appointments { get; set; }
    public DbSet<Doctor>? Doctors { get; set; }
    public DbSet<Employee>? Employees { get; set; }
    public DbSet<Nurse>? Nurses { get; set; }
    public DbSet<Patient>? Patients { get; set; }
    public DbSet<Room>? Rooms { get; set; }
    public DbSet<RoomAction>? RoomActions { get; set; }
    public DbSet<Vehicle>? Vehicles { get; set; }
    public DbSet<VehicleAction>? VehicleActions { get; set; }
    public DbSet<VehicleMission>? VehicleMissions { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        builder.Ignore<IdentityUserLogin<string>>();
        builder.Ignore<IdentityRoleClaim<string>>();
        builder.Ignore<IdentityUserToken<string>>();
        builder.Ignore<IdentityUserRole<string>>();
        builder.Ignore<IdentityUserClaim<string>>();
    }
}

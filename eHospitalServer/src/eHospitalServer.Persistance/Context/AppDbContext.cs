using eHospitalServer.Domain.Entities;
using eHospitalServer.Domain.Repositories.DefaultRepositories;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace eHospitalServer.Persistance.Context;
internal sealed class AppDbContext : IdentityDbContext<AppUser, AppRole, string>, IUnitOfWork
{
    public AppDbContext(DbContextOptions options) : base(options) {}

    public DbSet<Announcement> Announcements { get; set; }
    public DbSet<Appointment> Appointments { get; set; }
    public DbSet<Patient> Patients { get; set; }
    public DbSet<Doctor> Doctors { get; set; }
    public DbSet<Room> Rooms { get; set; }
    public DbSet<Employee> Employees { get; set; }
    public DbSet<Nurse> Nurses { get; set; }
}

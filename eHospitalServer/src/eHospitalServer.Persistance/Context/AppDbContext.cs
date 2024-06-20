using eHospitalServer.Domain.Entities;
using eHospitalServer.Domain.Repositories.DefaultRepositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using System.Text.Json;

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
    private readonly IHttpContextAccessor _httpContextAccessor;
    public AppDbContext(DbContextOptions options, IHttpContextAccessor httpContextAccessor) : base(options)
    {
        _httpContextAccessor = httpContextAccessor;
    }

    public DbSet<Announcement>? Announcements { get; set; }
    public DbSet<Faq>? Faqs { get; set; }
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
    public DbSet<Setting>? Settings { get; set; }
    public DbSet<Slider>? Sliders { get; set; }
    public DbSet<Service>? Services { get; set; }
    public DbSet<Department>? Departments { get; set; }
    public DbSet<UpdateLog>? UpdateLogs { get; set; }
    public DbSet<DeleteLog>? DeleteLogs { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        builder.Ignore<IdentityUserLogin<string>>();
        builder.Ignore<IdentityRoleClaim<string>>();
        builder.Ignore<IdentityUserToken<string>>();
        builder.Ignore<IdentityUserRole<string>>();
        builder.Ignore<IdentityUserClaim<string>>();


    }

    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        var entries = ChangeTracker.Entries()
            .Where(e => e.State == EntityState.Added || e.State == EntityState.Modified || e.State == EntityState.Deleted);

        var userId = GetUserIdFromJwt();
        var endpoint = GetRequestEndpoint();
        var method = GetRequestMethod();

        foreach (var entry in entries)
        {
            string oldObject;
            string newObject;
            string deletedObject;

            try
            {
                oldObject = JsonSerializer.Serialize(entry.OriginalValues.ToObject());
                newObject = JsonSerializer.Serialize(entry.CurrentValues.ToObject());
                deletedObject = JsonSerializer.Serialize(entry.Entity);
            }
            catch (Exception ex)
            {
                oldObject = $"Error serializing original: {ex.Message}";
                newObject = $"Error serializing current: {ex.Message}";
                deletedObject = $"Error serializing: {ex.Message}";
            }



            var IsDeleted = (bool)entry.Property("IsDeleted").CurrentValue!;
            var IsUpdated = (bool)entry.Property("IsUpdated").CurrentValue!;

            if (entry.State == EntityState.Modified)
            {

                if (IsDeleted)
                {
                    entry.Property("DeletedDate").CurrentValue = DateTime.Now;
                }
                if (IsUpdated)
                {
                    var updateLog = new UpdateLog
                    {
                        UserId = userId,
                        Method = method,
                        EndPoint = endpoint,
                        OriginalValues = oldObject,
                        CurrentValues = newObject
                    };
                    UpdateLogs!.Add(updateLog);

                    entry.Property("UpdatedDate").CurrentValue = DateTime.Now;
                }
            }
            if (entry.State == EntityState.Deleted)
            {
                var deleteLog = new DeleteLog
                {
                    UserId = userId,
                    Method = method,
                    EndPoint = endpoint,
                    Object = deletedObject,
                };
                DeleteLogs!.Add(deleteLog);
            }
        }

        return await base.SaveChangesAsync(cancellationToken);
    }

    private string GetUserIdFromJwt()
    {
        var httpContext = _httpContextAccessor.HttpContext;
        var userIdClaim = httpContext?.User?.Claims
            .FirstOrDefault(c => c.Type == "Id");

        return userIdClaim?.Value ?? "UnknownUser";
    }

    private string GetRequestEndpoint()
    {
        var httpContext = _httpContextAccessor.HttpContext;
        return httpContext?.Request?.Path.ToString() ?? "UnknownEndpoint";
    }

    private string GetRequestMethod()
    {
        var httpContext = _httpContextAccessor.HttpContext;
        return httpContext?.Request?.Method ?? "UnknownMethod";
    }
}

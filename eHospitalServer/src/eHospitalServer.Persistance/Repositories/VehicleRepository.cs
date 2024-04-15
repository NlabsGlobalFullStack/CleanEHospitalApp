using eHospitalServer.Domain.Entities;
using eHospitalServer.Domain.Repositories;
using eHospitalServer.Persistance.Context;
using eHospitalServer.Persistance.Repositories.BaseRepository;

namespace eHospitalServer.Persistance.Repositories;
internal sealed class VehicleRepository : Repository<Vehicle, AppDbContext>, IVehicleRepository
{
    public VehicleRepository(AppDbContext context) : base(context) {}
}

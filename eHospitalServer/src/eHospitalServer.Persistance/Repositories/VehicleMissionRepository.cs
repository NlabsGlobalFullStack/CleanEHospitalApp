using eHospitalServer.Domain.Entities;
using eHospitalServer.Domain.Repositories;
using eHospitalServer.Persistance.Context;
using eHospitalServer.Persistance.Repositories.BaseRepository;

namespace eHospitalServer.Persistance.Repositories;
internal sealed class VehicleMissionRepository : Repository<VehicleMission, AppDbContext>, IVehicleMissionRepository
{
    public VehicleMissionRepository(AppDbContext context) : base(context) {}
}

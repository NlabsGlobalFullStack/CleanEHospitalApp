using eHospitalServer.Domain.Entities;
using eHospitalServer.Domain.Repositories;
using eHospitalServer.Persistance.Context;
using eHospitalServer.Persistance.Repositories.BaseRepository;

namespace eHospitalServer.Persistance.Repositories;
internal sealed class VehicleActionRepository : Repository<VehicleAction, AppDbContext>, IVehicleActionRepository
{
    public VehicleActionRepository(AppDbContext context) : base(context) {}
}

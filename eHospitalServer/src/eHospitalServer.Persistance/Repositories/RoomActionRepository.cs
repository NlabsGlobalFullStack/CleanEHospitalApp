using eHospitalServer.Domain.Entities;
using eHospitalServer.Domain.Repositories;
using eHospitalServer.Persistance.Context;
using eHospitalServer.Persistance.Repositories.BaseRepository;

namespace eHospitalServer.Persistance.Repositories;
internal sealed class RoomActionRepository : Repository<RoomAction, AppDbContext>, IRoomActionRepository
{
    public RoomActionRepository(AppDbContext context) : base(context) {}
}

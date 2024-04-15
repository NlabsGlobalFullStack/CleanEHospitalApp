using eHospitalServer.Domain.Entities;
using eHospitalServer.Domain.Repositories;
using eHospitalServer.Persistance.Context;
using eHospitalServer.Persistance.Repositories.BaseRepository;

namespace eHospitalServer.Persistance.Repositories;
internal class RoomRepository : Repository<Room, AppDbContext>, IRoomRepository
{
    public RoomRepository(AppDbContext context) : base(context) {}
}

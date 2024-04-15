using eHospitalServer.Domain.Entities;
using eHospitalServer.Domain.Repositories;
using eHospitalServer.Persistance.Context;
using eHospitalServer.Persistance.Repositories.BaseRepository;

namespace eHospitalServer.Persistance.Repositories;
internal sealed class AnnouncementRepository : Repository<Announcement, AppDbContext>, IAnnouncementRepository
{
    public AnnouncementRepository(AppDbContext context) : base(context) {}
}

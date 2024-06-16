using eHospitalServer.Domain.Entities;
using eHospitalServer.Domain.Repositories;
using eHospitalServer.Persistance.Context;
using eHospitalServer.Persistance.Repositories.BaseRepository;

namespace eHospitalServer.Persistance.Repositories;
internal sealed class SettingRepository : Repository<Setting, AppDbContext>, ISettingRepository
{
    public SettingRepository(AppDbContext context) : base(context) {}
}

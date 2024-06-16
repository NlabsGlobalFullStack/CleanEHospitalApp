using eHospitalServer.Domain.Entities;
using eHospitalServer.Domain.Repositories;
using eHospitalServer.Persistance.Context;
using eHospitalServer.Persistance.Repositories.BaseRepository;

namespace eHospitalServer.Persistance.Repositories;
internal sealed class LogRepository : Repository<UpdateLog, AppDbContext>, ILogRepository
{
    public LogRepository(AppDbContext context) : base(context) {}
}

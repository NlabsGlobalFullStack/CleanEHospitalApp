using eHospitalServer.Domain.Entities;
using eHospitalServer.Domain.Repositories;
using eHospitalServer.Persistance.Context;
using eHospitalServer.Persistance.Repositories.BaseRepository;

namespace eHospitalServer.Persistance.Repositories;
internal sealed class NurseRepository : Repository<Nurse, AppDbContext>, INurseRepository
{
    public NurseRepository(AppDbContext context) : base(context) {}
}

using eHospitalServer.Domain.Entities;
using eHospitalServer.Domain.Repositories;
using eHospitalServer.Persistance.Context;
using eHospitalServer.Persistance.Repositories.BaseRepository;

namespace eHospitalServer.Persistance.Repositories;
internal sealed class ServiceRepository : Repository<Service, AppDbContext>, IServiceRepository
{
    public ServiceRepository(AppDbContext context) : base(context) {}
}

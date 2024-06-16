using eHospitalServer.Domain.Entities;
using eHospitalServer.Domain.Repositories;
using eHospitalServer.Persistance.Context;
using eHospitalServer.Persistance.Repositories.BaseRepository;

namespace eHospitalServer.Persistance.Repositories;
internal sealed class DepartmentRepository : Repository<Department, AppDbContext>, IDepartmentRepository
{
    public DepartmentRepository(AppDbContext context) : base(context) {}
}

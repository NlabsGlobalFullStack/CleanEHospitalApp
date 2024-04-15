using eHospitalServer.Domain.Entities;
using eHospitalServer.Domain.Repositories;
using eHospitalServer.Persistance.Context;
using eHospitalServer.Persistance.Repositories.BaseRepository;

namespace eHospitalServer.Persistance.Repositories;
internal sealed class EmployeeRepository : Repository<Employee, AppDbContext>, IEmployeeRepository
{
    public EmployeeRepository(AppDbContext context) : base(context) {}
}

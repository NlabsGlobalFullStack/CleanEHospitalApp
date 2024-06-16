using eHospitalServer.Domain.Entities;
using eHospitalServer.Domain.Repositories;
using eHospitalServer.Persistance.Context;
using eHospitalServer.Persistance.Repositories.BaseRepository;

namespace eHospitalServer.Persistance.Repositories;

internal sealed class UserRepository : Repository<AppUser, AppDbContext>, IUserRepository
{
    public UserRepository(AppDbContext context) : base(context) { }
}

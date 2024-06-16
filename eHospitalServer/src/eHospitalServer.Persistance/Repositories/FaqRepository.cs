using eHospitalServer.Domain.Entities;
using eHospitalServer.Domain.Repositories;
using eHospitalServer.Persistance.Context;
using eHospitalServer.Persistance.Repositories.BaseRepository;

namespace eHospitalServer.Persistance.Repositories;
internal sealed class FaqRepository : Repository<Faq, AppDbContext>, IFaqRepository
{
    public FaqRepository(AppDbContext context) : base(context) {}
}

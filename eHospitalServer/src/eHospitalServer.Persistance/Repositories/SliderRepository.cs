using eHospitalServer.Domain.Entities;
using eHospitalServer.Domain.Repositories;
using eHospitalServer.Persistance.Context;
using eHospitalServer.Persistance.Repositories.BaseRepository;

namespace eHospitalServer.Persistance.Repositories;
internal sealed class SliderRepository : Repository<Slider, AppDbContext>, ISliderRepository
{
    public SliderRepository(AppDbContext context) : base(context) {}
}

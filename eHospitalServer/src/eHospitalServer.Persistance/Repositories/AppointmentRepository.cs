using eHospitalServer.Domain.Entities;
using eHospitalServer.Domain.Repositories;
using eHospitalServer.Persistance.Context;
using eHospitalServer.Persistance.Repositories.BaseRepository;

namespace eHospitalServer.Persistance.Repositories;
internal sealed class AppointmentRepository : Repository<Appointment, AppDbContext>, IAppointmentRepository
{
    public AppointmentRepository(AppDbContext context) : base(context) {}
}

using eHospitalServer.Domain.Entities;
using eHospitalServer.Domain.Repositories;
using eHospitalServer.Persistance.Context;
using eHospitalServer.Persistance.Repositories.BaseRepository;

namespace eHospitalServer.Persistance.Repositories;
internal sealed class PatientRepository : Repository<Patient, AppDbContext>, IPatientRepository
{
    public PatientRepository(AppDbContext context) : base(context) {}
}

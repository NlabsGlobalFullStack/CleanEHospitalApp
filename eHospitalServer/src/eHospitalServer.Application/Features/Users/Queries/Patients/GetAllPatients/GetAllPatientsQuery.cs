using eHospitalServer.Infrastructure.Results;
using MediatR;

namespace eHospitalServer.Application.Features.Users.Queries.Patients.GetAllPatients;
public sealed record GetAllPatientsQuery : IRequest<Result<List<GetAllPatientsQueryResponse>>>;

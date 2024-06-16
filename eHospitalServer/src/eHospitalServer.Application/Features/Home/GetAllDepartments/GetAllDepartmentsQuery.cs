using eHospitalServer.Infrastructure.Results;
using MediatR;

namespace eHospitalServer.Application.Features.Home.GetAllDepartments;
public sealed class GetAllDepartmentsQuery : IRequest<Result<List<DepartmentResponse>>>;

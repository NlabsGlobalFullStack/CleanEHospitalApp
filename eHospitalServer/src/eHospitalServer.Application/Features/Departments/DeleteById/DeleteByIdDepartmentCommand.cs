using eHospitalServer.Infrastructure.Results;
using MediatR;

namespace eHospitalServer.Application.Features.Departments.DeleteById;
public sealed record DeleteByIdDepartmentCommand(string Id) : IRequest<Result<string>>;

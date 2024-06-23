using eHospitalServer.Infrastructure.Results;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace eHospitalServer.Application.Features.Departments.UpdateDepartment;
public sealed record UpdateDepartmentCommand(
    string Id,
    string Name,
    string Description,
    IFormFile? File
) : IRequest<Result<string>>;

using eHospitalServer.Infrastructure.Results;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace eHospitalServer.Application.Features.Departments.CreateDepartment;
public sealed record CreateDepartmentCommand(
    string Name,
    IFormFile File,
    string Description
) : IRequest<Result<string>>;

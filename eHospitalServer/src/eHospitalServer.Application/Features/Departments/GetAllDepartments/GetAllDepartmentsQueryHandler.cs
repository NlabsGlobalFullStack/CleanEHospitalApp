using eHospitalServer.Domain.Repositories;
using eHospitalServer.Infrastructure.Results;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace eHospitalServer.Application.Features.Departments.GetAllDepartments;

internal sealed class GetAllDepartmentsQueryHandler(IDepartmentRepository departmentRepository) : IRequestHandler<GetAllDepartmentsQuery, Result<List<DepartmentResponse>>>
{
    public async Task<Result<List<DepartmentResponse>>> Handle(GetAllDepartmentsQuery request, CancellationToken cancellationToken)
    {
        var departments = await departmentRepository.Where(p => p.IsDeleted == false).ToListAsync(cancellationToken);

        var response = departments.Select(p => new DepartmentResponse
        {
            Id = p.Id,
            Name = p.Name,
            Icon = p.Icon
        }).ToList();

        return response;
    }
}

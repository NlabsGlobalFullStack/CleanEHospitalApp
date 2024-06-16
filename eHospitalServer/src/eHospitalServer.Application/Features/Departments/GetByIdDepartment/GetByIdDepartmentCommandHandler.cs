using eHospitalServer.Domain.Repositories;
using eHospitalServer.Infrastructure.Results;
using MediatR;

namespace eHospitalServer.Application.Features.Departments.GetByIdDepartment;

internal sealed class GetByIdDepartmentCommandHandler(IDepartmentRepository departmentRepository) : IRequestHandler<GetByIdDepartmentCommand, Result<DepartmentResponse>>
{
    public async Task<Result<DepartmentResponse>> Handle(GetByIdDepartmentCommand request, CancellationToken cancellationToken)
    {
        var department = await departmentRepository.GetByExpressionAsync(p => p.Id == request.Id, cancellationToken);
        if (department is null)
        {
            return Result<DepartmentResponse>.Failure("Department not found!");
        }

        var response = new DepartmentResponse
        {
            Id = department.Id,
            Name = department.Name,
            Icon = department.Icon,
            Description = department.Description!
        };

        return response;
    }
}

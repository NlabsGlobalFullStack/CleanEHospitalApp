using AutoMapper;
using eHospitalServer.Domain.Entities;
using eHospitalServer.Domain.Repositories;
using eHospitalServer.Domain.Repositories.DefaultRepositories;
using eHospitalServer.Infrastructure.Results;
using MediatR;

namespace eHospitalServer.Application.Features.Departments.UpdateDepartment;
public sealed record UpdateDepartmentCommand(
    string Id,
    string Name,
    string Icon,
    string? Description
) : IRequest<Result<string>>;

internal sealed class UpdateDepartmentCommandHandler(
    IDepartmentRepository departmentRepository,
    IMapper mapper,
    IUnitOfWork unitOfWork
) : IRequestHandler<UpdateDepartmentCommand, Result<string>>
{
    public async Task<Result<string>> Handle(UpdateDepartmentCommand request, CancellationToken cancellationToken)
    {
        var department = await departmentRepository.GetByExpressionAsync(p => p.Id == request.Id, cancellationToken);
        if (department is null)
        {
            return Result<string>.Failure("Department not found!");
        }

        var result = mapper.Map<Department>(request);

        departmentRepository.Update(result);
        await unitOfWork.SaveChangesAsync(cancellationToken);

        return "Department update process was successful.";
    }
}

using eHospitalServer.Domain.Repositories;
using eHospitalServer.Domain.Repositories.DefaultRepositories;
using eHospitalServer.Infrastructure.Results;
using MediatR;

namespace eHospitalServer.Application.Features.Departments.DeleteByIdDepartment;

internal sealed class DeleteByIdDepartmentCommandHandler(
    IDepartmentRepository departmentRepository,
    IUnitOfWork unitOfWork
) : IRequestHandler<DeleteByIdDepartmentCommand, Result<string>>
{
    public async Task<Result<string>> Handle(DeleteByIdDepartmentCommand request, CancellationToken cancellationToken)
    {
        var department = await departmentRepository.GetByExpressionAsync(p => p.Id == request.Id, cancellationToken);
        if (department is null)
        {
            return Result<string>.Failure("Department not found!");
        }
        department.IsDeleted = true;
        department.DeletedDate = DateTime.Now;
        departmentRepository.Update(department);
        await unitOfWork.SaveChangesAsync(cancellationToken);

        return "The department is marked as deleted.";
    }
}

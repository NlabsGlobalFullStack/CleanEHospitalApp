using AutoMapper;
using eHospitalServer.Application.Events.Departments;
using eHospitalServer.Domain.Entities;
using eHospitalServer.Domain.Repositories;
using eHospitalServer.Domain.Repositories.DefaultRepositories;
using eHospitalServer.Infrastructure.Results;
using MediatR;

namespace eHospitalServer.Application.Features.Departments.CreateDepartment;

internal sealed class CreateDepartmentCommandHandler(
    IDepartmentRepository departmentRepository,
    IMapper mapper,
    IUnitOfWork unitOfWork,
    IMediator mediator
) : IRequestHandler<CreateDepartmentCommand, Result<string>>
{
    public async Task<Result<string>> Handle(CreateDepartmentCommand request, CancellationToken cancellationToken)
    {
        var department = await departmentRepository.GetByExpressionAsync(p => p.Name == request.Name, cancellationToken);
        if (department is not null)
        {
            return Result<string>.Failure("This department has been recorded before!");
        }

        var result = mapper.Map<Department>(request);


        await departmentRepository.AddAsync(result, cancellationToken);
        var saveChangesResult = await unitOfWork.SaveChangesAsync(cancellationToken);

        if (saveChangesResult > 0)
        {
            try
            {
                //await mediator.Publish(new DepartmentDomain(department!.Id), cancellationToken);
            }
            catch (Exception ex)
            {
                return Result<string>.Failure($"Error while publishing announcement: {ex.Message}");
            }
        }
        

        return "The department record has been created successfully.";
    }
}

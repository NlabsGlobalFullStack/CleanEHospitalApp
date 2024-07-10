using AutoMapper;
using eHospitalServer.Application.Events.Departments;
using eHospitalServer.Domain.Entities;
using eHospitalServer.Domain.Repositories;
using eHospitalServer.Domain.Repositories.DefaultRepositories;
using eHospitalServer.Infrastructure.Extensions;
using eHospitalServer.Infrastructure.Results;
using MediatR;
using Nlabs.FileService;

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
        var departmentIsExists = await departmentRepository.GetByExpressionAsync(p => p.Name == request.Name, cancellationToken);
        if (departmentIsExists is not null)
        {
            return Result<string>.Failure("This department has been recorded before!");
        }

        var department = mapper.Map<Department>(request);

        var fileName = FileService.FileSaveToServer(request.File, "wwwroot/departments/");
        department.Image = fileName;


        await departmentRepository.AddAsync(department, cancellationToken);
        //await unitOfWork.SaveChangesAsync(cancellationToken);

        var savechangesresult = await unitOfWork.SaveChangesAsync(cancellationToken);

        if (savechangesresult > 0)
        {
            var subject = department.Name;
            var body = EmailBodies.CreateDepartmentEmailBody(subject);
            await mediator.Publish(new DepartmentDomain(department, subject, body), cancellationToken);
        }


        return "The department record has been created successfully.";
    }
}

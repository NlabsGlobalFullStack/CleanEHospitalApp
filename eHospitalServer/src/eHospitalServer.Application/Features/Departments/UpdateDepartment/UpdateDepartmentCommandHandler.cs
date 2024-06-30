using AutoMapper;
using eHospitalServer.Domain.Entities;
using eHospitalServer.Domain.Repositories;
using eHospitalServer.Domain.Repositories.DefaultRepositories;
using eHospitalServer.Infrastructure.Results;
using MediatR;
using Nlabs.FileService;

namespace eHospitalServer.Application.Features.Departments.UpdateDepartment;

internal sealed class UpdateDepartmentCommandHandler(
    IDepartmentRepository departmentRepository,
    IMapper mapper,
    IUnitOfWork unitOfWork,
    IFileHostEnvironment fileHostEnvironment
) : IRequestHandler<UpdateDepartmentCommand, Result<string>>
{
    public async Task<Result<string>> Handle(UpdateDepartmentCommand request, CancellationToken cancellationToken)
    {
        var departmentIsExists = await departmentRepository.GetByExpressionAsync(p => p.Id == request.Id, cancellationToken);
        if (departmentIsExists is null)
        {
            return Result<string>.Failure("Department not found!");
        }

        var department = mapper.Map<Department>(request);


        if (request.File is null)
        {
            var ImageName = departmentIsExists.Image;
            department.Image = ImageName;
        }

        if (request.File is not null)
        {
            var fullPath = Path.Combine(fileHostEnvironment.WebRootPath, "departments", departmentIsExists.Image);

            if (File.Exists(fullPath))
            {
                FileService.FileDeleteToServer(fullPath);
            }
            var fileName = FileService.FileSaveToServer(request.File, "wwwroot/departments/");
            department.Image = fileName;
        }

        department.IsUpdated = true;
        departmentRepository.Update(department);
        await unitOfWork.SaveChangesAsync(cancellationToken);

        return "Department update process was successful.";
    }
}

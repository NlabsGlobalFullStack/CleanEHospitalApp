using eHospitalServer.Domain.Repositories;
using eHospitalServer.Domain.Repositories.CustomRepositories;
using eHospitalServer.Domain.Repositories.DefaultRepositories;
using eHospitalServer.Infrastructure.Results;
using MediatR;

namespace eHospitalServer.Application.Features.Departments.DeleteById;

internal sealed class DeleteByIdDepartmentCommandHandler(
    IDepartmentRepository departmentRepository,
    IUnitOfWork unitOfWork,
    IMyHostEnvironment hostEnvironment
) : IRequestHandler<DeleteByIdDepartmentCommand, Result<string>>
{
    public async Task<Result<string>> Handle(DeleteByIdDepartmentCommand request, CancellationToken cancellationToken)
    {
        var department = await departmentRepository.GetByExpressionAsync(p => p.Id == request.Id, cancellationToken);
        if (department is null)
        {
            return Result<string>.Failure("Department not found!");
        }

        //kendime ait bir Dosya silme işlemi yazdım
        //kendi kütüphaneme daha sonra entegre edecegim.
        var fullPath = Path.Combine(hostEnvironment.WebRootPath, "departments", department.Image);

        if (File.Exists(fullPath))
        {
            File.Delete(fullPath);
        }

        //Sanırım izinler ile alakalı bir sıkıntı var dosya silemedim.
        //FileService.FileDeleteToServer(fullPath);


        department.IsDeleted = true;
        departmentRepository.Delete(department);
        await unitOfWork.SaveChangesAsync(cancellationToken);

        return "The relevant record has been deleted. If you want, you can undo the transaction from the deleted records!";
    }
}

using eHospitalServer.Domain.Repositories;
using eHospitalServer.Domain.Repositories.DefaultRepositories;
using eHospitalServer.Infrastructure.Results;
using MediatR;

namespace eHospitalServer.Application.Features.Vehicles.DeleteByIdVehicle;

internal sealed class DeleteByIdVehicleCommandHandler
    (
        IVehicleRepository vehicleRepository,
        IUnitOfWork unitOfWork
    ) : IRequestHandler<DeleteByIdVehicleCommand, Result<string>>
{
    public async Task<Result<string>> Handle(DeleteByIdVehicleCommand request, CancellationToken cancellationToken)
    {
        var vehicle = await vehicleRepository.GetByExpressionAsync(p => p.Id == request.Id, cancellationToken);

        if (vehicle is null)
        {
            return Result<string>.Failure("Vehicle not found!");
        }

        vehicle.IsDeleted = true;
        vehicleRepository.Delete(vehicle);

        await unitOfWork.SaveChangesAsync(cancellationToken);

        return "The vehicle delete process is successful";
    }
}

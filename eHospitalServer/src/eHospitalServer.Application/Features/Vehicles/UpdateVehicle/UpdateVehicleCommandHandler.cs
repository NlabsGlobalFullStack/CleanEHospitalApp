using AutoMapper;
using eHospitalServer.Domain.Repositories;
using eHospitalServer.Domain.Repositories.DefaultRepositories;
using eHospitalServer.Infrastructure.Results;
using MediatR;

namespace eHospitalServer.Application.Features.Vehicles.UpdateVehicle;

internal sealed class UpdateVehicleCommandHandler
    (
        IVehicleRepository vehicleRepository,
        IMapper mapper,
        IUnitOfWork unitOfWork
    ) : IRequestHandler<UpdateVehicleCommand, Result<string>>
{
    public async Task<Result<string>> Handle(UpdateVehicleCommand request, CancellationToken cancellationToken)
    {
        var vehicleIsExists = await vehicleRepository.GetByExpressionAsync(p => p.Id == request.Id, cancellationToken);

        if (vehicleIsExists is null)
        {
            return Result<string>.Failure("Vehicle not found!");
        }

        if (request.Plate != vehicleIsExists.Plate)
        {
            var plateExists = await vehicleRepository.AnyAsync(p => p.Plate == request.Plate, cancellationToken);
            if (plateExists)
            {
                return Result<string>.Failure($"{vehicleIsExists.Plate} The vehicle with the license plate is already registered!");
            }
        }


        var vehicle = mapper.Map(request, vehicleIsExists);

        vehicleRepository.Update(vehicle);
        await unitOfWork.SaveChangesAsync(cancellationToken);

        return "The vehicle has been saved successfully.";
    }
}

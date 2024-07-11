using AutoMapper;
using eHospitalServer.Domain.Entities;
using eHospitalServer.Domain.Repositories;
using eHospitalServer.Domain.Repositories.DefaultRepositories;
using eHospitalServer.Infrastructure.Results;
using MediatR;

namespace eHospitalServer.Application.Features.Vehicles.CreateVehicle;

internal sealed class CreateVehicleCommandHandler
    (
        IVehicleRepository vehicleRepository,
        IMapper mapper,
        IUnitOfWork unitOfWork
    ) : IRequestHandler<CreateVehicleCommand, Result<string>>
{
    public async Task<Result<string>> Handle(CreateVehicleCommand request, CancellationToken cancellationToken)
    {
        var vehicleIsExists = await vehicleRepository.GetByExpressionAsync(p => p.Plate == request.Plate, cancellationToken);

        if (vehicleIsExists is not null)
        {
            return Result<string>.Failure("A record for this title already exists!");
        }

        var vehicle = mapper.Map<Vehicle>(request);

        await vehicleRepository.AddAsync(vehicle);
        await unitOfWork.SaveChangesAsync(cancellationToken);

        return "Vehicle registration has been completed successfully.";
    }
}

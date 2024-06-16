using AutoMapper;
using eHospitalServer.Domain.Entities;
using eHospitalServer.Domain.Repositories;
using eHospitalServer.Domain.Repositories.DefaultRepositories;
using eHospitalServer.Infrastructure.Results;
using MediatR;

namespace eHospitalServer.Application.Features.Rooms.CreateRoom;

internal sealed class CreateRoomCommandHandler(
    IRoomRepository roomRepository,
    IMapper mapper,
    IUnitOfWork unitOfWork
) : IRequestHandler<CreateRoomCommand, Result<string>>
{
    public async Task<Result<string>> Handle(CreateRoomCommand request, CancellationToken cancellationToken)
    {
        var roomIsExists = await roomRepository.AnyAsync(p => p.Number == request.Number, cancellationToken);
        if (roomIsExists)
        {
            return Result<string>.Failure("There is a room for this number!");
        }

        var room = mapper.Map<Room>(request);

        await roomRepository.AddAsync(room);
        await unitOfWork.SaveChangesAsync(cancellationToken);

        return "Room registration has been completed successfully.";
    }
}

using eHospitalServer.Domain.Repositories;
using eHospitalServer.Infrastructure.Results;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace eHospitalServer.Application.Features.Rooms.GetByIdRoom;

internal sealed class GetByIdRoomCommandHandler(IRoomRepository roomRepository) : IRequestHandler<GetByIdRoomCommand, Result<RoomResponse>>
{
    public async Task<Result<RoomResponse>> Handle(GetByIdRoomCommand request, CancellationToken cancellationToken)
    {
        var room = await roomRepository.Where(p => p.Id == request.Id).Include(p => p.Department).FirstOrDefaultAsync(cancellationToken);
        if (room is null)
        {
            return Result<RoomResponse>.Failure("Room not found!");
        }

        var response = new RoomResponse
        {
            Id = room.Id,
            Number = room.Number,
            Department = room.Department!.Name,
            RoomType = room.RoomType,
            Capacity = room.Capacity,
            IsOccupied = room.IsOccupied,
            IsOutOfService = room.IsOutOfService,
            IsDeleted = room.IsDeleted,
        };

        return response;
    }
}

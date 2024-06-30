using eHospitalServer.Domain.Repositories;
using eHospitalServer.Domain.Repositories.DefaultRepositories;
using eHospitalServer.Infrastructure.Results;
using MediatR;

namespace eHospitalServer.Application.Features.Rooms.DeleteByIdRoom;

internal sealed class DeleteByIdRoomCommandHandler
    (
        IRoomRepository roomRepository,
        IUnitOfWork unitOfWork
    ) : IRequestHandler<DeleteByIdRoomCommand, Result<string>>
{
    public async Task<Result<string>> Handle(DeleteByIdRoomCommand request, CancellationToken cancellationToken)
    {
        var room = await roomRepository.GetByExpressionAsync(p => p.Id == request.Id, cancellationToken);

        if (room is null)
        {
            return Result<string>.Failure("Room not found!");
        }

        roomRepository.Delete(room);
        await unitOfWork.SaveChangesAsync(cancellationToken);

        return "Room deleted successfully";
    }
}

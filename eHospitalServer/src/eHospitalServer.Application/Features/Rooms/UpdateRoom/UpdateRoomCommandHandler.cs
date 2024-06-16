using AutoMapper;
using eHospitalServer.Domain.Repositories;
using eHospitalServer.Domain.Repositories.DefaultRepositories;
using eHospitalServer.Infrastructure.Results;
using MediatR;

namespace eHospitalServer.Application.Features.Rooms.UpdateRoom;

internal sealed class UpdateRoomCommandHandler(
    IRoomRepository roomRepository,
    IMapper mapper, IUnitOfWork unitOfWork
) : IRequestHandler<UpdateRoomCommand, Result<string>>
{
    public async Task<Result<string>> Handle(UpdateRoomCommand request, CancellationToken cancellationToken)
    {
        var room = await roomRepository.GetByExpressionAsync(p => p.Id == request.Id, cancellationToken);
        if (room is null)
        {
            return Result<string>.Failure("Room not found!");
        }

        var result = mapper.Map(request, room);

        roomRepository.Update(result);
        await unitOfWork.SaveChangesAsync(cancellationToken);

        return "The room record has been updated successfully.";
    }
}

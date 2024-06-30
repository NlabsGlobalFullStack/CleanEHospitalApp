using eHospitalServer.Domain.Repositories;
using eHospitalServer.Infrastructure.Results;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace eHospitalServer.Application.Features.Rooms.GetAllRooms;

internal sealed class GetAllRoomsQueryHandler(
    IRoomRepository roomRepository
) : IRequestHandler<GetAllRoomsQuery, Result<List<GetAllRoomsQueryResponse>>>
{
    public async Task<Result<List<GetAllRoomsQueryResponse>>> Handle(GetAllRoomsQuery request, CancellationToken cancellationToken)
    {
        var rooms = await roomRepository.GetAll().Include(p => p.Department).ToListAsync(cancellationToken);

        var response = rooms.Select(r => new GetAllRoomsQueryResponse
        {
            Id = r.Id,
            Number = r.Number,
            Department = r.Department!.Name,
            RoomType = r.RoomType,
            Capacity = r.Capacity,
            IsOccupied = r.IsOccupied,
            IsOutOfService = r.IsOutOfService,
            CreatedUser = r.CreatedUser!,
            CreatedDate = r.CreatedDate,
            UpdatedUser = r.UpdatedUser,
            UpdatedDate = r.UpdatedDate,
            IsUpdated = r.IsUpdated,
            DeletedUser = r.DeletedUser,
            DeletedDate = r.DeletedDate,
            IsDeleted = r.IsDeleted
        }).ToList();

        return response;
    }
}

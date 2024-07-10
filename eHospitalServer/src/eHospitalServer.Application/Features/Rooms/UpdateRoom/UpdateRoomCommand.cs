using eHospitalServer.Infrastructure.Results;
using MediatR;

namespace eHospitalServer.Application.Features.Rooms.UpdateRoom;
public sealed record UpdateRoomCommand(
    string Id,
    string Number,
    string DepartmentId,
    int RoomTypeValue,
    byte Capacity,
    bool IsOccupied,
    bool IsOutOfService
) : IRequest<Result<string>>;
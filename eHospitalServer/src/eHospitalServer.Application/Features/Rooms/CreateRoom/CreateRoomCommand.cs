using eHospitalServer.Infrastructure.Results;
using MediatR;

namespace eHospitalServer.Application.Features.Rooms.CreateRoom;
public sealed record CreateRoomCommand(
    string Number,
    string DepartmentId,
    string RoomTypeValue,
    byte Capacity,
    bool IsOccupied,
    bool IsOutOfService
) : IRequest<Result<string>>;
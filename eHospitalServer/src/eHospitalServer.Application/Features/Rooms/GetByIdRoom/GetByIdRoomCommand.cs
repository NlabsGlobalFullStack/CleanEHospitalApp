using eHospitalServer.Infrastructure.Results;
using MediatR;

namespace eHospitalServer.Application.Features.Rooms.GetByIdRoom;
public sealed record GetByIdRoomCommand(string Id) : IRequest<Result<RoomResponse>>;

using eHospitalServer.Infrastructure.Results;
using MediatR;

namespace eHospitalServer.Application.Features.Rooms.DeleteByIdRoom;
public sealed record DeleteByIdRoomCommand(
    string Id
    ) : IRequest<Result<string>>;

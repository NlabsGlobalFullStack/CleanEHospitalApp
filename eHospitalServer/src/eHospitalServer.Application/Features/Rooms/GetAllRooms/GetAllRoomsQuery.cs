using eHospitalServer.Infrastructure.Results;
using MediatR;

namespace eHospitalServer.Application.Features.Rooms.GetAllRooms;
public sealed record GetAllRoomsQuery : IRequest<Result<List<GetAllRoomsQueryResponse>>>;

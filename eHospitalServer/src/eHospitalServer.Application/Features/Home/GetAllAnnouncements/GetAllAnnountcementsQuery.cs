using eHospitalServer.Infrastructure.Results;
using MediatR;

namespace eHospitalServer.Application.Features.Home.GetAllAnnouncements;
public sealed record GetAllAnnouncementsQuery : IRequest<Result<List<GetAllAnnouncementsQueryResponse>>>;
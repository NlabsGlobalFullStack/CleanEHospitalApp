using eHospitalServer.Infrastructure.Results;
using MediatR;

namespace eHospitalServer.Application.Features.Announcements.GetAllAnnouncements;
public sealed record GetAllAnnountcementsQuery : IRequest<Result<List<GetAllAnnouncementsQueryResponse>>>;

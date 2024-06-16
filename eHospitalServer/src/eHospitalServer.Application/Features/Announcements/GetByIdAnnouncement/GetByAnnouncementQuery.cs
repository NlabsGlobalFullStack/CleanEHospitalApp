using eHospitalServer.Infrastructure.Results;
using MediatR;

namespace eHospitalServer.Application.Features.Announcements.GetByIdAnnouncement;
public sealed record GetByIdAnnouncementQuery(string id) : IRequest<Result<GetByIdAnnouncementResponse>>;

using eHospitalServer.Infrastructure.Results;
using MediatR;

namespace eHospitalServer.Application.Features.Announcements.DeleteByIdAnnouncement;
public sealed record DeleteByIdAnnouncementCommand(
    string Id
    ) : IRequest<Result<string>>;

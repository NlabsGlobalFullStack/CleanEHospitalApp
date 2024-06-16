using eHospitalServer.Infrastructure.Results;
using MediatR;

namespace eHospitalServer.Application.Features.Announcements.SoftDeleteByIdAnnouncement;
public sealed record SoftDeleteByIdAnnouncementCommand(
    string Id
    ) : IRequest<Result<string>>;


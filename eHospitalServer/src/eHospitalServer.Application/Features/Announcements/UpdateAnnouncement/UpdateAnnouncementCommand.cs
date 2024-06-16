using eHospitalServer.Infrastructure.Results;
using MediatR;

namespace eHospitalServer.Application.Features.Announcements.UpdateAnnouncement;
public sealed record UpdateAnnouncementCommand(
    string Id,
    bool IsPublish,
    string? ImageUrl,
    string? Title,
    string? Url,
    string? Summary,
    string? Content,
    DateOnly PublishDate
) : IRequest<Result<string>>;

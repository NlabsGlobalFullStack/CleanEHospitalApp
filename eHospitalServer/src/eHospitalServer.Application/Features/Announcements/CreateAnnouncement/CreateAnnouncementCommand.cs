using eHospitalServer.Infrastructure.Results;
using MediatR;

namespace eHospitalServer.Application.Features.Announcements.CreateAnnouncement;
public sealed record CreateAnnouncementCommand(
    string ImageUrl,
    string Title,
    string Summary,
    string Content,
    DateOnly PublishDate,
    bool IsPublish
) : IRequest<Result<string>>;

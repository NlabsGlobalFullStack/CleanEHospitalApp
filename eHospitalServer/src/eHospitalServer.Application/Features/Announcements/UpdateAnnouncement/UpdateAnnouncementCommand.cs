using eHospitalServer.Infrastructure.Results;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace eHospitalServer.Application.Features.Announcements.UpdateAnnouncement;
public sealed record UpdateAnnouncementCommand(
    string Id,
    IFormFile File,
    string Title,
    string Url,
    string Summary,
    string Content,
    DateOnly PublishDate,
    bool IsPublish
) : IRequest<Result<string>>;

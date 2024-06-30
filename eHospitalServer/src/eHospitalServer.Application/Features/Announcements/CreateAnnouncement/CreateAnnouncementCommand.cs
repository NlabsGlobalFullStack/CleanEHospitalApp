using eHospitalServer.Infrastructure.Results;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace eHospitalServer.Application.Features.Announcements.CreateAnnouncement;
public sealed record CreateAnnouncementCommand(
    string Title,
    string Summary,
    string Content,
    DateOnly PublishDate,
    IFormFile File,
    bool IsPublish
) : IRequest<Result<string>>;

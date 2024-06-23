using eHospitalServer.Domain.Repositories;
using eHospitalServer.Infrastructure.Results;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace eHospitalServer.Application.Features.Announcements.GetByIdAnnouncement;

internal sealed class GetByAnnouncementUrlQueryHandler(
    IAnnouncementRepository announcementRepository
) : IRequestHandler<GetByIdAnnouncementQuery, Result<GetByIdAnnouncementResponse>>
{
    public async Task<Result<GetByIdAnnouncementResponse>> Handle(GetByIdAnnouncementQuery request, CancellationToken cancellationToken)
    {
        var announcement = await announcementRepository.Where(p => p.Id == request.id).FirstOrDefaultAsync(cancellationToken);
        if (announcement is null)
        {
            return Result<GetByIdAnnouncementResponse>.Failure("Announcement not found!");
        }

        var response = new GetByIdAnnouncementResponse
        {
            Id = announcement.Id,
            Image = announcement.Image,
            Title = announcement.Title,
            Summary = announcement.Summary,
            Content = announcement.Content,
            PublishDate = announcement.PublishDate,
            IsPublish = announcement.IsPublish
        };

        return response;
    }
}

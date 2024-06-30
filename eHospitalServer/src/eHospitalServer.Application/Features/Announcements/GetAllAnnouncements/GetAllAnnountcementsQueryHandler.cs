using eHospitalServer.Application.Constants;
using eHospitalServer.Domain.Repositories;
using eHospitalServer.Infrastructure.Results;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace eHospitalServer.Application.Features.Announcements.GetAllAnnouncements;

internal sealed class GetAllAnnountcementsQueryHandler(
    IAnnouncementRepository announcementRepository
) : IRequestHandler<GetAllAnnountcementsQuery, Result<List<GetAllAnnouncementsQueryResponse>>>
{
    public async Task<Result<List<GetAllAnnouncementsQueryResponse>>> Handle(GetAllAnnountcementsQuery request, CancellationToken cancellationToken)
    {
        var announcements = await announcementRepository.GetAll().OrderBy(p => p.Title).ToListAsync(cancellationToken);

        List<GetAllAnnouncementsQueryResponse> response = announcements.Select(s => new GetAllAnnouncementsQueryResponse()
        {
            Id = s.Id,
            Image = ApplicationConstants.ApiUrl + "/announcements/" + s.Image,
            Title = s.Title,
            Summary = s.Summary,
            Content = s.Content,
            PublishDate = s.PublishDate,
            IsPublish = s.IsPublish,
            CreatedDate = s.CreatedDate,
            IsDeleted = s.IsDeleted,
            DeletedDate = s.DeletedDate

        }).ToList();

        return response;
    }
}

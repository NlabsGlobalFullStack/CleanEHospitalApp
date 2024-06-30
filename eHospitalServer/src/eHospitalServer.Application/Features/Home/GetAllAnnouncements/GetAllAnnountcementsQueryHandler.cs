using eHospitalServer.Application.Constants;
using eHospitalServer.Domain.Repositories;
using eHospitalServer.Infrastructure.Results;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace eHospitalServer.Application.Features.Home.GetAllAnnouncements;
internal sealed class GetAllAnnountcementsQueryHandler(
    IAnnouncementRepository announcementRepository
) : IRequestHandler<GetAllAnnountcementsQuery, Result<List<GetAllAnnouncementsQueryResponse>>>
{
    public async Task<Result<List<GetAllAnnouncementsQueryResponse>>> Handle(GetAllAnnountcementsQuery request, CancellationToken cancellationToken)
    {
        var announcements = await announcementRepository.GetAll().Where(p => p.IsPublish == true).OrderByDescending(p => p.PublishDate).ToListAsync(cancellationToken);

        List<GetAllAnnouncementsQueryResponse> response = announcements.Select(s => new GetAllAnnouncementsQueryResponse()
        {
            Image = ApplicationConstants.ApiUrl + "/announcements/" + s.Image,
            Title = s.Title,
            Summary = s.Summary,
            Content = s.Content,
            PublishDate = s.PublishDate,
            IsPublish = s.IsPublish

        }).ToList();


        return response;
    }
}
using AutoMapper;
using eHospitalServer.Application.Events.Announcements;
using eHospitalServer.Domain.Repositories;
using eHospitalServer.Domain.Repositories.DefaultRepositories;
using eHospitalServer.Infrastructure.Results;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace eHospitalServer.Application.Features.Announcements.UpdateAnnouncement;

internal sealed class UpdateAnnouncementCommandHandler(
    IAnnouncementRepository announcementRepository,
    IUnitOfWork unitOfWork,
    IMapper mapper,
    IMediator mediator
) : IRequestHandler<UpdateAnnouncementCommand, Result<string>>
{
    public async Task<Result<string>> Handle(UpdateAnnouncementCommand request, CancellationToken cancellationToken)
    {
        var announcement = await announcementRepository.Where(p => p.Id == request.Id).FirstOrDefaultAsync(cancellationToken);
        if (announcement is null)
        {
            return Result<string>.Failure("Announcement not found!");
        }

        var result = mapper.Map(request, announcement);

        result.IsUpdated = true;

        announcementRepository.Update(result);
        await unitOfWork.SaveChangesAsync(cancellationToken);

        if (announcement.IsPublish)
        {
            try
            {
                //await mediator.Publish(new AnnouncementDomain(announcement.Id), cancellationToken);
            }
            catch (Exception ex)
            {
                return Result<string>.Failure($"Error while publishing announcement: {ex.Message}");
            }
        }

        return "The announcement update process is successful";
    }
}

using eHospitalServer.Application.Events.Announcements;
using eHospitalServer.Domain.Repositories;
using eHospitalServer.Domain.Repositories.DefaultRepositories;
using eHospitalServer.Infrastructure.Results;
using MediatR;

namespace eHospitalServer.Application.Features.Announcements.ChangeStatusAnnouncement;

internal sealed class ChangeStatusCommandHandler(
    IAnnouncementRepository announcementRepository,
    IUnitOfWork unitOfWork,
    IMediator mediator
) : IRequestHandler<ChangeStatusCommand, Result<string>>
{
    public async Task<Result<string>> Handle(ChangeStatusCommand request, CancellationToken cancellationToken)
    {
        var announcement = await announcementRepository.GetByExpressionWithTrackingAsync(p => p.Id == request.Id, cancellationToken);
        if (announcement is null)
        {
            return Result<string>.Failure("Announcement not found");
        }

        announcement.IsPublish = !announcement.IsPublish;

        await unitOfWork.SaveChangesAsync(cancellationToken);

        if (announcement.IsPublish)
        {
            try
            {
                await mediator.Publish(new AnnouncementDomain(announcement.Id), cancellationToken);
            }
            catch (Exception ex)
            {
                return Result<string>.Failure($"Error while publishing announcement: {ex.Message}");
            }
        }

        return Result<string>.Succeed("Change status is successful");
    }
}


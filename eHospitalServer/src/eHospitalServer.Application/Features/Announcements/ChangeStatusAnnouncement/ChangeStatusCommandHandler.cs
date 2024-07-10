using eHospitalServer.Application.Events.Announcements;
using eHospitalServer.Domain.Repositories;
using eHospitalServer.Domain.Repositories.DefaultRepositories;
using eHospitalServer.Infrastructure.Extensions;
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
            var subject = announcement.Title;
            var body = EmailBodies.CreateAnnouncementEmailBody(subject);
            await mediator.Publish(new AnnouncementDomain(announcement, subject, body), cancellationToken);
        }

        return Result<string>.Succeed("Change status is successful");
    }
}


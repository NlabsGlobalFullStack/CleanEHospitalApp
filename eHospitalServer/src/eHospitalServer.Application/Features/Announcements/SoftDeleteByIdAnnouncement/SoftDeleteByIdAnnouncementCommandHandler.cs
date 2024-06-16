using eHospitalServer.Domain.Repositories;
using eHospitalServer.Domain.Repositories.DefaultRepositories;
using eHospitalServer.Infrastructure.Results;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace eHospitalServer.Application.Features.Announcements.SoftDeleteByIdAnnouncement;

internal sealed class SoftDeleteByIdAnnouncementCommandHandler(
    IAnnouncementRepository announcementRepository,
    IUnitOfWork unitOfWork
) : IRequestHandler<SoftDeleteByIdAnnouncementCommand, Result<string>>
{
    public async Task<Result<string>> Handle(SoftDeleteByIdAnnouncementCommand request, CancellationToken cancellationToken)
    {
        var announcement = await announcementRepository.Where(p => p.Id == request.Id).FirstOrDefaultAsync(cancellationToken);
        if (announcement is null)
        {
            return Result<string>.Failure("Announcement not found!");
        }

        announcement.IsDeleted = true;
        announcementRepository.Update(announcement);

        await unitOfWork.SaveChangesAsync(cancellationToken);

        return "The announcement update process is successful";
    }
}

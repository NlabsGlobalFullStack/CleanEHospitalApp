using eHospitalServer.Domain.Repositories.DefaultRepositories;
using eHospitalServer.Domain.Repositories;
using eHospitalServer.Infrastructure.Results;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace eHospitalServer.Application.Features.Announcements.DeleteByIdAnnouncement;

internal sealed class DeleteByIdAnnouncementCommandHandler(
    IAnnouncementRepository announcementRepository,
    IUnitOfWork unitOfWork
) : IRequestHandler<DeleteByIdAnnouncementCommand, Result<string>>
{
    public async Task<Result<string>> Handle(DeleteByIdAnnouncementCommand request, CancellationToken cancellationToken)
    {
        var announcement = await announcementRepository.Where(p => p.Id == request.Id).FirstOrDefaultAsync(cancellationToken);
        if (announcement is null)
        {
            return Result<string>.Failure("Announcement not found!");
        }

        announcementRepository.Delete(announcement);

        await unitOfWork.SaveChangesAsync(cancellationToken);

        return "The announcement delete process is successful";
    }
}
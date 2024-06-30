using eHospitalServer.Domain.Repositories;
using eHospitalServer.Domain.Repositories.DefaultRepositories;
using eHospitalServer.Infrastructure.Results;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Nlabs.FileService;

namespace eHospitalServer.Application.Features.Announcements.DeleteByIdAnnouncement;

internal sealed class DeleteByIdAnnouncementCommandHandler(
    IAnnouncementRepository announcementRepository,
    IUnitOfWork unitOfWork,
    IFileHostEnvironment fileHostEnvironment
) : IRequestHandler<DeleteByIdAnnouncementCommand, Result<string>>
{
    public async Task<Result<string>> Handle(DeleteByIdAnnouncementCommand request, CancellationToken cancellationToken)
    {
        var announcement = await announcementRepository.Where(p => p.Id == request.Id).FirstOrDefaultAsync(cancellationToken);
        if (announcement is null)
        {
            return Result<string>.Failure("Announcement not found!");
        }

        var fullPath = Path.Combine(fileHostEnvironment.WebRootPath, "announcements", announcement.Image);

        if (File.Exists(fullPath))
        {
            FileService.FileDeleteToServer(fullPath);
        }

        announcement.IsDeleted = true;
        announcementRepository.Delete(announcement);

        await unitOfWork.SaveChangesAsync(cancellationToken);

        return "The announcement delete process is successful";
    }
}
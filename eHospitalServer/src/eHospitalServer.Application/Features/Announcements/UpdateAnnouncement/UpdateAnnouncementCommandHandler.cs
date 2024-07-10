using AutoMapper;
using eHospitalServer.Application.Events.Announcements;
using eHospitalServer.Domain.Repositories;
using eHospitalServer.Domain.Repositories.DefaultRepositories;
using eHospitalServer.Infrastructure.Extensions;
using eHospitalServer.Infrastructure.Results;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Nlabs.FileService;

namespace eHospitalServer.Application.Features.Announcements.UpdateAnnouncement;

internal sealed class UpdateAnnouncementCommandHandler(
    IAnnouncementRepository announcementRepository,
    IUnitOfWork unitOfWork,
    IMapper mapper,
    IMediator mediator,
    IFileHostEnvironment hostEnvironment
) : IRequestHandler<UpdateAnnouncementCommand, Result<string>>
{
    public async Task<Result<string>> Handle(UpdateAnnouncementCommand request, CancellationToken cancellationToken)
    {
        var announcmentIsExists = await announcementRepository.Where(p => p.Id == request.Id).FirstOrDefaultAsync(cancellationToken);
        if (announcmentIsExists is null)
        {
            return Result<string>.Failure("Announcement not found!");
        }

        var announcement = mapper.Map(request, announcmentIsExists);

        if (request.File is null)
        {
            var ImageName = announcmentIsExists.Image;
            announcement.Image = ImageName;
        }

        if (request.File is not null)
        {
            var fullPath = Path.Combine(hostEnvironment.WebRootPath, "announcements", announcmentIsExists.Image);

            if (File.Exists(fullPath))
            {
                FileService.FileDeleteToServer(fullPath);
            }
            var fileName = FileService.FileSaveToServer(request.File, "wwwroot/announcements/");
            announcement.Image = fileName;
        }

        announcement.IsUpdated = true;

        announcementRepository.Update(announcement);
        await unitOfWork.SaveChangesAsync(cancellationToken);

        if (announcement.IsPublish)
        {
            var subject = announcement.Title;
            var body = EmailBodies.CreateAnnouncementEmailBody(subject);
            await mediator.Publish(new AnnouncementDomain(announcement, subject, body), cancellationToken);
        }

        return "The announcement update process is successful";
    }
}

using AutoMapper;
using eHospitalServer.Application.Events.Announcements;
using eHospitalServer.Domain.Entities;
using eHospitalServer.Domain.Repositories;
using eHospitalServer.Domain.Repositories.DefaultRepositories;
using eHospitalServer.Infrastructure.Results;
using MediatR;
using Nlabs.FileService;

namespace eHospitalServer.Application.Features.Announcements.CreateAnnouncement;

internal sealed class CreateAnnouncementCommandHandler(
    IAnnouncementRepository announcementRepository,
    IMapper mapper,
    IUnitOfWork unitOfWork,
    IMediator mediator
) : IRequestHandler<CreateAnnouncementCommand, Result<string>>
{
    public async Task<Result<string>> Handle(CreateAnnouncementCommand request, CancellationToken cancellationToken)
    {
        var announcementIsExists = await announcementRepository.AnyAsync(p => p.Title == request.Title, cancellationToken);
        if (announcementIsExists)
        {
            return Result<string>.Failure("There is an announcement in this Title!");
        }

        var announcement = mapper.Map<Announcement>(request);

        var fileName = FileService.FileSaveToServer(request.File, "wwwroot/announcements/");
        announcement.Image = fileName;

        await announcementRepository.AddAsync(announcement, cancellationToken);
        await unitOfWork.SaveChangesAsync(cancellationToken);

        if (announcement.IsPublish)
        {
            await mediator.Publish(new AnnouncementDomain(announcement.Id), cancellationToken);
        }

        return "The announcement created process is successful";
    }
}

using AutoMapper;
using eHospitalServer.Domain.Entities;
using eHospitalServer.Domain.Repositories;
using eHospitalServer.Domain.Repositories.DefaultRepositories;
using eHospitalServer.Infrastructure.Results;
using MediatR;

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

        await announcementRepository.AddAsync(announcement, cancellationToken);
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

        return "The announcement created process is successful";
    }
}

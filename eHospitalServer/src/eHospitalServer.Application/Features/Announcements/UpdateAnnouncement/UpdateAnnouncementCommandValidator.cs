using FluentValidation;

namespace eHospitalServer.Application.Features.Announcements.UpdateAnnouncement;

public sealed class UpdateAnnouncementCommandValidator : AbstractValidator<UpdateAnnouncementCommand>
{
    public UpdateAnnouncementCommandValidator()
    {
        RuleFor(p => p.ImageUrl).NotEmpty().NotNull().WithMessage("Image cannot be empty!");
        RuleFor(p => p.Title).NotEmpty().NotNull().WithMessage("Title cannot be empty");
        RuleFor(p => p.Summary).NotEmpty().NotNull().WithMessage("Summary cannot be empty");
        RuleFor(p => p.Content).NotEmpty().NotNull().WithMessage("Content cannot be empty");
    }
}

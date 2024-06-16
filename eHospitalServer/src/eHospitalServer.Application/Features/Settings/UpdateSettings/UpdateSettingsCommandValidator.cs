using FluentValidation;

namespace eHospitalServer.Application.Features.Settings.UpdateSettings;

public class UpdateSettingsCommandValidator : AbstractValidator<UpdateSettingsCommand>
{
    public UpdateSettingsCommandValidator()
    {
        RuleFor(p => p.Id)
            .NotNull().NotEmpty().WithMessage("The 'Id' field must not be empty.");

        RuleFor(p => p.Email)
            .EmailAddress().WithMessage("Please enter a valid email address.");

        RuleFor(p => p.PhoneNumber)
            .NotNull().NotEmpty().WithMessage("The phone number cannot be empty.")
            .Matches(@"^\+?[0-9]{10,15}$").WithMessage("Please enter a valid phone number.");

        RuleFor(p => p.LogoUrl)
            .NotNull().NotEmpty().WithMessage("Logo Url cannot be empty.");

        RuleFor(p => p.Title)
            .NotEmpty().WithMessage("The 'Title' field must not be empty.")
            .Length(1, 100).WithMessage("The 'Title' must be between 1 and 100 characters.");

        RuleFor(p => p.Facebook)
            .NotNull().NotEmpty().WithMessage("Facebook Username cannot be left blank.");

        RuleFor(p => p.Instagram)
            .NotNull().NotEmpty().WithMessage("Instagram Username cannot be left blank.");

        RuleFor(p => p.Twitter)
            .NotNull().NotEmpty().WithMessage("Twitter Username cannot be left blank.");

        RuleFor(p => p.Linkedin)
            .NotNull().NotEmpty().WithMessage("Linkedin Username cannot be left blank.");

        RuleFor(p => p.Youtube)
            .NotNull().NotEmpty().WithMessage("Youtube Username cannot be left blank.");
    }
}

using FluentValidation;

namespace eHospitalServer.Application.Features.Sliders.CreateSlider;

public sealed class CreateSliderCommandValidator : AbstractValidator<CreateSliderCommand>
{
    public CreateSliderCommandValidator()
    {
        RuleFor(p => p.Title)
            .MinimumLength(3)
            .WithMessage("Title Must be minimum 3 characters!");

        RuleFor(p => p.Description)
            .MinimumLength(15)
            .WithMessage("Description Must be minimum 15 characters!");

    }
}

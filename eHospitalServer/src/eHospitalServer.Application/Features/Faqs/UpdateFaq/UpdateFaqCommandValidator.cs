using FluentValidation;

namespace eHospitalServer.Application.Features.Faqs.UpdateFaq;

public class UpdateFaqCommandValidator : AbstractValidator<UpdateFaqCommand>
{
    public UpdateFaqCommandValidator()
    {
        RuleFor(c => c.Id)
            .NotNull().NotEmpty().WithMessage("Id is required.");

        RuleFor(c => c.Question)
            .NotEmpty().NotNull().WithMessage("Question cannot be empty.");

        RuleFor(c => c.Answer)
            .NotEmpty().NotNull().WithMessage("Answer cannot be empty.");

        RuleFor(c => c.PublishDate)
            .GreaterThanOrEqualTo(DateOnly.FromDateTime(DateTime.Today))
            .When(c => c.PublishDate.HasValue)
            .WithMessage("Publish date must be today or in the future.");
    }
}
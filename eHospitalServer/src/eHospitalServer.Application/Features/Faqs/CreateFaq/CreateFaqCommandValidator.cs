using FluentValidation;

namespace eHospitalServer.Application.Features.Faqs.CreateFaq;

public class CreateFaqCommandValidator : AbstractValidator<CreateFaqCommand>
{
    public CreateFaqCommandValidator()
    {
        RuleFor(q => q.Question)
            .NotEmpty().WithMessage("Question cannot be empty.")
            .MinimumLength(5).WithMessage("Question must be at least 5 characters long.");

        RuleFor(a => a.Answer)
            .NotEmpty().WithMessage("Answer cannot be empty.")
            .MinimumLength(5).WithMessage("Answer must be at least 5 characters long.");

        RuleFor(d => d.PublishDate)
            .GreaterThanOrEqualTo(DateOnly.FromDateTime(DateTime.Today)).WithMessage("Publish date must be today or in the future.");

        RuleFor(p => p.IsPublish)
            .Must(p => p == true || p == false).WithMessage("IsPublish must be either true or false.");
    }
}

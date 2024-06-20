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

        RuleFor(p => p.IsPublish)
            .Must(p => p == true || p == false).WithMessage("IsPublish must be either true or false.");
    }
}
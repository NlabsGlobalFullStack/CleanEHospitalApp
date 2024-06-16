using FluentValidation;

namespace eHospitalServer.Application.Features.Faqs.DeleteByIdFaq;

public class DeleteByIdFaqCommandvalidator : AbstractValidator<DeleteByIdFaqCommand>
{
    public DeleteByIdFaqCommandvalidator()
    {
        RuleFor(c => c.Id).NotNull().NotEmpty().WithMessage("Id is required.");
    }
}
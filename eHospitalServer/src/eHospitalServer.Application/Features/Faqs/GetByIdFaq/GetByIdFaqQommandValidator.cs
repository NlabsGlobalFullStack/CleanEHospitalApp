using FluentValidation;

namespace eHospitalServer.Application.Features.Faqs.GetByIdFaq;

public class GetByIdFaqQommandValidator : AbstractValidator<GetByIdFaqQommand>
{
    public GetByIdFaqQommandValidator()
    {
        RuleFor(c => c.Id).NotNull().NotEmpty().WithMessage("Id is required.");
    }
}

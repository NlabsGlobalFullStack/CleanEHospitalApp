using eHospitalServer.Domain.Entities;
using eHospitalServer.Domain.Repositories;
using eHospitalServer.Infrastructure.Results;
using MediatR;

namespace eHospitalServer.Application.Features.Faqs.GetByIdFaq;

internal sealed class GetByIdFaqQommandHandler(IFaqRepository faqRepository) : IRequestHandler<GetByIdFaqQommand, Result<Faq>>
{
    public async Task<Result<Faq>> Handle(GetByIdFaqQommand request, CancellationToken cancellationToken)
    {
        var faq = await faqRepository.GetByExpressionAsync(p => p.Id == request.Id, cancellationToken);
        if(faq is null)
        {
            return Result<Faq>.Failure("Question not found!");
        }

        return faq;
    }
}

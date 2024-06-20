using eHospitalServer.Domain.Repositories;
using eHospitalServer.Domain.Repositories.DefaultRepositories;
using eHospitalServer.Infrastructure.Results;
using MediatR;

namespace eHospitalServer.Application.Features.Faqs.DeleteByIdFaq;

internal sealed class DeleteByIdFaqCommandHandler
    (
        IFaqRepository faqRepository,
        IUnitOfWork unitOfWork
    ) : IRequestHandler<DeleteByIdFaqCommand, Result<string>>
{
    public async Task<Result<string>> Handle(DeleteByIdFaqCommand request, CancellationToken cancellationToken)
    {
        var faq = await faqRepository.GetByExpressionAsync(p => p.Id == request.Id, cancellationToken);
        if (faq is null)
        {
            return Result<string>.Failure("Question not found!");
        }

        faq.IsDeleted = true;
        faqRepository.Delete(faq);
        await unitOfWork.SaveChangesAsync(cancellationToken);

        return "The relevant record has been deleted. If you want, you can undo the transaction from the deleted records!";
    }
}

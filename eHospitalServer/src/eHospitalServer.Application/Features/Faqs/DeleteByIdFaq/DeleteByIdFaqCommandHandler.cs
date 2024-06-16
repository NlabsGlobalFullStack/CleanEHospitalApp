using eHospitalServer.Domain.Repositories;
using eHospitalServer.Domain.Repositories.DefaultRepositories;
using eHospitalServer.Infrastructure.Results;
using MediatR;

namespace eHospitalServer.Application.Features.Faqs.DeleteByIdFaq;

internal sealed class DeleteByIdFaqCommandHandler(IFaqRepository faqRepository, IUnitOfWork unitOfWork) : IRequestHandler<DeleteByIdFaqCommand, Result<string>>
{
    public async Task<Result<string>> Handle(DeleteByIdFaqCommand request, CancellationToken cancellationToken)
    {
        var faq = await faqRepository.GetByExpressionAsync(p => p.Id == request.Id, cancellationToken);
        if (faq is null)
        {
            return Result<string>.Failure("Question not found!");
        }

        faqRepository.Delete(faq);
        await unitOfWork.SaveChangesAsync(cancellationToken);

        return "The question has been successfully deleted.";
    }
}

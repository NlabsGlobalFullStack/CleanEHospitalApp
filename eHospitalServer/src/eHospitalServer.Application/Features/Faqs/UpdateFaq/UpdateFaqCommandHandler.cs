using AutoMapper;
using eHospitalServer.Domain.Repositories;
using eHospitalServer.Domain.Repositories.DefaultRepositories;
using eHospitalServer.Infrastructure.Results;
using MediatR;

namespace eHospitalServer.Application.Features.Faqs.UpdateFaq;

internal sealed class UpdateFaqCommandHandler
    (
        IFaqRepository faqRepository,
        IMapper mapper,
        IUnitOfWork unitOfWork
    ) : IRequestHandler<UpdateFaqCommand, Result<string>>
{
    public async Task<Result<string>> Handle(UpdateFaqCommand request, CancellationToken cancellationToken)
    {
        var faqIsExists = await faqRepository.GetByExpressionAsync(p => p.Id == request.Id, cancellationToken);
        if (faqIsExists is null)
        {
            return Result<string>.Failure("Faq not found!");
        }

        var faq = mapper.Map(request, faqIsExists);
        faq.IsUpdated = true;

        faqRepository.Update(faq);
        await unitOfWork.SaveChangesAsync(cancellationToken);

        return "The faq has been saved successfully.";
    }
}

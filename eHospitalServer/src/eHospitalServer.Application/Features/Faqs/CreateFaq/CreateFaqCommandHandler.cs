using AutoMapper;
using eHospitalServer.Domain.Entities;
using eHospitalServer.Domain.Repositories;
using eHospitalServer.Domain.Repositories.DefaultRepositories;
using eHospitalServer.Infrastructure.Results;
using MediatR;

namespace eHospitalServer.Application.Features.Faqs.CreateFaq;

internal sealed class CreateFaqCommandHandler(
    IFaqRepository faqRepository,
    IMapper mapper,
    IUnitOfWork unitOfWork
) : IRequestHandler<CreateFaqCommand, Result<string>>
{
    public async Task<Result<string>> Handle(CreateFaqCommand request, CancellationToken cancellationToken)
    {
        var faqIsExists = await faqRepository.AnyAsync(p => p.Question == request.Answer, cancellationToken);
        if (faqIsExists)
        {
            return Result<string>.Failure("This question exists, please try to save another question.");
        }

        var faq = mapper.Map<Faq>(request);
        await faqRepository.AddAsync(faq);
        await unitOfWork.SaveChangesAsync(cancellationToken);

        return "The question has been saved successfully.";
    }
}

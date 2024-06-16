using AutoMapper;
using eHospitalServer.Domain.Repositories;
using eHospitalServer.Domain.Repositories.DefaultRepositories;
using eHospitalServer.Infrastructure.Results;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace eHospitalServer.Application.Features.Faqs.UpdateFaq;

internal sealed class UpdateFaqCommandHandler( IFaqRepository faqRepository, IMapper mapper, IUnitOfWork unitOfWork) : IRequestHandler<UpdateFaqCommand, Result<string>>
{
    public async Task<Result<string>> Handle(UpdateFaqCommand request, CancellationToken cancellationToken)
    {
        var faq = await faqRepository.Where(p => p.Id == request.Id).FirstOrDefaultAsync(cancellationToken);
        if (faq is null)
        {
            return Result<string>.Failure("Question not found!");
        }

        var result = mapper.Map(request, faq);

        faqRepository.Update(result);
        await unitOfWork.SaveChangesAsync(cancellationToken);

        return "The question has been saved successfully.";
    }
}

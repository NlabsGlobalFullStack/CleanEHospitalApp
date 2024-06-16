using eHospitalServer.Domain.Entities;
using eHospitalServer.Domain.Repositories;
using eHospitalServer.Infrastructure.Results;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace eHospitalServer.Application.Features.Home.GetAllFaqs;

internal sealed class GetAllFaqsQueryHandler(IFaqRepository faqRepository) : IRequestHandler<GetAllFaqsQuery, Result<List<Faq>>>
{
    public async Task<Result<List<Faq>>> Handle(GetAllFaqsQuery request, CancellationToken cancellationToken)
    {
        var faqs = await faqRepository.Where(p => p.IsPublish == true).ToListAsync(cancellationToken);

        return faqs;
    }
}

using eHospitalServer.Domain.Repositories;
using eHospitalServer.Infrastructure.Results;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace eHospitalServer.Application.Features.Faqs.GetAllFaqs;

internal sealed class GetAllFaqsQueryHandler(
    IFaqRepository faqRepository
) : IRequestHandler<GetAllFaqsQuery, Result<List<GetAllFaqsQueryResponse>>>
{
    public async Task<Result<List<GetAllFaqsQueryResponse>>> Handle(GetAllFaqsQuery request, CancellationToken cancellationToken)
    {
        var faqs = await faqRepository.GetAll().ToListAsync(cancellationToken);

        var response = faqs.Select(f => new GetAllFaqsQueryResponse
        {
            Id = f.Id,
            Question = f.Question,
            Answer = f.Answer,
            IsPublish = f.IsPublish,
            PublishDate = f.PublishDate,
            CreatedDate = f.CreatedDate
        }).ToList();

        return response;
    }
}

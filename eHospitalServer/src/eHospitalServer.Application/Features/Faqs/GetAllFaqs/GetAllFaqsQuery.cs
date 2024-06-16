using eHospitalServer.Infrastructure.Results;
using MediatR;

namespace eHospitalServer.Application.Features.Faqs.GetAllFaqs;
public sealed record GetAllFaqsQuery : IRequest<Result<List<GetAllFaqsQueryResponse>>>;

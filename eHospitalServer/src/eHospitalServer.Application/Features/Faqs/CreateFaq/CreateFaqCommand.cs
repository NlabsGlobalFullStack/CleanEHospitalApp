using eHospitalServer.Infrastructure.Results;
using MediatR;

namespace eHospitalServer.Application.Features.Faqs.CreateFaq;
public sealed record CreateFaqCommand(
    string Question,
    string Answer,
    DateOnly PublishDate,
    bool IsPublish
) : IRequest<Result<string>>;

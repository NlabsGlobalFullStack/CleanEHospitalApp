using eHospitalServer.Infrastructure.Results;
using MediatR;

namespace eHospitalServer.Application.Features.Faqs.UpdateFaq;
public sealed record UpdateFaqCommand(
    string Id,
    string Question,
    string Answer,
    DateOnly PublishDate,
    bool IsPublish
) : IRequest<Result<string>>;

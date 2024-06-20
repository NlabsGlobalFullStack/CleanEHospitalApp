using eHospitalServer.Infrastructure.Results;
using MediatR;

namespace eHospitalServer.Application.Features.Faqs.DeleteByIdFaq;
public sealed record DeleteByIdFaqCommand(string Id) : IRequest<Result<string>>;

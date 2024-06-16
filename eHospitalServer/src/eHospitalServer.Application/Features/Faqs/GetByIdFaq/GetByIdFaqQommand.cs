using eHospitalServer.Domain.Entities;
using eHospitalServer.Infrastructure.Results;
using MediatR;

namespace eHospitalServer.Application.Features.Faqs.GetByIdFaq;
public sealed record GetByIdFaqQommand(string Id) : IRequest<Result<Faq>>;

using eHospitalServer.Domain.Entities;
using eHospitalServer.Infrastructure.Results;
using MediatR;

namespace eHospitalServer.Application.Features.Home.GetAllFaqs;
public sealed record GetAllFaqsQuery : IRequest<Result<List<Faq>>>;

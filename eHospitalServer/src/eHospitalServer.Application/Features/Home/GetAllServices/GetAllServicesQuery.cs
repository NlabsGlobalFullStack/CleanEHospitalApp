using eHospitalServer.Domain.Entities;
using eHospitalServer.Infrastructure.Results;
using MediatR;

namespace eHospitalServer.Application.Features.Home.GetAllServices;
public sealed record GetAllServicesQuery : IRequest<Result<List<Service>>>;

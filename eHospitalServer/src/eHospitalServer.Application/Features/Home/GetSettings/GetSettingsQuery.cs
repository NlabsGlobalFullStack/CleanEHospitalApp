using eHospitalServer.Domain.Entities;
using eHospitalServer.Infrastructure.Results;
using MediatR;

namespace eHospitalServer.Application.Features.Home.GetSettings;

public sealed record GetSettingsQuery : IRequest<Result<Setting>>;
using eHospitalServer.Infrastructure.Results;
using MediatR;

namespace eHospitalServer.Application.Features.Announcements.ChangeStatusAnnouncement;
public sealed record ChangeStatusCommand(string Id) : IRequest<Result<string>>;


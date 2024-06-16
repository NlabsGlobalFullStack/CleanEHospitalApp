using eHospitalServer.Infrastructure.Results;
using MediatR;

namespace eHospitalServer.Application.Features.Settings.UpdateSettings;

public sealed record UpdateSettingsCommand(
    string Id,
    string LogoUrl,
    string Title,
    string Author,
    string PhoneNumber,
    string Email,
    string Address,
    string Facebook,
    string Instagram,
    string Twitter,
    string Linkedin,
    string Youtube,
    string Descriptions,
    string Keywords,
    string About,
    string MapsCode
) : IRequest<Result<string>>;

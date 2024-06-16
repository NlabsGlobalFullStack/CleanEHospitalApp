using eHospitalServer.Domain.Entities;
using eHospitalServer.Domain.Repositories;
using eHospitalServer.Infrastructure.Results;
using MediatR;

namespace eHospitalServer.Application.Features.Settings.GetSettings;

internal sealed class GetSettingsQueryHandler(ISettingRepository settingRepository) : IRequestHandler<GetSettingsQuery, Result<Setting>>
{
    public async Task<Result<Setting>> Handle(GetSettingsQuery request, CancellationToken cancellationToken)
    {
        var setting = await settingRepository.GetFirstAsync(cancellationToken);
        if (setting is null)
        {
            return Result<Setting>.Failure("Settings not found!");
        }

        return setting;
    }
}

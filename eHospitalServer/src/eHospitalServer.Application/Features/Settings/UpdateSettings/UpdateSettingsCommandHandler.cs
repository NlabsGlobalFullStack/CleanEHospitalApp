using AutoMapper;
using eHospitalServer.Domain.Repositories;
using eHospitalServer.Domain.Repositories.DefaultRepositories;
using eHospitalServer.Infrastructure.Results;
using MediatR;

namespace eHospitalServer.Application.Features.Settings.UpdateSettings;

internal sealed class UpdateSettingsCommandHandler(
    ISettingRepository settingRepository,
    IMapper mapper,
    IUnitOfWork unitOfWork
) : IRequestHandler<UpdateSettingsCommand, Result<string>>
{
    public async Task<Result<string>> Handle(UpdateSettingsCommand request, CancellationToken cancellationToken)
    {
        var setting = await settingRepository.GetByExpressionAsync(p => p.Id == request.Id);
        if (setting is null)
        {
            return Result<string>.Failure("Settings not found!");
        }

        var result = mapper.Map(request, setting);

        settingRepository.Update(result);
        await unitOfWork.SaveChangesAsync(cancellationToken);

        return "System settings have been updated successfully.";
    }
}

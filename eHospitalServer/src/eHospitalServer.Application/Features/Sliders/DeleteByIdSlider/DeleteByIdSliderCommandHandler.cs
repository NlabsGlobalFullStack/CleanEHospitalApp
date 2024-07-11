using eHospitalServer.Domain.Repositories;
using eHospitalServer.Domain.Repositories.DefaultRepositories;
using eHospitalServer.Infrastructure.Results;
using MediatR;
using Nlabs.FileService;

namespace eHospitalServer.Application.Features.Sliders.DeleteByIdSlider;

internal sealed class DeleteByIdSliderCommandHandler(
    ISliderRepository sliderRepository,
    IUnitOfWork unitOfWork,
    IFileHostEnvironment fileHostEnvironment
) : IRequestHandler<DeleteByIdSliderCommand, Result<string>>
{
    public async Task<Result<string>> Handle(DeleteByIdSliderCommand request, CancellationToken cancellationToken)
    {
        var slider = await sliderRepository.GetByExpressionAsync(p => p.Id == request.Id, cancellationToken);
        if (slider is null)
        {
            return Result<string>.Failure("Slider not found!");
        }

        var fullPath = Path.Combine(fileHostEnvironment.WebRootPath, "sliders", slider.Image);

        if (File.Exists(fullPath))
        {
            FileService.FileDeleteToServer(fullPath);
        }

        slider.IsDeleted = true;
        sliderRepository.Delete(slider);

        await unitOfWork.SaveChangesAsync(cancellationToken);

        return "The slider delete process is successful";
    }
}
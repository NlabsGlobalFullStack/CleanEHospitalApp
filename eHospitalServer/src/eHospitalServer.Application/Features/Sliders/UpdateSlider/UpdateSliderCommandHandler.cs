using AutoMapper;
using eHospitalServer.Domain.Repositories;
using eHospitalServer.Domain.Repositories.DefaultRepositories;
using eHospitalServer.Infrastructure.Results;
using MediatR;
using Nlabs.FileService;

namespace eHospitalServer.Application.Features.Sliders.UpdateSlider;

internal sealed class UpdateSliderCommandHandler
    (
        ISliderRepository sliderRepository,
        IMapper mapper,
        IUnitOfWork unitOfWork,
        IFileHostEnvironment hostEnvironment
    ) : IRequestHandler<UpdateSliderCommand, Result<string>>
{
    public async Task<Result<string>> Handle(UpdateSliderCommand request, CancellationToken cancellationToken)
    {
        var sliderIsExists = await sliderRepository.GetByExpressionAsync(p => p.Id == request.Id, cancellationToken);

        if (sliderIsExists is null)
        {
            return Result<string>.Failure("Slider not found!");
        }

        var slider = mapper.Map(request, sliderIsExists);

        if (request.File is null)
        {
            var ImageName = sliderIsExists.Image;
            sliderIsExists.Image = ImageName;
        }

        if (request.File is not null)
        {
            var fullPath = Path.Combine(hostEnvironment.WebRootPath, "sliders", sliderIsExists.Image);

            if (File.Exists(fullPath))
            {
                FileService.FileDeleteToServer(fullPath);
            }
            var fileName = FileService.FileSaveToServer(request.File, "wwwroot/sliders/");
            slider.Image = fileName;
        }

        slider.IsUpdated = true;

        sliderRepository.Update(slider);
        await unitOfWork.SaveChangesAsync(cancellationToken);

        return "The slider has been saved successfully.";
    }
}

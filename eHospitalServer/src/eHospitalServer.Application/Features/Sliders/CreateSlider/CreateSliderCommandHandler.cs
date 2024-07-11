using AutoMapper;
using eHospitalServer.Domain.Entities;
using eHospitalServer.Domain.Repositories;
using eHospitalServer.Domain.Repositories.DefaultRepositories;
using eHospitalServer.Infrastructure.Results;
using MediatR;
using Nlabs.FileService;

namespace eHospitalServer.Application.Features.Sliders.CreateSlider;

internal sealed class CreateSliderCommandHandler
    (
        ISliderRepository sliderRepository,
        IMapper mapper,
        IUnitOfWork unitOfWork
    ) : IRequestHandler<CreateSliderCommand, Result<string>>
{
    public async Task<Result<string>> Handle(CreateSliderCommand request, CancellationToken cancellationToken)
    {
        var sliderIsExists = await sliderRepository.GetByExpressionAsync(p => p.Title == request.Title, cancellationToken);

        if (sliderIsExists is not null)
        {
            return Result<string>.Failure("The record with this information has already been added!");
        }

        var slider = mapper.Map<Slider>(request);
        var fileName = FileService.FileSaveToServer(request.File, "wwwroot/sliders/");
        slider.Image = fileName;

        await sliderRepository.AddAsync(slider, cancellationToken);
        await unitOfWork.SaveChangesAsync(cancellationToken);

        return "The slider has been saved successfully.";
    }
}

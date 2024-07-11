using eHospitalServer.Domain.Repositories;
using eHospitalServer.Infrastructure.Results;
using MediatR;

namespace eHospitalServer.Application.Features.Sliders.GetByIdSlider;

internal sealed class GetByIdSliderCommandHandler
    (
        ISliderRepository sliderRepository
    ) : IRequestHandler<GetByIdSliderCommand, Result<GetByIdSliderCommandResponse>>
{
    public async Task<Result<GetByIdSliderCommandResponse>> Handle(GetByIdSliderCommand request, CancellationToken cancellationToken)
    {
        var response = await sliderRepository.GetByExpressionAsync(p => p.IsDeleted == false, cancellationToken);

        var result = new GetByIdSliderCommandResponse
        {
            Id = response.Id,
            Title = response.Title,
            Description = response.Description,
            Image = Constants.ApplicationConstants.ApiUrl + response.Image,
            CreatedUser = response.CreatedUser,
            CreatedDate = response.CreatedDate,
            IsUpdated = response.IsUpdated,
            UpdatedUser = response.UpdatedUser,
            UpdatedDate = response.UpdatedDate,
            IsDeleted = response.IsDeleted,
            DeletedUser = response.DeletedUser,
            DeletedDate = response.DeletedDate,
        };

        return result;
    }
}

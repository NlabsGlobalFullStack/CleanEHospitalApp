using eHospitalServer.Application.Constants;
using eHospitalServer.Domain.Repositories;
using eHospitalServer.Infrastructure.Results;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace eHospitalServer.Application.Features.Sliders.GetAllSliders;

internal sealed class GetAllSlidersQueryHandler
    (
        ISliderRepository sliderRepository
    ) : IRequestHandler<GetAllSlidersQuery, Result<List<GetAllSlidersResponse>>>
{
    public async Task<Result<List<GetAllSlidersResponse>>> Handle(GetAllSlidersQuery request, CancellationToken cancellationToken)
    {
        var response = await sliderRepository.GetAll().Where(p => p.IsDeleted == false).ToListAsync(cancellationToken);
        var result = response.Select(s => new GetAllSlidersResponse
        {
            Id = s.Id,
            Title = s.Title,
            Image = ApplicationConstants.ApiUrl + "/sliders/" + s.Image,
            Description = s.Description,
            CreatedUser = s.CreatedUser,
            CreatedDate = s.CreatedDate,
            IsUpdated = s.IsUpdated,
            UpdatedUser = s.UpdatedUser,
            UpdatedDate = s.UpdatedDate,
            IsDeleted = s.IsDeleted,
            DeletedUser = s.DeletedUser,
            DeletedDate = s.DeletedDate,
        }).ToList();

        return result;
    }
}

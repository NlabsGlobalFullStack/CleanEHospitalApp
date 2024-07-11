using eHospitalServer.Application.Constants;
using eHospitalServer.Domain.Repositories;
using eHospitalServer.Infrastructure.Results;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace eHospitalServer.Application.Features.Home.GetAllSliders;

internal sealed class GetAllSlidersQueryHandler
    (
        ISliderRepository sliderRepository
    )
    : IRequestHandler<GetAllSlidersQuery, Result<List<GetAllSlidersQueryResponse>>>
{
    public async Task<Result<List<GetAllSlidersQueryResponse>>> Handle(GetAllSlidersQuery request, CancellationToken cancellationToken)
    {
        var sliders = await sliderRepository
            .GetAll()
            .Where(p => p.IsDeleted == false)
            .OrderByDescending(p => p.CreatedDate)
            .ToListAsync(cancellationToken);
        var responseList = new List<GetAllSlidersQueryResponse>();

        List<GetAllSlidersQueryResponse> response = sliders.Select(s => new GetAllSlidersQueryResponse
        {
            Title = s.Title,
            Description = s.Description,
            Image = ApplicationConstants.ApiUrl + "/sliders/" + s.Image
        }).ToList();

        return response;
    }
}

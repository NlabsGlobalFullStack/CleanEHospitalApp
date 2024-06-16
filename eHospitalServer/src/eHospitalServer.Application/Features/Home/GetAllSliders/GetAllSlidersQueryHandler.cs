using eHospitalServer.Domain.Entities;
using eHospitalServer.Domain.Repositories;
using eHospitalServer.Infrastructure.Results;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace eHospitalServer.Application.Features.Home.GetAllSliders;

internal sealed class GetAllSlidersQueryHandler(ISliderRepository sliderRepository) : IRequestHandler<GetAllSlidersQuery, Result<List<Slider>>>
{
    public async Task<Result<List<Slider>>> Handle(GetAllSlidersQuery request, CancellationToken cancellationToken)
    {
        var sliders = await sliderRepository.GetAll().ToListAsync(cancellationToken);

        return sliders;
    }
}

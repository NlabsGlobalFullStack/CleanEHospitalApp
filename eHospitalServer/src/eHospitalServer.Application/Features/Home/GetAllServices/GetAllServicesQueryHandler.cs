using eHospitalServer.Domain.Entities;
using eHospitalServer.Domain.Repositories;
using eHospitalServer.Infrastructure.Results;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace eHospitalServer.Application.Features.Home.GetAllServices;

internal sealed class GetAllServicesQueryHandler(IServiceRepository serviceRepository) : IRequestHandler<GetAllServicesQuery, Result<List<Service>>>
{
    public async Task<Result<List<Service>>> Handle(GetAllServicesQuery request, CancellationToken cancellationToken)
    {
        var services = await serviceRepository.GetAll().ToListAsync(cancellationToken);

        return services;
    }
}

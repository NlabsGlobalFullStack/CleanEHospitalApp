namespace eHospitalServer.Application.Features.Home.GetAllSliders;

public sealed record GetAllSlidersQueryResponse
{
    public string Title { get; set; } = default!;
    public string Image { get; set; } = default!;
    public string Description { get; set; } = default!;
}

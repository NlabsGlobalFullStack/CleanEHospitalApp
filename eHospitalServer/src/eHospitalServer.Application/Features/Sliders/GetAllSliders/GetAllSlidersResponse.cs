namespace eHospitalServer.Application.Features.Sliders.GetAllSliders;

public sealed record GetAllSlidersResponse
{
    public string Id { get; set; } = default!;
    public string? CreatedUser { get; set; } = default;
    public DateTime CreatedDate { get; set; } = default;
    public string? UpdatedUser { get; set; } = default;
    public DateTime? UpdatedDate { get; set; } = default;
    public bool IsUpdated { get; set; }
    public string? DeletedUser { get; set; } = default;
    public DateTime? DeletedDate { get; set; } = default;
    public bool IsDeleted { get; set; }

    public string Title { get; set; } = default!;
    public string Image { get; set; } = default!;
    public string Description { get; set; } = default!;
}
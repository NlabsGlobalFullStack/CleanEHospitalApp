namespace eHospitalServer.Application.Features.Home.GetByIdAnnouncement;

public sealed record GetByIdAnnouncementResponse
{
    public string Id { get; set; } = default!;
    public string CreatedUser { get; set; } = default!;
    public string UpdatedUser { get; set; } = default!;
    public string DeletedUser { get; set; } = default!;
    public string Image { get; set; } = default!;
    public string Title { get; set; } = default!;
    public string Summary { get; set; } = default!;
    public string Content { get; set; } = default!;

    public DateTime CreatedDate { get; set; } = default!;
    public bool IsUpdated { get; set; }
    public DateTime? UpdatedDate { get; set; } = default;
    public bool IsDeleted { get; set; }
    public DateTime? DeletedDate { get; set; } = default;

    public DateOnly PublishDate { get; set; } = default!;
    public bool IsPublish { get; set; } = false;
}
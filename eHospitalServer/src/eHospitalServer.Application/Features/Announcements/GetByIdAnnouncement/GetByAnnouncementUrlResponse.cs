namespace eHospitalServer.Application.Features.Announcements.GetByIdAnnouncement;

public sealed record GetByIdAnnouncementResponse
{
    public string Id { get; set; } = string.Empty;
    public string CreatedUser { get; set; } = string.Empty;
    public string UpdatedUser { get; set; } = string.Empty;
    public string DeletedUser { get; set; } = string.Empty;
    public string ImageUrl { get; set; } = string.Empty;
    public string Title { get; set; } = string.Empty;
    public string Summary { get; set; } = string.Empty;
    public string Content { get; set; } = string.Empty;

    public DateTime CreatedDate { get; set; }
    public bool IsUpdated { get; set; }
    public DateTime? UpdatedDate { get; set; }
    public bool IsDeleted { get; set; }
    public DateTime? DeletedDate { get; set; }

    public DateOnly PublishDate { get; set; }
    public bool IsPublish { get; set; } = false;
}
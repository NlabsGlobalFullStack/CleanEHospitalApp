namespace eHospitalServer.Application.Features.Announcements.GetAllAnnouncements;

public sealed record GetAllAnnouncementsQueryResponse
{
    public string Id { get; set; } = string.Empty;
    public string ImageUrl { get; set; } = string.Empty;
    public string Title { get; set; } = string.Empty;
    public string Url { get; set; } = string.Empty;
    public string Summary { get; set; } = string.Empty;
    public string Content { get; set; } = string.Empty;
    public DateOnly PublishDate { get; set; }
    public bool IsPublish { get; set; } = false;

    public DateTime CreatedDate { get; set; }
    public DateTime? UpdatedDate { get; set; }
    public bool IsUpdated { get; set; }
    public DateTime? DeletedDate { get; set; }
    public bool IsDeleted { get; set; }
}

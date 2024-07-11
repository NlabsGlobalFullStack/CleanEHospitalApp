namespace eHospitalServer.Application.Features.Home.GetAllAnnouncements;
public sealed record GetAllAnnouncementsQueryResponse
{
    public string Id { get; set; } = default!;
    public string Image { get; set; } = default!;
    public string Title { get; set; } = default!;
    public string Url { get; set; } = default!;
    public string Summary { get; set; } = default!;
    public string Content { get; set; } = default!;
    public DateOnly PublishDate { get; set; }
    public bool IsPublish { get; set; } = false;
}

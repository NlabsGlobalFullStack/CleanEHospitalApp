using eHospitalServer.Domain.Abstraction;

namespace eHospitalServer.Domain.Entities;
public sealed class Announcement : Entity
{
    public string ImageUrl { get; set; } = string.Empty;
    public string Title { get; set; } = string.Empty;
    public string Summary { get; set; } = string.Empty;
    public string Content { get; set; } = string.Empty;
    public DateOnly PublishDate { get; set; }
    public bool IsPublish { get; set; } = false;
}

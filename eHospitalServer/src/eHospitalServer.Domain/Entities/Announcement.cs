using eHospitalServer.Domain.Abstraction;

namespace eHospitalServer.Domain.Entities;
public sealed class Announcement : Entity
{
    public string Image { get; set; } = default!;
    public string Title { get; set; } = default!;
    public string Summary { get; set; } = default!;
    public string Content { get; set; } = default!;
    public DateOnly PublishDate { get; set; } = default;
    public bool IsPublish { get; set; } = false;
}

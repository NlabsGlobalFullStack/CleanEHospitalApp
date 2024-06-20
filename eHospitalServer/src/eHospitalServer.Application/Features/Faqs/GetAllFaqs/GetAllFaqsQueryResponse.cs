namespace eHospitalServer.Application.Features.Faqs.GetAllFaqs;

public sealed record GetAllFaqsQueryResponse
{
    public string Id { get; set; } = string.Empty;
    public string Question { get; set; } = string.Empty;
    public string Answer { get; set; } = string.Empty;
    public DateOnly PublishDate { get; set; }
    public bool IsPublish { get; set; } = false;
    public DateTime CreatedDate { get; set; } = default!;
}

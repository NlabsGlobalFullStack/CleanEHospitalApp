namespace eHospitalServer.Domain.Abstraction;
public abstract class Entity
{
    public string Id { get; set; } = Guid.NewGuid().ToString();
    public string? CreatedUser { get; set; } = default;
    public DateTime CreatedDate { get; set; } = DateTime.Now;
    public string? UpdatedUser { get; set; } = default;
    public DateTime? UpdatedDate { get; set; } = default;
    public bool IsUpdated { get; set; } = false;
    public string? DeletedUser { get; set; } = default;
    public DateTime? DeletedDate { get; set; } = default;
    public bool IsDeleted { get; set; } = false;
}

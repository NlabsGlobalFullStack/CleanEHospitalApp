namespace eHospitalServer.Domain.Abstraction;
public abstract class Entity
{
    protected Entity()
    {
        Id = Guid.NewGuid().ToString();
    }
    public string Id { get; set; }
    public string CreatedBy { get; set; }
    public DateTime CreatedDate { get; set; } = DateTime.Now;
    public string UpdatedBy { get; set; }
    public DateTime? UpdatedDate { get; set;}
    public string DeletedBy { get; set; }
    public DateTime? DeletedDate { get; set; }
}

namespace eHospitalServer.Domain.Abstraction;
public abstract class Entity
{
    protected Entity()
    {
        Id = Guid.NewGuid().ToString();
    }
    public string Id { get; set; }
}

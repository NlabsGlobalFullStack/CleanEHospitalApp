namespace eHospitalServer.Domain.Entities;
public sealed class Setting
{
    public string Id { get; set; } = Guid.NewGuid().ToString();
    public string Logo { get; set; } = string.Empty;
    public string Title { get; set; } = string.Empty;
    public string Author { get; set; } = string.Empty;
    public string PhoneNumber { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Address { get; set; } = string.Empty;
    public string Facebook { get; set; } = string.Empty;
    public string Instagram { get; set; } = string.Empty;
    public string Twitter { get; set; } = string.Empty;
    public string Linkedin { get; set; } = string.Empty;
    public string Youtube { get; set; } = string.Empty;
    public string Descriptions { get; set; } = string.Empty;
    public string Keywords { get; set; } = string.Empty;
    public string About { get; set; } = string.Empty;
    public string MapsCode { get; set; } = string.Empty;
}

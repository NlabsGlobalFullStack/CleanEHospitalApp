namespace eHospitalServer.Infrastructure.Options;
public sealed class EmailOptions
{
    public string Smtp { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
    public int Port { get; set; } = 587;
    public bool SSL { get; set; } = true;
    public bool HTML { get; set; } = true;
}

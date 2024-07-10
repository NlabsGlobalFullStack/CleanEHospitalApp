namespace eHospitalServer.Infrastructure.Options;
public sealed class EmailOptions
{
    public string Smtp { get; set; } = default!;
    public string Email { get; set; } = default!;
    public string Password { get; set; } = default!;
    public int Port { get; set; } = 587;
    public bool SSL { get; set; } = true;
    public bool HTML { get; set; } = true;
}

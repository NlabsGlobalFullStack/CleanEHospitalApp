using eHospitalServer.Domain.DTOs;

namespace eHospitalServer.Application.Features.Users.Queries.Patients.GetAllPatients;

public sealed record GetAllPatientsQueryResponse
{
    public string Id { get; set; } = string.Empty;
    public string UserId { get; set; } = string.Empty;
    public UserDto? User { get; set; }
}
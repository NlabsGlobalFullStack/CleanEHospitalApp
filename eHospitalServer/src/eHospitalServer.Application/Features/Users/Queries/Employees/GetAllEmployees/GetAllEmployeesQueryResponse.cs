using eHospitalServer.Domain.DTOs;
using eHospitalServer.Domain.Enums;

namespace eHospitalServer.Application.Features.Users.Queries.Employees.GetAllEmployees;

public sealed record GetAllEmployeesQueryResponse
{
    public string Id { get; set; } = string.Empty;
    public string UserId { get; set; } = string.Empty;
    public UserDto? User { get; set; }
    public string Department { get; set; } = string.Empty;
    public PositionEnum Position { get; set; } = PositionEnum.Driver;
}
using eHospitalServer.Domain.DTOs;
using eHospitalServer.Domain.Enums;

namespace eHospitalServer.Application.Features.Users.Queries.Nurses.GetAllNurses;
public sealed record GetAllNursesQueryResponse
{
    public string Id { get; set; } = string.Empty;
    public string UserId { get; set; } = string.Empty;
    public UserDto? User { get; set; }
    public string Department { get; set; } = string.Empty;
    public ShiftEnum Shift { get; set; } = ShiftEnum.Morning;
}
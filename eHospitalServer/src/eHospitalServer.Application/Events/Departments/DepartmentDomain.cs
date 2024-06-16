using MediatR;

namespace eHospitalServer.Application.Events.Departments;
public sealed record DepartmentDomain(string departmentId) : INotification;

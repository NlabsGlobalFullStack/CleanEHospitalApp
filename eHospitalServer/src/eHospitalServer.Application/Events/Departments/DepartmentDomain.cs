using eHospitalServer.Domain.Entities;
using MediatR;

namespace eHospitalServer.Application.Events.Departments;


public sealed class DepartmentDomain : INotification
{
    public readonly Department _department;

    public readonly string _subject;
    public readonly string _body;
    public DepartmentDomain(Department department, string subject, string body)
    {
        _department = department;
        _subject = subject;
        _body = body;
    }
}

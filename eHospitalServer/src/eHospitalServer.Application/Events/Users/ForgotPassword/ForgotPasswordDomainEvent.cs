using eHospitalServer.Domain.Entities;
using MediatR;

namespace eHospitalServer.Application.Events.Users.ForgotPassword;
public sealed class ForgotPasswordDomainEvent : INotification
{
    public readonly AppUser _user;

    public readonly string _subject;
    public readonly string _body;
    public ForgotPasswordDomainEvent(AppUser user, string subject, string body)
    {
        _user = user;
        _subject = subject;
        _body = body;
    }
}

using eHospitalServer.Domain.Entities;
using MediatR;

namespace eHospitalServer.Application.Events.Announcements;
public sealed class AnnouncementDomain : INotification
{
    public readonly Announcement _announcement;

    public readonly string _subject;
    public readonly string _body;

    public AnnouncementDomain(Announcement announcement, string subject, string body)
    {
        _announcement = announcement;
        _subject = subject;
        _body = body;
    }
}

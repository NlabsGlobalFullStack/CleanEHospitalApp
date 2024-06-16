using MediatR;

namespace eHospitalServer.Application.Events.Announcements;
public sealed record AnnouncementDomain(string announcementId) : INotification;

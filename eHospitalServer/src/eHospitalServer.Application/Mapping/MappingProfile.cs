using AutoMapper;
using eHospitalServer.Application.Features.Announcements.CreateAnnouncement;
using eHospitalServer.Application.Features.Announcements.UpdateAnnouncement;
using eHospitalServer.Application.Features.Departments.CreateDepartment;
using eHospitalServer.Application.Features.Departments.UpdateDepartment;
using eHospitalServer.Application.Features.Faqs.CreateFaq;
using eHospitalServer.Application.Features.Faqs.UpdateFaq;
using eHospitalServer.Application.Features.Rooms.CreateRoom;
using eHospitalServer.Application.Features.Rooms.UpdateRoom;
using eHospitalServer.Application.Features.Users.Queries.Users.GetAllUsers;
using eHospitalServer.Domain.Entities;
using eHospitalServer.Domain.Enums;

namespace eHospitalServer.Application.Mapping;
public sealed class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<CreateRoomCommand, Room>().ForMember(m => m.RoomType, options =>
        {
            options.MapFrom(map => RoomTypeEnum.FromValue(map.RoomTypeValue));
        });

        CreateMap<UpdateRoomCommand, Room>().ForMember(member => member.RoomType, options =>
        {
            options.MapFrom(map => RoomTypeEnum.FromValue(map.RoomTypeValue));
        });

        CreateMap<GetAllUsersQuery, AppUser>().ReverseMap();

        CreateMap<CreateDepartmentCommand, Department>().ReverseMap();
        CreateMap<UpdateDepartmentCommand, Department>().ReverseMap();


        CreateMap<CreateAnnouncementCommand, Announcement>().ReverseMap();
        CreateMap<UpdateAnnouncementCommand, Announcement>().ReverseMap();

        CreateMap<CreateFaqCommand, Faq>().ReverseMap();
        CreateMap<UpdateFaqCommand, Faq>().ReverseMap();
    }
}

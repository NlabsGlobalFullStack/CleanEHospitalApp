using AutoMapper;
using eHospitalServer.Application.Features.Announcements.CreateAnnouncement;
using eHospitalServer.Application.Features.Announcements.UpdateAnnouncement;
using eHospitalServer.Application.Features.Departments.CreateDepartment;
using eHospitalServer.Application.Features.Departments.UpdateDepartment;
using eHospitalServer.Application.Features.Faqs.CreateFaq;
using eHospitalServer.Application.Features.Faqs.UpdateFaq;
using eHospitalServer.Application.Features.Rooms.CreateRoom;
using eHospitalServer.Application.Features.Rooms.UpdateRoom;
using eHospitalServer.Application.Features.Sliders.CreateSlider;
using eHospitalServer.Application.Features.Sliders.UpdateSlider;
using eHospitalServer.Application.Features.Users.Queries.Users.GetAllUsers;
using eHospitalServer.Application.Features.Vehicles.CreateVehicle;
using eHospitalServer.Application.Features.Vehicles.UpdateVehicle;
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

        CreateMap<UpdateRoomCommand, Room>().ForMember(m => m.RoomType, options =>
        {
            options.MapFrom(map => RoomTypeEnum.FromValue(map.RoomTypeValue));
        });

        CreateMap<CreateVehicleCommand, Vehicle>().ForMember(m => m.VehicleType, options =>
        {
            options.MapFrom(map => VehicleTypeEnum.FromValue(map.VehicleTypeValue));
        });

        CreateMap<UpdateVehicleCommand, Vehicle>().ForMember(m => m.VehicleType, options =>
        {
            options.MapFrom(map => VehicleTypeEnum.FromValue(map.VehicleTypeValue));
        });

        CreateMap<GetAllUsersQuery, AppUser>().ReverseMap();

        CreateMap<CreateDepartmentCommand, Department>().ReverseMap();
        CreateMap<UpdateDepartmentCommand, Department>().ReverseMap();


        CreateMap<CreateAnnouncementCommand, Announcement>().ReverseMap();
        CreateMap<UpdateAnnouncementCommand, Announcement>().ReverseMap();

        CreateMap<CreateFaqCommand, Faq>().ReverseMap();
        CreateMap<UpdateFaqCommand, Faq>().ReverseMap();

        CreateMap<CreateSliderCommand, Slider>().ReverseMap();
        CreateMap<UpdateSliderCommand, Slider>().ReverseMap();
    }
}

using AutoMapper;
using LeaguerManagement.Entities.Entities;
using LeaguerManagement.Entities.ViewModels.Authentication;
using LeaguerManagement.Entities.ViewModels.Settings;

namespace LeaguerManagement.APIs.Configurations
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            //
            // Authentication
            CreateMap<UserModel, LoggedUserModel>().ReverseMap();
            CreateMap<UserModel, AuthenticationUserModel>().ReverseMap();
            CreateMap<UserTokenModel, UserToken>().ReverseMap();
            // Settings
            CreateMap<User, UserModel>().ReverseMap();
            CreateMap<AccessControl, AccessControlModel>().ReverseMap();
            CreateMap<Role, RoleModel>().ReverseMap();
            CreateMap<Ward, WardModel>().ReverseMap();
            CreateMap<District, DistrictModel>().ReverseMap();
            CreateMap<Apartment, ApartmentModel>().ReverseMap();
            CreateMap<Holiday, HolidayModel>().ReverseMap();
        }
    }
}

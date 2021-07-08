using AutoMapper;
using LeaguerManagement.Entities.Entities;
using LeaguerManagement.Entities.ViewModels;

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
            CreateMap<AccessControl, BaseSettingModel>().ReverseMap();
            CreateMap<Role, RoleModel>().ReverseMap();
            // Leaguer
            CreateMap<Leaguer, LeaguerModel>().ReverseMap();
            CreateMap<LeaguerAttachment, AttachmentModel>().ReverseMap();
            CreateMap<ChangeOfficialDocument, ChangeOfficialDocumentModel>().ReverseMap();
        }
    }
}

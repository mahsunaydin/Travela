using AutoMapper;
using Travela.EntityLayer.Concrete;
using Travela.WebUI.Dtos.LoginDto;
using Travela.WebUI.Dtos.RegisterDto;

namespace Travela.WebUI.Mapping
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<LoginUserDto, AppUser>().ReverseMap();
            CreateMap<CreateNewUserDto, AppUser>().ReverseMap();
        }
    }
}

using AutoMapper;
using Udemy.AdvertisementApp.Dtos;
using Udemy.AdvertisementApp.Entities;

namespace Udemy.AdvertisementApp.Business.Mappings.AutoMapper
{
    public class AppRoleProfile : Profile
    {
        public AppRoleProfile()
        {
            CreateMap<AppRole, AppRoleListDto>().ReverseMap();
            CreateMap<AppRole, AppRoleCreateDto>().ReverseMap();
            CreateMap<AppRole, AppRoleUpdateDto>().ReverseMap();
        }
    }
}

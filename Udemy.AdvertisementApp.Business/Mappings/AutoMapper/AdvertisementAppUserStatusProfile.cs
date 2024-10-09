using AutoMapper;
using Udemy.AdvertisementApp.Dtos;
using Udemy.AdvertisementApp.Entities;

namespace Udemy.AdvertisementApp.Business.Mappings.AutoMapper
{
    public class AdvertisementAppUserStatusProfile : Profile
    {
        public AdvertisementAppUserStatusProfile()
        {
            CreateMap<AdvertisementAppUserStatus, AdvertisementAppUserStatusListDto>().ReverseMap();
        }
    }
}

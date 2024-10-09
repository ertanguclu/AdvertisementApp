using AutoMapper;
using Udemy.AdvertisementApp.Dtos;
using Udemy.AdvertisementApp.Entities;

namespace Udemy.AdvertisementApp.Business.Mappings.AutoMapper
{
    public class MilitaryStatusProfile : Profile
    {
        public MilitaryStatusProfile()
        {
            CreateMap<MilitaryStatus, MilitaryStatusListDto>().ReverseMap();
        }
    }
}

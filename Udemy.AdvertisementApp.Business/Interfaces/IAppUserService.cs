using Udemy.AdvertisementApp.Dtos;
using Udemy.AdvertisementApp.Entities;

namespace Udemy.AdvertisementApp.Business.Interfaces
{
    public interface IAppUserService : IService<AppUserCreateDto, AppUserUpdateDto, AppUserListDto, AppUser>
    {
    }
}

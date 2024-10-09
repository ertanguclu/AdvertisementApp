using System.Threading.Tasks;
using Udemy.AdvertisementApp.Common;
using Udemy.AdvertisementApp.Dtos;

namespace Udemy.AdvertisementApp.Business.Interfaces
{
    public interface IAdvertisementAppUserService
    {
        Task<IResponse<AdvertisementAppUserCreateDto>> CreateAsync(AdvertisementAppUserCreateDto dto);
    }
}

using AutoMapper;
using FluentValidation;
using Udemy.AdvertisementApp.Business.Interfaces;
using Udemy.AdvertisementApp.DataAccess.UnitOfWork;
using Udemy.AdvertisementApp.Dtos;
using Udemy.AdvertisementApp.Entities;

namespace Udemy.AdvertisementApp.Business.Services
{
    public class AppUserService : Service<AppUserCreateDto, AppUserUpdateDto, AppUserListDto, AppUser>, IAppUserService
    {
        public AppUserService(IMapper mapper, IValidator<AppUserCreateDto> createDtoValidator, IValidator<AppUserUpdateDto> updateDtoValidator, IUow uow) :
            base(mapper, createDtoValidator, updateDtoValidator, uow)
        {

        }
    }
}

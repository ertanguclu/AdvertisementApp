using AutoMapper;
using FluentValidation;
using System.Collections.Generic;
using System.Threading.Tasks;
using Udemy.AdvertisementApp.Business.Extensions;
using Udemy.AdvertisementApp.Business.Interfaces;
using Udemy.AdvertisementApp.Common;
using Udemy.AdvertisementApp.DataAccess.UnitOfWork;
using Udemy.AdvertisementApp.Dtos;
using Udemy.AdvertisementApp.Entities;

namespace Udemy.AdvertisementApp.Business.Services
{
    public class AdvertisementAppUserService : IAdvertisementAppUserService
    {
        private readonly IUow _uow;
        private readonly IValidator<AdvertisementAppUserCreateDto> _createDtoValidator;
        private readonly IMapper _mapper;
        public AdvertisementAppUserService(IUow uow, IValidator<AdvertisementAppUserCreateDto> createDtoValidator, IMapper mapper)
        {
            _uow = uow;
            _createDtoValidator = createDtoValidator;
            _mapper = mapper;
        }
        public async Task<IResponse<AdvertisementAppUserCreateDto>> CreateAsync(AdvertisementAppUserCreateDto dto)
        {
            var result = _createDtoValidator.Validate(dto);
            if (result.IsValid)
            {
                var control = await _uow.GetRepository<AdvertisementAppUser>().GetByFilterAsync(x => x.AdvertisementId == dto.AdvertisementId && x.AppUserId == dto.AppUserId);
                if (control == null)
                {
                    var createAdvertisementAppUser = _mapper.Map<AdvertisementAppUser>(dto);
                    await _uow.GetRepository<AdvertisementAppUser>().CreateAsync(createAdvertisementAppUser);
                    await _uow.SaveChangesAsync();
                    return new Response<AdvertisementAppUserCreateDto>(ResponseType.Success, dto);
                }
                List<CustomValidationError> errors = new()
                {
                    new CustomValidationError
                    {
                        PropertyName = "",
                        ErrorMessage = "Daha önce başvurulan ilana başvurulamaz."
                    }
                };
                return new Response<AdvertisementAppUserCreateDto>(dto, errors);

            }
            return new Response<AdvertisementAppUserCreateDto>(dto, result.ConvertToCustomValidationError());
        }
    }
}

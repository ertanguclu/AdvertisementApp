using FluentValidation;
using Udemy.AdvertisementApp.Dtos;

namespace Udemy.AdvertisementApp.Business.ValidationRules
{
    public class GenderCreateDtoValidator : AbstractValidator<GenderCreateDto>
    {
        public GenderCreateDtoValidator()
        {
            RuleFor(x => x.Definition).NotEmpty();
        }
    }
}

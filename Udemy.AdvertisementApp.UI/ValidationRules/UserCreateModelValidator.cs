﻿using FluentValidation;
using Udemy.AdvertisementApp.UI.Models;

namespace Udemy.AdvertisementApp.UI.ValidationRules
{
    public class UserCreateModelValidator : AbstractValidator<UserCreateModel>
    {

        public UserCreateModelValidator()
        {

            RuleFor(x => x.Password).NotEmpty().WithMessage("Parola boş geçilemez");
            RuleFor(x => x.Password).MinimumLength(3).WithMessage("Parola en az 3 karakter olmalıdır");
            RuleFor(x => x.Password).Equal(x => x.ConfirmPassword).WithMessage("Parolalar eşleşmiyor!");
            RuleFor(x => x.Firstname).NotEmpty().WithMessage("Ad boş olamaz.");
            RuleFor(x => x.Surname).NotEmpty().WithMessage("Soyad boş olamaz.");
            RuleFor(x => x.Username).NotEmpty().WithMessage("Kullanıcı adı boş geçilemez.");
            RuleFor(x => x.Username).MinimumLength(3).WithMessage("Kullanıcı adı en az 3 karakter olmalıdır.");
            RuleFor(x => new
            {
                x.Firstname,
                x.Username
            }).Must(x => CanNotFirstname(x.Username, x.Firstname)).WithMessage("Kullanıcı adı, adınızı içeremez.").When(x => x.Username != null && x.Firstname != null);
            RuleFor(x => x.GenderId).NotEmpty().WithMessage("Cinsiyet seçimi zorunludur.");
        }

        private bool CanNotFirstname(string username, string firstname)
        {
            return !username.Contains(firstname);
        }
    }
}

using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using Udemy.AdvertisementApp.Business.Interfaces;
using Udemy.AdvertisementApp.Common.Enums;
using Udemy.AdvertisementApp.Dtos;
using Udemy.AdvertisementApp.UI.Extensions;
using Udemy.AdvertisementApp.UI.Models;

namespace Udemy.AdvertisementApp.UI.Controllers
{
    public class AccountController : Controller
    {
        private readonly IGenderService _genderService;
        private readonly IValidator<UserCreateModel> _userCreateValidator;
        private readonly IAppUserService _appUserService;
        private readonly IMapper _mapper;
        public AccountController(IGenderService genderService, IValidator<UserCreateModel> userCreateValidator, IAppUserService appUserService, IMapper mapper)
        {
            _genderService = genderService;
            _userCreateValidator = userCreateValidator;
            _appUserService = appUserService;
            _mapper = mapper;

        }
        public async Task<IActionResult> SignUp()
        {
            var response = await _genderService.GetAllAsync();
            var model = new UserCreateModel();
            model.Genders = new SelectList(response.Data, "Id", "Definition");
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> SignUp(UserCreateModel model)
        {
            var result = _userCreateValidator.Validate(model);
            if (result.IsValid)
            {
                var dto = _mapper.Map<AppUserCreateDto>(model);
                var createResponse = await _appUserService.CreateWithRoleAsync(dto, (int)RoleType.Member);
                return this.ResponseRedirectAction(createResponse, "SignIn");
            }
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(error.PropertyName, error.ErrorMessage);
            }
            var response = await _genderService.GetAllAsync();
            model.Genders = new SelectList(response.Data, "Id", "Definition", model.GenderId);

            return View(model);
        }
        public IActionResult SignIn()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> SignIn(AppUserLoginDto dto)
        {
            var result = await _appUserService.CheckUserAsync(dto);
            if (result.ResponseType == Common.ResponseType.Success)
            {
                //İlgili kullancının rollerini çekmemiz lazım
                var claims = new List<Claim>();
                var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                var authProperties = new AuthenticationProperties
                {
                    IsPersistent = dto.RememberMe
                };
                await HttpContext.SignInAsync(
                    CookieAuthenticationDefaults.AuthenticationScheme,
                    new ClaimsPrincipal(claimsIdentity), authProperties);
            }
            ModelState.AddModelError("", result.Message);
            return View(dto);

        }
    }
}

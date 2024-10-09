﻿using AutoMapper;
using System.Collections.Generic;
using Udemy.AdvertisementApp.Business.Mappings.AutoMapper;

namespace Udemy.AdvertisementApp.Business.Helpers
{
    public static class ProfileHelper
    {
        public static List<Profile> GetProfiles()
        {
            return new List<Profile>
            {
                new ProvidedServiceProfile(),
                new AdvertisementProfile(),
                new AppUserProfile(),
                new GenderProfile(),
                new AppRoleProfile(),
                new AdvertisementAppUserProfile()
            };
        }
    }
}

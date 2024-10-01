using System.Collections.Generic;

namespace Udemy.AdvertisementApp.Common
{
    public interface IResponse<T> : IResponse
    {
        T Data { get; set; }
        List<CustomValidationError> validationErrors { get; set; }
    }

}

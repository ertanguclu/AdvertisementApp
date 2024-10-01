using System.Collections.Generic;

namespace Udemy.AdvertisementApp.Common
{
    public class Response<T> : Response
    {
        public T Data { get; set; }
        public List<CustomValidationError> validationErrors { get; set; }
        public Response(ResponseType responseType, string message) : base(responseType, message)
        {
        }
        public Response(ResponseType responseType, T data) : base(responseType)
        {
            Data = data;
        }
        public Response(T data, List<CustomValidationError> errors) : base(ResponseType.ValidationError)
        {
            validationErrors = errors;
            Data = data;
        }
    }
}

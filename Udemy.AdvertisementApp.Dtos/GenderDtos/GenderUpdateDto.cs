using Udemy.AdvertisementApp.Dtos.Interfaces;

namespace Udemy.AdvertisementApp.Dtos
{
    public class GenderUpdateDto : IUpdateDto
    {
        public int Id { get; set; }
        public string Definition { get; set; }
    }
}

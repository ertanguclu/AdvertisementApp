using System.Threading.Tasks;
using Udemy.AdvertisementApp.DataAccess.UnitOfWork;

namespace Udemy.AdvertisementApp.Business.Services
{
    public class AdvertisementAppUserService
    {
        private readonly IUow _uow;
        public AdvertisementAppUserService(IUow uow)
        {
            _uow = uow;
        }
        public async Task Create()
        {

        }
    }
}

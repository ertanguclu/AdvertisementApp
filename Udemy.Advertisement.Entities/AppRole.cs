using System.Collections.Generic;

namespace Udemy.Advertisement.Entities
{
    public class AppRole : BaseEntity
    {
        public string Definition { get; set; }
        public List<AppUserRole> AppUserRoles { get; set; }
    }
}

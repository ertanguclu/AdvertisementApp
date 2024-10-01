using System.Collections.Generic;

namespace Udemy.Advertisement.Entities
{
    public class Gender : BaseEntity
    {
        public string Definition { get; set; }
        public List<AppUser> AppUsers { get; set; }
    }
}

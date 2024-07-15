using Microsoft.AspNetCore.Identity;
using Domain.Entities.Base;

namespace Domain.Entities
{
    public class AppUser : IdentityUser<int>, IBaseEntity
    {
        public DateTime CreatedAt { get; set; }
        public int CreatedBy { get; set; }
    }
}

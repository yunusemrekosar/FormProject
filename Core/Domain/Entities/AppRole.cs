using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;
using Domain.Entities.Base;

namespace Domain.Entities
{
    public class AppRole : IdentityRole<int>, IBaseEntity
    {
        [NotMapped]
        public DateTime CreatedAt { get; set; }
        [NotMapped]
        public int CreatedBy { get; set; }
    }
}

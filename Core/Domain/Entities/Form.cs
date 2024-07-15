using System.ComponentModel.DataAnnotations;
using Domain.Entities.Base;

namespace Domain.Entities
{
    public class Form : BaseEntity
    {
        [Required] 
        public string Name { get; set; }
        public string Description { get; set; }

        //relations 
        public AppUser User { get; set; }
        public ICollection<FormField> FormFields { get; set; }
    }
}
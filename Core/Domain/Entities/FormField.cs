using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Domain.Entities.Base;

namespace Domain.Entities
{
    public class FormField : IBaseEntity
    {
        #region NotMappeds
        public int Id { get; set; }
        [NotMapped]
        public DateTime CreatedAt { get; set; }
        [NotMapped]
        public int CreatedBy { get; set; }
        #endregion

        [Required]
        public string Name { get; set; }
        public bool Required { get; set; } = false;
        [Required]
        public int DataType { get; set; } // int = 1 , string = 2 

        //relations
        public int FormId { get; set; }
        public Form Form { get; set; }
    }
}

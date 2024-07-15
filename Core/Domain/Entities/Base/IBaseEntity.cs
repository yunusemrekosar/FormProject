using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities.Base
{
    public interface IBaseEntity
    {
        public int Id { get; set; }

        [Column(TypeName = "datetime")]
        public  DateTime CreatedAt { get; set; }
        public int CreatedBy { get; set; }
    }
}

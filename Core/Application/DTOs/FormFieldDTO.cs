using System.ComponentModel.DataAnnotations;

namespace Application.Dtos
{
    public class FormFieldDTO
    {

        [Required]
        public string FieldName { get; set; }
        public bool IsRequired { get; set; } = false;
        [Required]
        public int DataType { get; set; } // int = 1 , string = 2 

    }
}

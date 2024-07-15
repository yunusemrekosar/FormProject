using System.ComponentModel.DataAnnotations;
using Application.CQRS;
using Application.Dtos;
using Domain.Entities;
using MediatR;

namespace Application.Features.Commands.FormCommands.AddForm
{
    public class AddFormCommandRequest : BaseRequest, IRequest<AddFormCommandResponse>
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }


        public List<string> FieldName { get; set; }
        public List<bool> IsRequired { get; set; }
        public List<int> DataType { get; set; }

        public List<FormFieldDTO> FormFields { get; set; } = new();

        /*
         
          public string FieldName { get; set; }
        public bool IsRequired { get; set; } = false;
        [Required]
        public int DataType { get; set; } // int = 1 , string = 2 
         */
    }
}
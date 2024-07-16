using System.ComponentModel.DataAnnotations;
using Application.CQRS;
using Application.Dtos;
using MediatR;

namespace Application.Features.Commands.FormCommands.AddForm
{
    public class AddFormCommandRequest : BaseRequest, IRequest<AddFormCommandResponse>
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        public List<FormFieldDTO> FormFields { get; set; } = new();

    }
}
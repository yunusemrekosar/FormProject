using Application.CQRS;
using System.ComponentModel.DataAnnotations;
using MediatR;

namespace Application.Features.Commands.AccountCommands.RegisterUser
{
    public class RegisterUserCommandRequest : BaseRequest, IRequest<RegisterUserCommandResponse>
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        
        [Required]
        public string Password { get; set; }
        [Required]
        public string RePassword { get; set; }

        [Required]
        public string UserName { get; set; }
    }
}

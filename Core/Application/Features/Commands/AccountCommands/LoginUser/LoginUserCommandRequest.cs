using Application.CQRS;
using MediatR;

namespace Application.Features.Commands.AccountCommands.LoginUser
{
    public class LoginUserCommandRequest : BaseRequest , IRequest<LoginUserCommandResponse>
    {
        public string Password { get; set; }
        public string UsernameOrEmail { get; set; }
    }
}
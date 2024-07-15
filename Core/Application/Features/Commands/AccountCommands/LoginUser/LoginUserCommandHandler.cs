using Microsoft.AspNetCore.Identity;
using Domain.Entities;
using MediatR;

namespace Application.Features.Commands.AccountCommands.LoginUser
{
    public class LoginUserCommandHandler : IRequestHandler<LoginUserCommandRequest, LoginUserCommandResponse>
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;

        public LoginUserCommandHandler(SignInManager<AppUser> signInManager, UserManager<AppUser> userManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
        }

        public async Task<LoginUserCommandResponse> Handle(LoginUserCommandRequest request, CancellationToken cancellationToken)
        {
            LoginUserCommandResponse response = new();
            try
            {
                bool IsEmail = request.UsernameOrEmail.Contains('@');

                AppUser? user;

                if (IsEmail)
                    user = await _userManager.FindByEmailAsync(request.UsernameOrEmail);
                else
                    user = await _userManager.FindByNameAsync(request.UsernameOrEmail);

                if (user != null)
                {
                    var result = await _signInManager.PasswordSignInAsync(user.NormalizedUserName, request.Password, isPersistent: true, lockoutOnFailure: false);
                    if (result.Succeeded)
                    {
                        response.IsSuccess = true;
                        response.Message = "Giriş Başarılı!";
                    }
                    else
                        response.Message = "Email ya da Şifre Yanlış";
                }
                else
                    response.Message = "Email ya da Şifre Yanlış";
            }
            catch (Exception ex)
            {
                //Loglanabilir
            }
            return response;
        }
    }
}

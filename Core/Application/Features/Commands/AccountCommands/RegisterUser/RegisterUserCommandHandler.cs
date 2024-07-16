using Microsoft.AspNetCore.Identity;
using Domain.Entities;
using MediatR;

namespace Application.Features.Commands.AccountCommands.RegisterUser
{
    public class RegisterUserCommandHandler : IRequestHandler<RegisterUserCommandRequest, RegisterUserCommandResponse>
    {
        private readonly SignInManager<AppUser> _signInManager;
        private readonly UserManager<AppUser> _userManager;

        public RegisterUserCommandHandler(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public async Task<RegisterUserCommandResponse> Handle(RegisterUserCommandRequest request, CancellationToken cancellationToken)
        {
            RegisterUserCommandResponse response = new();
            try
            {
                //todo: email ve username kontolü yap

                if (request.Password != request.RePassword)
                {
                    response.Message = "Şifreler Aynı değil";
                    return response;
                }
                AppUser user = new();
                user.Email = request.Email;
                user.EmailConfirmed = false;
                user.UserName = request.UserName;
                var result = await _userManager.CreateAsync(user, request.Password);

                if (result.Succeeded)
                {
                    await _signInManager.SignInAsync(user, isPersistent: true);
                    response.IsSuccess = true;
                    response.Message = "Kullanıcı Başarıyla Kayıt Edildi!";
                }
                else
                    response.Message = result.Errors.First().Description;
            }
            catch (Exception ex)
            {
                //response.Message = ex.Message;
            }
            return response;
        }
    }
}

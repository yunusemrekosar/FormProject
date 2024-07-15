using Application.Features.Commands.AccountCommands.LoginUser;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc;
using MediatR;
using Application.Features.Commands.AccountCommands.RegisterUser;

namespace FormProjectPresenter.Controllers
{
    public class AccountController : Controller
    {
        readonly IMediator _MediatR;

        public AccountController(IMediator mediatR)
        {
            _MediatR = mediatR;
        }

        [Route(nameof(Login))]
        [HttpGet]
        public IActionResult Login(string? ReturnUrl)
        {
            if (User.Identity.IsAuthenticated)
                return RedirectToAction("Index", "home");

            TempData["ReturnUrl"] = ReturnUrl;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginUserCommandRequest request)
        {
            if (!ModelState.IsValid)
            {
                TempData["CameFromPostState"] = false;
                TempData["CameFromPostMessage"] = ModelState.Values
                    .Where(x => x.ValidationState == ModelValidationState.Invalid)
                    .First().Errors.First().ErrorMessage;
                        return LocalRedirect("/login");

            }

            var response = await _MediatR.Send(request);

            if (response.IsSuccess)
                return LocalRedirect(TempData["ReturnUrl"] == null ? "/" : TempData["ReturnUrl"].ToString());

            TempData["CameFromPostState"] = response.IsSuccess;
            TempData["CameFromPostMessage"] = response.Message;

            return LocalRedirect("/login");
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterUserCommandRequest request)
        {

            if (!ModelState.IsValid)
            {
                TempData["CameFromPostState"] = false;
                TempData["CameFromPostMessage"] = ModelState.Values
                    .Where(x => x.ValidationState == ModelValidationState.Invalid)
                    .First().Errors.First().ErrorMessage;
                return View();
            }
            var response = await _MediatR.Send(request);

            TempData["CameFromPostState"] = response.IsSuccess;
            TempData["CameFromPostMessage"] = response.Message;

            return LocalRedirect(TempData["ReturnUrl"] == null ? "/" : TempData["ReturnUrl"].ToString());
        }

    }
}

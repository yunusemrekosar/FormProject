using Application.Features.Commands.FormCommands.AddForm;
using Azure.Core;
using Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace FormProjectPresenter.Controllers
{
    public class FormController : Controller
    {
        readonly UserManager<AppUser> _userManager;
        readonly IMediator _MediatR;

        public FormController(UserManager<AppUser> userManager, IMediator mediatR)
        {
            _userManager = userManager;
            _MediatR = mediatR;
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddForm(AddFormCommandRequest request)
        {
            request.LoggedUserId = int.Parse(_userManager.GetUserId(User));

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
            return View();
        }
    }
}

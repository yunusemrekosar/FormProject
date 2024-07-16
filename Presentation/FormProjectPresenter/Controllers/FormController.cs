using Application.Features.Queries.FormQueries.DetailForm;
using Application.Features.Commands.FormCommands.AddForm;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Domain.Entities;
using MediatR;

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

        [Route("forms/{formId}")]
        public async Task<IActionResult> Forms(int formId)
        {
            var request = new DetailFormQueryRequest { Id = formId };

            request.LoggedUserId = int.Parse(_userManager.GetUserId(User));

            if (!ModelState.IsValid)
            {
                TempData["CameFromPostState"] = false;
                TempData["CameFromPostMessage"] = ModelState.Values
                    .Where(x => x.ValidationState == ModelValidationState.Invalid)
                    .First().Errors.First().ErrorMessage;
                return RedirectToAction("index", "home");
            }

            var response = await _MediatR.Send(request);

            if (response.IsSuccess)
                return View(response);

            TempData["CameFromPostState"] = response.IsSuccess;
            TempData["CameFromPostMessage"] = response.Message;

            return RedirectToAction("index", "home");
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
                return RedirectToAction("index", "home");
            }

            var response = await _MediatR.Send(request);

            TempData["CameFromPostState"] = response.IsSuccess;
            TempData["CameFromPostMessage"] = response.Message;

            return RedirectToAction("index", "home");
        }
    }
}

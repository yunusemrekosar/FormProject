using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Application.Dtos;
using Application.Features.Queries.FormQueries.ListForms;
using MediatR;
using Domain.Entities;
using Microsoft.AspNetCore.Identity;

namespace FormProjectPresenter.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        readonly UserManager<AppUser> _userManager;
        readonly IMediator _MediatR;

        public HomeController(IMediator mediatR, UserManager<AppUser> userManager)
        {
            _MediatR = mediatR;
            _userManager = userManager;
        }

        public async Task<IActionResult> Index(ListFormsQueryRequest request)
        {
            request.LoggedUserId = int.Parse(_userManager.GetUserId(User));

            var response = await _MediatR.Send(request);

            if (!response.IsSuccess)
            {
                TempData["CameFromPostState"] = response.IsSuccess;
                TempData["CameFromPostMessage"] = response.Message;
            }

            return View(response);
        }
    }
}

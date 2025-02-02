using ECommerce.Application.Dtos.authenticationDtos;
using ECommerce.Application.Interfaces.Authentication;
using ECommerce.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.Web.Controllers
{
    public class AccountController : Controller
    {
        private readonly IRegistrationService _registrationService;

        public AccountController(IRegistrationService registrationService)
        {
            _registrationService = registrationService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Register()
        {
            return View();
        }


        [HttpPost]
        public async Task< IActionResult>Register(RegisterViewModel model)
        {
            if (ModelState.IsValid) {
                var result = await _registrationService.Register(new RegisterDto
                {
                    Email = model.Email,
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    Password = model.Password,
                    BirthDate = model.BirthDate,
                    ProfileImage = model.ProfileImage
                });

                if (result.Success)
                {
                    return RedirectToAction("Index", "Home");
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error);
                }
            }
            return View();
        }
    }
}

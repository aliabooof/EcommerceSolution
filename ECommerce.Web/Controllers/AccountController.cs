using ECommerce.Application.Dtos.authenticationDtos;
using ECommerce.Application.Interfaces.Authentication;
using ECommerce.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.Web.Controllers
{
    public class AccountController : Controller
    {
        private readonly IRegistrationService _registrationService;
        private readonly IAuthenticationService _authenticationService;

        public AccountController(IRegistrationService registrationService, IAuthenticationService authenticationService)
        {
            _registrationService = registrationService;
            _authenticationService = authenticationService;
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

                if (!result.Success)
                {

                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError("", error);
                    }
                }
                return View("RegistrationSuccessful");
            }
            return View(model);
      
        }


        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]  
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return (View(model));
            }

            var result = await _authenticationService.LoginAsync(new LoginDto
            {
                Email = model.Email,
                Password = model.Password,
                RememberMe = model.RememberMe
            });
            if (result.Success)
            {
                return RedirectToAction("Index", "Home");
            }
           foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error);
                }

            return View(model);
        }
   
       public async Task<IActionResult> ConfirmEmail(string userid, string token)
       {
            if (string.IsNullOrEmpty(userid) || string.IsNullOrEmpty(token))
            {
                return RedirectToAction(nameof(Login));
            }
            var result =  await _registrationService.ConfirmEmailAsync(userid,token);

            if (result.Success)
            {
                return View("AccountConfirmed");
            }
            return View();
       }

        public async Task<IActionResult> Logout()
        {
            var result = await _authenticationService.LogoutAsync();
            if (!result.Success)
            {
                return RedirectToAction("Index", "Home");
            }
            return View(nameof(Login));
        }


    }
}

using ECommerce.Application.Dtos.authenticationDtos;
using AuthenticationResult = ECommerce.Application.Dtos.Models.AuthenticationResult;
using EcommerceSolution.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using ECommerce.Application.Interfaces.Authentication;
using Microsoft.Extensions.Logging;

namespace ECommerce.Infrastructure.Services.Authentication
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly ILogger _logger;

        public AuthenticationService(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager,
            ILogger logger)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _logger = logger;
        }

        public async Task<AuthenticationResult> LoginAsync(LoginDto dto)
        {
            var user =await _userManager.FindByEmailAsync(dto.Email);
            if(user == null)
            {
                return new AuthenticationResult {
                    Success = false,
                    Errors = new List<string> { "Email not found.\nSignUp if you dont have account" }
                };   
            }
            var result = await _userManager.CheckPasswordAsync(user, dto.Password);
            if (!result)
            {
                return new AuthenticationResult
                {
                    Success = false,
                    Errors = new List<string> { "Wrong Email Or Password" }
                };
            }

            if (!user.EmailConfirmed)
            {
                return new AuthenticationResult
                {
                    Success = false,
                    Errors = new List<string> { "Please Confirm your Email " }
                };
            }

            if ((await _signInManager.PasswordSignInAsync(user, dto.Password, dto.RememberMe, false)) is not null)
            {
                return new AuthenticationResult
                {
                    Success = true,
                };
            }

            return new AuthenticationResult
            {
                Success = false,
                Errors = new List<string> { "Invalid SignIn operation" }
            };



        }

        public async Task<AuthenticationResult> LogoutAsync()
        {
            await _signInManager.SignOutAsync();
            _logger.LogInformation("User signed out.");
            return new AuthenticationResult
            {
                Success = true
            };
        }
    }
}

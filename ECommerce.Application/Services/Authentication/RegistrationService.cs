using ECommerce.Application.Dtos.authenticationDtos;
using AuthenticationResult = ECommerce.Application.Dtos.Models.AuthenticationResult;
using EcommerceSolution.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using ECommerce.Application.Interfaces.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.AspNetCore.Routing;
using Microsoft.AspNetCore.Mvc.Abstractions;
using ECommerce.Application.Interfaces.Emails;



namespace ECommerce.Application.Services.Authentication
{
    public class RegistrationService : IRegistrationService
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IUrlHelperFactory _urlHelperFactory;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IEmailSender _emailSender;

        public RegistrationService(UserManager<AppUser> userManager, IUrlHelperFactory urlHelperFactory,
            IHttpContextAccessor httpContextAccessor , IEmailSender emailSender)
        {                                                            
            _userManager = userManager;
            _urlHelperFactory = urlHelperFactory;
            _httpContextAccessor = httpContextAccessor;
            _emailSender = emailSender;


        }
        public async Task<AuthenticationResult> Register(RegisterDto dto)
        {
            if (dto == null)
            {
                throw new ArgumentNullException(nameof(dto));
            }
            var user = new AppUser
            {
                Email = dto.Email,
                UserName = dto.Email,
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                BirthDate = dto.BirthDate,
                ProfileImage = dto.ProfileImage ?? "default!"
            };
            var result = await _userManager.CreateAsync(user, dto.Password);
            if (!result.Succeeded)
            {
                return new AuthenticationResult
                {
                    Success = false,
                    Errors = result.Errors.Select(x => x.Description).ToList()
                };
            }
            var token = await _userManager.GenerateEmailConfirmationTokenAsync(user);
            if(token == null)
            {
                return new AuthenticationResult
                {
                    Success = false,
                    Errors = new List<string> { "failed " }
                };
            }

            var urlHelper = _urlHelperFactory.GetUrlHelper(
               new ActionContext(_httpContextAccessor.HttpContext, new RouteData(), new ActionDescriptor()));
            var confirmationLink = urlHelper.Action("ConfirmEmail", "Account",
                new { userId = dto.Email,token }, protocol: _httpContextAccessor.HttpContext.Request.Scheme);

            await _emailSender.SendEmailAsync(dto.Email, "Confirm your email", $"Click <a href=\"{confirmationLink}\">here</a> to confirm your email.");

            return new AuthenticationResult {  Success = true };
           
        }

        public async Task<AuthenticationResult> ConfirmEmailAsync(string userId, string token)
        {
            if (userId == null || token == null)
            {
                return new AuthenticationResult
                {
                    Success = false,
                    Errors = new List<string> { "operation failed " }
                };
            }

            var user = await _userManager.FindByEmailAsync(userId);
            if (user == null)
            {
                return new AuthenticationResult
                {
                    Success = false,
                    Errors = new List<string> { "operation failed " }
                };
            }

            var result = await _userManager.ConfirmEmailAsync(user, token);
            if (!result.Succeeded)
            {
                return new AuthenticationResult
                {
                    Success = false,
                    Errors = new List<string> { "operation failed " }
                };

            }
            return new AuthenticationResult {Success = true};
        }

        public Task<AuthenticationResult> Unregister()
        {
            throw new NotImplementedException();
        }
    }   
}

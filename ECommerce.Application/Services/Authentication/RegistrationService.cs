using ECommerce.Application.Dtos.authenticationDtos;
using AuthenticationResult = ECommerce.Application.Dtos.Models.AuthenticationResult;
using EcommerceSolution.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using ECommerce.Application.Interfaces.Authentication;

namespace ECommerce.Application.Services.Authentication
{
    public class RegistrationService : IRegistrationService
    {
        private readonly UserManager<AppUser> _userManager;

        public RegistrationService(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }
        public Task<AuthenticationResult> ConfirmEmailAsync(string userId, string token)
        {
            throw new NotImplementedException();
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
            if (result.Succeeded)
            {
                return new AuthenticationResult
                {
                    Success = true
                };
            }
            else
            {
                return new AuthenticationResult
                {
                    Success = false,
                    Errors = result.Errors.Select(x => x.Description).ToList()
                };
            }
        }


        public Task<AuthenticationResult> Unregister(string email, string password)
        {
            throw new NotImplementedException();
        }

        public Task<AuthenticationResult> Unregister()
        {
            throw new NotImplementedException();
        }

    }   
}

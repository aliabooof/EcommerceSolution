using ECommerce.Application.Dtos.authenticationDtos;
using AuthenticationResult = ECommerce.Application.Dtos.Models.AuthenticationResult;
namespace ECommerce.Application.Interfaces.Authentication
{
    public interface IAuthenticationService
    {
        Task<AuthenticationResult> LoginAsync(LoginDto dto);
        Task<AuthenticationResult> LogoutAsync();
    }
}

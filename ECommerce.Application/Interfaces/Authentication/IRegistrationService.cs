using ECommerce.Application.Dtos.authenticationDtos;
using AuthenticationResult = ECommerce.Application.Dtos.Models.AuthenticationResult;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Application.Interfaces.Authentication
{
    public interface IRegistrationService
    {
        Task<AuthenticationResult> Register(RegisterDto dto);
        Task<AuthenticationResult> Unregister();
        Task<AuthenticationResult> ConfirmEmailAsync(string userId, string token);

    }
}

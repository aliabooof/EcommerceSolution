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
    public interface IAuthenticationService
    {
        Task<AuthenticationResult> LoginAsync(LoginDto dto);
    }
}

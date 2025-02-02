using ECommerce.Application.Interfaces.Authentication;
using EcommerceSolution.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Infrastructure.Services.Authentication
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly UserManager<AppUser> _userManager;

        public AuthenticationService(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        public Task<AuthenticationResult> Login(string email, string password)
        {
            throw new NotImplementedException();
        }
    }
}

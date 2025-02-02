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
        Task<AuthenticationResult> Login(string email, string password);
    }
}

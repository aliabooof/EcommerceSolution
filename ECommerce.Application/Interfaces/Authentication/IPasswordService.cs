using Microsoft.Identity.Client;
using AuthenticationResult = ECommerce.Application.Dtos.Models.AuthenticationResult;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Application.Interfaces.Authentication
{
    public interface IPasswordService
    {
        Task<AuthenticationResult> ForgorPassword(string email);
        Task<AuthenticationResult> ResetPassword(string userId, string token, string newPassword);
    }
}

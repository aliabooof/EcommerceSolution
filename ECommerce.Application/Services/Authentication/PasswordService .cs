﻿using AuthenticationResult = ECommerce.Application.Dtos.Models.AuthenticationResult;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ECommerce.Application.Interfaces.Authentication;

namespace ECommerce.Application.Services.Authentication
{
    public class PasswordService : IPasswordService
    {
        public Task<AuthenticationResult> ForgorPassword(string email)
        {
            throw new NotImplementedException();
        }

        public Task<AuthenticationResult> ResetPassword(string userId, string token, string newPassword)
        {
            throw new NotImplementedException();
        }
    }
}

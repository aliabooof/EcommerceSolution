using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Application.Dtos.authenticationDtos
{
    public class LoginDto : AuthDto
    {

        public string Password { get; set; } = default!;
        public bool RememberMe { get; set; } 
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Application.Dtos.authenticationDtos
{
    public class ResetPasswordDto : AuthDto
    {
        public string NewPassword { get; set; } = default!;
        public string Token { get; set; } = default!;
    }
}

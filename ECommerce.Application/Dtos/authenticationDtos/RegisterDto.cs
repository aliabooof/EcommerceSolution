using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Application.Dtos.authenticationDtos
{
    public class RegisterDto : AuthDto
    {
        public string FirstName { get; set; } = default!;
        public string LastName { get; set; } = default!;
        public string Password { get; set; } = default!;

        public DateTime BirthDate { get; set; }
        public string? ProfileImage { get; set; } 

    }
}

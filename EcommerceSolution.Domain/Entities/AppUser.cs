using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceSolution.Domain.Entities
{
    public class AppUser:IdentityUser
    {
        [Required]
        public string FirstName { get; set; } = default!;
        [Required]
        public string LastName { get; set; } = default!;
        [Required]
        public DateTime BirthDate { get; set; }
        public DateTime CreateDate { get; set; } = DateTime.UtcNow;
        public string ProfileImage { get; set; } = "default!";
    }
}

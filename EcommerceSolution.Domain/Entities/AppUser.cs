using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

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

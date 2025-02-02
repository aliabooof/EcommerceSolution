using System.ComponentModel.DataAnnotations;

namespace ECommerce.Web.Models
{
    public class RegisterViewModel
    {
        [Required]
        public string Email { get; set; } = default!;
        [Required]
        public string FirstName { get; set; } = default!;
        [Required]
        public string LastName { get; set; } = default!;
        [Required]
        public string Password { get; set; } = default!;
        [Required]
        [Compare("Password", ErrorMessage = "Passwords do not match")]
        public string ConfirmPassword { get; set; } = default!;
        [Required]
        public DateTime BirthDate { get; set; }
        public string? ProfileImage { get; set; }
    }
}

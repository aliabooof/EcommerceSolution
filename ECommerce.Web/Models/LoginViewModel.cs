using System.ComponentModel.DataAnnotations;

namespace ECommerce.Web.Models
{
    public class LoginViewModel
    {
        [Required]  
        public string Email { get; set; } = default!;
        [Required]
        public string Password { get; set; } = default!;
        public bool RememberMe { get; set; }
    }
}

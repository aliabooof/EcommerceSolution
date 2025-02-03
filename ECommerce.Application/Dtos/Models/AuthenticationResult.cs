namespace ECommerce.Application.Dtos.Models
{
    public class AuthenticationResult
    {
        public bool Success { get; set; }=default!; 
        public string Token { get; set; } =default!;
        public List<string>? Errors { get; set; }

    }
}

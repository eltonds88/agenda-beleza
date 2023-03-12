using System.ComponentModel.DataAnnotations;

namespace AgendaBeleza.Api.ViewModels
{
    public class LoginRequest
    {
        [Required]
        public string? Email { get; set; }
        [Required]
        public string? Senha { get; set; }
    }

    public class LoginResponse
    {
        public string? Token { get; set; }
        public string? Nome { get; set; }
        public string? Role { get; set; }
    }
}

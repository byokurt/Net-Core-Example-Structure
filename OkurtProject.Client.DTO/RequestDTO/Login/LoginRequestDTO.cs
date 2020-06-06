using System.ComponentModel.DataAnnotations;

namespace OkurtProject.Client.DTO
{
    public class LoginRequestDTO
    {
        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        public bool RememberMe { get; set; }
    }
}

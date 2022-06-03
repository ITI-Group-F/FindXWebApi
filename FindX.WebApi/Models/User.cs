using System.ComponentModel.DataAnnotations;

namespace FindX.WebApi.Models
{
    public class User
    {
        [Required]
        public string Email { get; set; }
        [Required]
        public string PasswordHash { get; set; }
        [Required]
        public string role { get; set; }
    }
}

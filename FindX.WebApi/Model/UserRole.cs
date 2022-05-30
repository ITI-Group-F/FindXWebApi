using System.ComponentModel.DataAnnotations;

namespace FindX.WebApi.Model
{
    public class UserRole
    {
        [Required]
        public string RoleName { get; set; }
    }
}

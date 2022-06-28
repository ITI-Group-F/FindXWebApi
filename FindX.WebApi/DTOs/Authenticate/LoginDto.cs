using System.ComponentModel.DataAnnotations;

namespace FindX.WebApi.DTOs
{
	public class LoginDto
	{
		[EmailAddress]
		[Required]
		public string Email { get; set; }

		[Required]
		public string Password { get; set; }
	}
}

using System.ComponentModel.DataAnnotations;

namespace FindX.WebApi.DTOs
{
	public class LoginDto
	{
		[Required(ErrorMessage = "User Name is required")]
		public string Username { get; set; }

		[Required(ErrorMessage = "Password is required")]
		public string Password { get; set; }
	}
}

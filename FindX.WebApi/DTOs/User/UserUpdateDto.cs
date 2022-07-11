namespace FindX.WebApi.DTOs.User
{
    public class UserUpdateDto
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }
        public string CPassword { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
    }
}

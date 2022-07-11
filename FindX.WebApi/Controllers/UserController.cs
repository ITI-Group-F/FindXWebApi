using AutoMapper;
using FindX.WebApi.DTOs.User;
using FindX.WebApi.Helpers;
using FindX.WebApi.Repositories.IRepository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FindX.WebApi.Controllers
{
    [Authorize(Roles = "Admin,User")]
    [Route("api/[controller]")]
    [ApiController]    
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _usersRepository;
        private readonly IMapper _mapper;

        public UserController(IUserRepository UsersRepository, IMapper mapper)
        {
            _usersRepository = UsersRepository;
            _mapper = mapper;
        }
        [HttpPut]
        [Route("update")]
        public async Task<ActionResult<UserUpdateDto>> UpdateUserAsync([FromBody] UserUpdateDto UpdatedUser)
        {
            if (UpdatedUser.Password != UpdatedUser.Password) {
                return BadRequest("Passwords don't match !!");
            }
            if (string.IsNullOrEmpty(UpdatedUser.Email)) {
                return BadRequest("Email is empty !!");
            }
            if (string.IsNullOrEmpty(UpdatedUser.FirstName))
            {
                return BadRequest("FirstName is empty !!");
            }
            if (string.IsNullOrEmpty(UpdatedUser.LastName))
            {
                return BadRequest("LastName is empty !!");
            }
            if (string.IsNullOrEmpty(UpdatedUser.Phone))
            {
                return BadRequest("PhoneNumber is empty !!");
            }
            if (_usersRepository.CheckEmailAsync(UpdatedUser.Id, UpdatedUser.Email).Result)
            {
                return BadRequest("Email already exists !!");
            }
            else {                
               await _usersRepository.UpdateUserAsync(UpdatedUser);
                return Ok(UpdatedUser);
            }
            
        }
    }
    
}

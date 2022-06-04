using FindX.WebApi.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using FindX.WebApi.Repositories.IRepository;
using System.ComponentModel.DataAnnotations;

namespace FindX.WebApi.Controllers
{
    [Authorize(Roles = "Admin,User")]
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
       
        private IApplicationAuthenticateUserRepository _UserAuthenticate;
        private IUserRepository _UserRepository;
        public UserController(IApplicationAuthenticateUserRepository UserAuthenticate,
            IUserRepository UserRepository)
        {           
            _UserAuthenticate = UserAuthenticate;
            _UserRepository = UserRepository;
        }
        //for test
        [HttpGet]        
        public async Task<ActionResult> GetAll()
        {
            var users = await _UserRepository.GetAllUsers();
            if (users != null) {
                return Ok(users);            
            }
            return NotFound();
        }

     
        [AllowAnonymous]
        [HttpPost]
        [Route("login")]
        public async Task<ActionResult> LogIn(User user) {
            var token = await _UserAuthenticate.CheckLogIn(user);
            if (token == null)
            {
                return NotFound("Wrong username/email or password");
            }
            return Ok(token); 
        }


    }
}

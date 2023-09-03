using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ApplicationCore.Services.Interface;
using Domain.Entities;

namespace MemorialAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUsersService _usersService;
        public UsersController(IUsersService usersService)
        {
            _usersService = usersService;
        }

        [HttpPost]
        [Route("Users/CreateUser")]
        public async Task<IActionResult> CreateUser(Users user)
        {
            var userResponse = _usersService.CreateUser(user);
            return this.Ok();
        }

        [HttpPost]
        [Route("Login/CheckValidUser")]
        public async Task<IActionResult> CheckValidUser(Login loginRequest)
        {
            return this.BadRequest();
        }

    }
}

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ApplicationCore.Services.Interface;
using Domain.Entities;
using Domain.Exceptions;
using System.Net;
using System.Text;
using ApplicationCore.Extensions;

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
        [Route("CreateUser")]
        public async Task<IActionResult> CreateUser(Users user)
        {
            try
            {
                var userResponse = _usersService.CreateUser(user);
                if(userResponse.StatusCode == HttpStatusCode.Created)
                {
                    return this.Created("", userResponse.Data);
                }
                return this.Problem(userResponse.Message, null, (int)userResponse.StatusCode);

            }
            catch (DatabaseException ex)
            {
                return this.Problem(ex.Message, null, (int)HttpStatusCode.UnprocessableEntity);
            }
           
        }

        [HttpPost]
        [Route("CheckValidUser")]
        public async Task<IActionResult> CheckValidUser(Login loginRequest)
        {
            var response= _usersService.CheckValidUser(loginRequest);
            if(response.StatusCode != HttpStatusCode.OK)
            {
                return this.Problem(response.Message, null,(int)response.StatusCode);
            }
            var jwtToken = JWTTokenGenerate.GenerateJSONWebToken(response.Data);
            return Ok(new { token= jwtToken, response.Data });
        }   
    }
}

using Xunit;
using Moq;
using ApplicationCore.Services.Interface;
using MemorialAPI.Controllers;
using Microsoft.AspNetCore.Mvc;
using Domain.Entities;
using System.Security.Cryptography;
using Domain.Exceptions;
using Microsoft.AspNetCore.Http;

namespace MemorialAPITest.Controllers
{
    public class UsersControllerTest
    {
        private readonly Mock<IUsersService> _usersService;
        private readonly UsersController _controller;
        public UsersControllerTest() {
            _usersService= new Mock<IUsersService>();
            _controller = new UsersController(_usersService.Object);
        }

        [Fact]
        public async void CreateUser_Success()
        {
            ResponseResult<Users> response = new ResponseResult<Users>();
            response.Message = "Success";
            response.StatusCode = System.Net.HttpStatusCode.Created;
            response.Data = new Users { Name = "Manikandan" };
            _usersService.Setup(x=>x.CreateUser(It.IsAny<Users>())).Returns(response);
            var result = _controller.CreateUser(response.Data);
           // var responsed = await ExecuteHttpStatus(_controller, result.Result);
            Assert.IsType<CreatedResult>(result.Result);
        }


        [Fact]
        public void CreateUser_Error()
        {
            ResponseResult<Users> response = new ResponseResult<Users>();
            response.Message = "Success";
            response.StatusCode = System.Net.HttpStatusCode.BadRequest;
            response.Data = new Users { Name = "Manikandan" };
            _usersService.Setup(x => x.CreateUser(It.IsAny<Users>())).Returns(response);
            var result = _controller.CreateUser(response.Data);           
        }

        [Fact]
        public void CreateUser_Exception() 
        {
            ResponseResult<Users> response = new ResponseResult<Users>();
            response.Data = new Users { Name = "Manikandan" };
            _usersService.Setup(x => x.CreateUser(It.IsAny<Users>())).Throws(new DatabaseException());
            var result = _controller.CreateUser(response.Data);        
        }

        private static async Task<HttpResponse> ExecuteHttpStatus(UsersController controller,IActionResult actionResult)
        {
            await actionResult.ExecuteResultAsync(controller.ControllerContext);
            return controller.HttpContext.Response;
        }
    }
}

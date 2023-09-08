using System;
using System.Collections.Generic;
using System.Text;
using Domain.Entities;
namespace ApplicationCore.Services.Interface
{
   public interface IUsersService
    {
        ResponseResult<Users> CreateUser(Users user);
        ResponseResult<Users> CheckValidUser(Login login);
    }
}

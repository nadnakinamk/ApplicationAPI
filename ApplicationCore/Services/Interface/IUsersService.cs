using System;
using System.Collections.Generic;
using System.Text;
using Domain.Entities;
namespace ApplicationCore.Services.Interface
{
   public interface IUsersService
    {
        string CheckValidUser(Login login);
        string CreateUser(Users user);
    }
}

﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;

namespace Infrastructure.Repositories.Interface
{
    public interface IUsersRepository
    {
        ResponseResult<Users> CreateUser(Users user);
        ResponseResult<Users> CheckValidUser(Login login);
    }
}

using ApplicationCore.Services.Interface;
using Domain.Entities;
using Infrastructure.Repositories.Interface;
using Infrastructure.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Services.Implementation
{
    public class UsersService:IUsersService
    {
        private readonly IUsersRepository _usersRepository;

        public UsersService(IUsersRepository usersRepository)
        {
            _usersRepository = usersRepository;
        }
        public string CreateUser(Users user)
        {
            return _usersRepository.CreateUser(user);
        }
        public string CheckValidUser(Login login)
        {
            return _usersRepository.CheckValidUser(login);
        }
    }
}

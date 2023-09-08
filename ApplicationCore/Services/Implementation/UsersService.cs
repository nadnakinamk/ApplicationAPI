using ApplicationCore.Extensions;
using ApplicationCore.Services.Interface;
using Domain.Constant;
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
        public ResponseResult<Users> CreateUser(Users user)
        {
            user.Password= EncryptionDecryption.EncryptString(CommonData.cryptoKey, user.Password);
            var response= _usersRepository.CreateUser(user);
            response.Data.Password= EncryptionDecryption.DecryptString(CommonData.cryptoKey, response.Data.Password);
            return response;
        }
        public ResponseResult<Users> CheckValidUser(Login login)
        {
            login.Password = EncryptionDecryption.EncryptString(CommonData.cryptoKey, login.Password);
            return _usersRepository.CheckValidUser(login);
        }
    }
}

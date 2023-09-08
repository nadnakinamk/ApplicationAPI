using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using System.Data;
using System.Data.SqlClient;
using Domain.Entities;
using Infrastructure.Repositories.Interface;
using Domain.Exceptions;
using System.Net;
using Microsoft.Extensions.Primitives;
using Domain.Constant;
using static System.Net.Mime.MediaTypeNames;
using System.Security.Cryptography;

namespace Infrastructure.Repository
{

    public class UsersRepository : IUsersRepository
    {
        private IConfiguration _config;
        public UsersRepository(IConfiguration config)
        {
            _config = config;
        }

        public ResponseResult<Users> CheckValidUser(Login login)
        {
            
            List<Users> usersList = new List<Users>();
            DBConnection sc = new DBConnection(_config);
            sc.connect();
            SqlCommand cmd;
            cmd = new SqlCommand("Users_CheckCredential", sc.con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Username", login.UserName);
            cmd.Parameters.AddWithValue("@Password", login.Password);
            using (var reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    Users users = new Users();
                    users.UserId = Convert.ToInt32(reader["UserID"].ToString());
                    users.Name = reader["Name"].ToString();
                    users.Email = reader["EmailID"].ToString();
                    users.MobileNo = reader["MobileNo"].ToString();
                    usersList.Add(users);
                }
            }
            ResponseResult<Users> response = new ResponseResult<Users>(); 
            if(usersList.Count == 0)
            {
                response.StatusCode = HttpStatusCode.NotFound;
                response.Message = "User not Found!";
                response.Data = null;
                return response;

            }
            if (usersList.Count>1)
            {
                response.StatusCode = HttpStatusCode.Conflict;
                response.Message = "Multiple account found this user, contact admin";
                response.Data = null;
                return response;

            }
            response.StatusCode = HttpStatusCode.OK;
            response.Data = usersList[0];
            return response;
        }
        public ResponseResult<Users> CreateUser(Users usersRequest)
        {
            int resposeDb = 0;
            DBConnection sc = new DBConnection(_config);
            sc.connect();
            try
            {
                SqlCommand cmd;
                cmd = new SqlCommand("Users_CreateCredential", sc.con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@UserId", usersRequest.UserId);
                cmd.Parameters.AddWithValue("@Name", usersRequest.Name);
                cmd.Parameters.AddWithValue("@EmailID", usersRequest.Email);
                cmd.Parameters.AddWithValue("@MobileNo", usersRequest.MobileNo);
                cmd.Parameters.AddWithValue("@Password", usersRequest.Password);
                cmd.Parameters.AddWithValue("@IsActive", 1);
                cmd.Parameters.Add("@ReturnCode", SqlDbType.NVarChar, 500);
                cmd.Parameters["@ReturnCode"].Direction = ParameterDirection.Output;
                cmd.ExecuteNonQuery().ToString();
                resposeDb = Convert.ToInt32((string)cmd.Parameters["@ReturnCode"].Value);
                sc.disconnect();
                ResponseResult<Users> response = new ResponseResult<Users>();
                var (message, httpStatus) = ReturnHttpResult(resposeDb);
                response.Message = message;
                response.StatusCode = httpStatus;
                response.Data = usersRequest;
                response.Data.UserId = Convert.ToInt32(resposeDb);
                return response;
            }
            catch (Exception ex)
            {
                throw new DatabaseException(ex.Message);
            }
        }

        private static Tuple<string, HttpStatusCode> ReturnHttpResult(int resposeDb)
        {
            string message = "";
            HttpStatusCode httpStatusCode = HttpStatusCode.BadRequest;
            if (resposeDb > 0)
            {
                message = "Created Successfully!";
                httpStatusCode = HttpStatusCode.Created;
            }
            else if (resposeDb == 0)
            {
                message = "Created Failed!";
                httpStatusCode = HttpStatusCode.UnprocessableEntity;
            }
            else if (resposeDb == -1)
            {
                message = "Already Exists!";
                httpStatusCode = HttpStatusCode.Conflict;
            }
            return Tuple.Create(message, httpStatusCode);
        }
    }
}

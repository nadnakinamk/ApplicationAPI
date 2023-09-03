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

namespace Infrastructure.Repository
{
   
   public class UsersRepository:IUsersRepository
    {
        private IConfiguration _config;
        public UsersRepository(IConfiguration config)
        {
            _config = config;
        }

        public string CheckValidUser(Login login)
        { 
            string result = "";
            DBConnection sc = new DBConnection(_config);
            sc.connect();
            SqlCommand cmd;
            cmd = new SqlCommand("M_Users_Save", sc.con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@UserName", login.UserName);
            cmd.Parameters.AddWithValue("@Password", login.Password);
            cmd.Parameters.Add("@ReturnCode", SqlDbType.NVarChar, 500);
            cmd.Parameters["@ReturnCode"].Direction = ParameterDirection.Output;
            cmd.ExecuteNonQuery().ToString();
            result = (string)cmd.Parameters["@ReturnCode"].Value;
            sc.disconnect();
            return result;
        }
        public string CreateUser(Users users)
        {
            string result = "";
            DBConnection sc = new DBConnection(_config);
            sc.connect();
            SqlCommand cmd;
            cmd = new SqlCommand("Users_CreateCredential", sc.con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@UserId", users.UserId);
            cmd.Parameters.AddWithValue("@Name", users.Name);
            cmd.Parameters.AddWithValue("@EmailID", users.Email);
            cmd.Parameters.AddWithValue("@MobileNo", users.MobileNo);
            cmd.Parameters.AddWithValue("@Password", users.Password);
            cmd.Parameters.AddWithValue("@IsActive", 1);
            cmd.Parameters.Add("@ReturnCode", SqlDbType.NVarChar, 500);
            cmd.Parameters["@ReturnCode"].Direction = ParameterDirection.Output;
            cmd.ExecuteNonQuery().ToString();
            result = (string)cmd.Parameters["@ReturnCode"].Value;
            sc.disconnect();
            return result;
        }

    }
}

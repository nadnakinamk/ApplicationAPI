using Domain.Constant;
using Domain.Entities;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace ApplicationCore.Extensions
{
    public static class JWTTokenGenerate
    {
        public static string GenerateJSONWebToken(Users user)
        {
            // generate token that is valid for 7 days
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(CommonData.jwtKey));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(CommonData.jwtIssuer,
             CommonData.jwtIssuer,
              null,
              expires: DateTime.Now.AddMinutes(120),
              signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}

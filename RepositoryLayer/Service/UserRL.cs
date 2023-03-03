using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using ModelLayer.Service;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace RepositoryLayer.Service
{
    public class UserRL :IUserRL
    {
        private readonly IConfiguration iconfiguration;

        public UserRL(IConfiguration iconfiguration)
        {
            this.iconfiguration = iconfiguration;
        }

        public UserModel UserRegi(UserModel userModel)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(this.iconfiguration.GetConnectionString("EmployeeDBMVC")))
                {
                    SqlCommand cmd = new SqlCommand("spRegister", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@Firstname", userModel.Firstname);
                    cmd.Parameters.AddWithValue("@Lastname", userModel.Lastname);
                    cmd.Parameters.AddWithValue("@Email", userModel.Email);
                    cmd.Parameters.AddWithValue("@Password", userModel.Password);

                    con.Open(); 
                    var result = cmd.ExecuteNonQuery();
                    if (result == 1)
                    {
                        return userModel;
                    }
                    else
                    {
                        return null;
                    }

                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public UserModel Login(UserModel userModel)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(this.iconfiguration.GetConnectionString("EmployeeDBMVC")))
                {
                    SqlCommand cmd = new SqlCommand("Login", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@EmailId", userModel.Email);
                    cmd.Parameters.AddWithValue("@Password", userModel.Password);
                    //cmd.Parameters.AddWithValue("@UserId", userModel.UserId);


                    con.Open();
                    var result = cmd.ExecuteNonQuery();
                    if (result == 1)
                    {
                        return userModel;
                    }
                    else
                    {
                        return null;
                    }
                }
            }
            catch(Exception ex)
            {
                throw;
            }
        }
        /*
        //JWT token
        public string GenerateSecurityToken(string email, string UserId)
        {

            try
            {
                var tokenHandler = new JwtSecurityTokenHandler();
                var key = Encoding.ASCII.GetBytes(this.iConfiguration[("JWT:Key")]);
                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new[]
                    {
                       new Claim(ClaimTypes.Role, "Users"),
                        new Claim(ClaimTypes.Email, email),
                        new Claim("UserId", UserId.ToString())
                }),
                    Expires = DateTime.UtcNow.AddMinutes(30),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
                };

                var token = tokenHandler.CreateToken(tokenDescriptor);

                return tokenHandler.WriteToken(token);
            }
            catch (Exception ex)
            {
                throw;
            }
        }*/
    }
}

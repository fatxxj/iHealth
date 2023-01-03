using iHealthAPI.Data;
using iHealthAPI.Models;
using Microsoft.EntityFrameworkCore;
using System.Text;
using System.Security.Cryptography;
using iHealthAPI.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using static iHealthAPI.Models.User;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;

namespace iHealthAPI.Services
{
    public class ReusableMethods : IReusableMethods
    {
        private readonly IConfiguration configuration;
        private readonly AppDbContext dbContext;

        public ReusableMethods(AppDbContext dbContext, IConfiguration configuration)
        {
            this.dbContext = dbContext;
            this.configuration = configuration;
        }

        public string HashString(string str)
        {
            if (str != null)
            {
                var message = Encoding.Unicode.GetBytes(str);
                var hash = new SHA256Managed();

                var hashValue = hash.ComputeHash(message);

                return Encoding.Unicode.GetString(hashValue);
            }
            return null;
        }

        public async Task<IActionResult> Authenticate(Login login)
        {

            var user = await dbContext.User.Where(x => x.Email == login.Email).FirstOrDefaultAsync();
            if (user != null)
            {
                var userAuthenticated = await dbContext.User.Where(x => x.Email == login.Email && x.Password == HashString(login.Password)).FirstOrDefaultAsync();
                if (userAuthenticated != null)
                {
                    return new JsonResult(new { message = "Successful authentication", statuscode = 200, user });

                }
                return null;

            }
            return null;
        }


        public int? ValidateToken(string token)
        {
            if (token == null)
                return null;

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(this.configuration.GetValue<string>("Jwt:Key"));
            try
            {
                tokenHandler.ValidateToken(token, new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    // set clockskew to zero so tokens expire exactly at token expiration time (instead of 5 minutes later)
                    ClockSkew = TimeSpan.Zero
                }, out SecurityToken validatedToken);

                var jwtToken = (JwtSecurityToken)validatedToken;
                var userId = int.Parse(jwtToken.Claims.First(x => x.Type == "id").Value);

                return userId;
            }
            catch
            {
                return null;
            }


        }
    }
}


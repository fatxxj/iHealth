using iHealthAPI.Data;
using iHealthAPI.Models;
using Microsoft.EntityFrameworkCore;
using System.Text;
using System.Security.Cryptography;
using iHealthAPI.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using static iHealthAPI.Models.User;

namespace iHealthAPI.Services
{
    public class ReusableMethods :IReusableMethods
    {
        private readonly AppDbContext dbContext;

        public ReusableMethods(AppDbContext dbContext)
        {
            this.dbContext = dbContext;
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
                if(userAuthenticated!=null)
                {
                    return new JsonResult(new {message="Successful authentication" ,statuscode = 200, user });

                }
                return null;
                
            }
            return null;
        }

        
    }
}

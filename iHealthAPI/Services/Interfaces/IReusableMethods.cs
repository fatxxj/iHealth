using iHealthAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace iHealthAPI.Services.Interfaces
{
    public interface IReusableMethods
    {
         public Task<IActionResult> Authenticate(Login login);
         string HashString(string str);

        public int? ValidateToken(string token);
    }
}

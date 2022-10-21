using iHealthAPI.Data;
using iHealthAPI.Models;
using iHealthAPI.Services;
using iHealthAPI.Services.Interfaces;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Net.Http.Headers;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace iHealthAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UsersController : Controller
    {
        private readonly AppDbContext dbContext;
        private readonly IReusableMethods reusable;
        private readonly IConfiguration configuration;
        private readonly HttpContext context;

        public UsersController(AppDbContext dbContext, IReusableMethods reusable, IConfiguration configuration)
        {
            this.dbContext = dbContext;
            this.reusable = reusable;
            this.configuration = configuration;
        }

        public bool CheckToken()
        {
            var token = context.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();
            var userId = reusable.ValidateToken(token);
            if(userId!=null)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        public string GenerateToken(User user)
        {
            // generate token that is valid for 7 days
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(this.configuration.GetValue<string>("Jwt:Key"));
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[] { new Claim("id", user.Id.ToString()) }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

        // Create user method for the first person tha creates clinic
        [HttpPost]
        public async Task<IActionResult> CreateUser(User newUser)
        {
            var emailExists = dbContext.User.Where(x => x.Email == newUser.Email).FirstOrDefault();
            if (emailExists == null)
            {
                var user = new User
                {
                    Name = newUser.Name,
                    Email = newUser.Email,
                    Surname = newUser.Surname,
                    Password = reusable.HashString(newUser.Password)
                };
                await dbContext.User.AddAsync(user);
                await dbContext.SaveChangesAsync();
                var token = GenerateToken(user);
                user.Token = token;
                await dbContext.SaveChangesAsync();
                var result = new OkObjectResult(new { message = "Status code 200. User is created successfully!", user = user });
                return result;
            }
            else
            {
                return BadRequest("User with this email already exists");
            }
        }

        // Get method for user page
        [HttpGet]
        public async Task<IActionResult> GetUser(int id)
        {
            var user = await dbContext.User.Where(x => x.Id == id).FirstOrDefaultAsync();
            if (user != null)
            {
                var result = new OkObjectResult(new { user = user });
                return result;
            }
            return NotFound("User is not found");
        }

        //Update User method when user wants to update his basic information such as name surname
        [HttpPost]
        public async Task<IActionResult> UpdatePersonalInformation(int id, UserPersonalInfo updateUser)
        {
            var existingUser = await dbContext.User.Where(x => x.Id == id).FirstOrDefaultAsync();
            if (existingUser != null)
            {
                existingUser.Name = updateUser.Name;
                existingUser.Surname = updateUser.Surname;

                await dbContext.SaveChangesAsync();
                return Ok(existingUser);
            }
            return NotFound("User is not found!");
        }

        //Change password if user knows old password
        [HttpPost]
        public async Task<IActionResult> ChangePassword(int id, ChangePassword changePassword)
        {
            var existingUser = await dbContext.User.Where(x => x.Id == id).FirstOrDefaultAsync();
            if (existingUser != null)
            {
                if (existingUser.Password == reusable.HashString(changePassword.OldPassword))
                {
                    existingUser.Password = reusable.HashString(changePassword.NewPassword);
                    await dbContext.SaveChangesAsync();
                    return Ok(existingUser);
                }
                return NotFound("The passwords do not match!");
            }
            return NotFound("User is not found!");
        }

        //TODO: Change password with email , like forgot password

        // Change email method to change email if user knows old email and current Password
        [HttpPost]
        public async Task<IActionResult> ChangeEmail(int id, ChangeEmail changeEmail)
        {
            var existingUser = await dbContext.User.Where(x => x.Id == id).FirstOrDefaultAsync();
            if (existingUser != null)
            {
                if (changeEmail.OldEmail == existingUser.Email)
                {
                    if (existingUser.Password == reusable.HashString(changeEmail.Password))
                    {
                        existingUser.Email = changeEmail.NewEmail;
                        await dbContext.SaveChangesAsync();
                        return Ok("Email changed successfully!");
                    }
                    return NotFound("Incorrect password!");
                }
                return NotFound("The emails do not match!");
            }
            return NotFound("User is not found!");
        }

        [HttpPost]
        public async Task<IActionResult> Login(Login login)
        {
            var token = Request.Headers["Authorization"].FirstOrDefault()?.Split(".").Last();
            
            var existingUser = await dbContext.User.Where(x => x.Email == login.Email).FirstOrDefaultAsync();
            if (existingUser != null)
            {
                if(existingUser.Id ==reusable.ValidateToken(token))
                {
                    return NotFound();
                }
                var logInUser = await reusable.Authenticate(login);
                return Ok(logInUser);
            }
            return NotFound("Email is not existing!");
        }

        //TODO: Log out method
    }
}

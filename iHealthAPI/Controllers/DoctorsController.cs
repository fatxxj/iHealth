using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using iHealthAPI.Data;
using iHealthAPI.Models;
using iHealthAPI.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace iHealthAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class DoctorsController : Controller
    {
        // GET
        private readonly AppDbContext dbContext;
        private readonly IReusableMethods reusable;
        private readonly IConfiguration configuration;
        private readonly HttpContext context;

        public DoctorsController(AppDbContext dbContext, IReusableMethods reusable, IConfiguration configuration)
        {
            this.dbContext = dbContext;
            this.reusable = reusable;
            this.configuration = configuration;
        }

        [HttpPost]
        public string GenerateToken(Doctor doctor)
        {
            // generate token that is valid for 7 days
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(this.configuration.GetValue<string>("Jwt:Key"));
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[] { new Claim("id", doctor.Id.ToString()) }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key),
                    SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

        [HttpPost]
        public async Task<IActionResult> CreateDoctor(Doctor newDoctor)
        {
            var emailExists = dbContext.Doctor.Where(x => x.Email == newDoctor.Email).FirstOrDefault();
            if (emailExists == null)
            {
                var doctor = new Doctor
                {
                    Name = newDoctor.Name,
                    Surname = newDoctor.Surname,
                    Email = newDoctor.Email,
                    Gender = newDoctor.Gender,
                    BirthDate = newDoctor.BirthDate,
                    PhoneNumber = newDoctor.PhoneNumber,
                    Faksimil = newDoctor.Faksimil,
                    Image = newDoctor.Image,
                    WorkerId = newDoctor.WorkerId

                };
                await dbContext.Doctor.AddAsync(doctor);
                await dbContext.SaveChangesAsync();
                var token = GenerateToken(doctor);
                doctor.Token = token;
                await dbContext.SaveChangesAsync();
                var result = new OkObjectResult(new
                    { message = "Status code 200. User is created successfully!", user = doctor });
                return result;
            }
            else
            {
                return BadRequest("Doctor with this email already exists");
            }
        }
    }
}
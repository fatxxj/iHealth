using iHealthAPI.Data;
using iHealthAPI.Models;
using iHealthAPI.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace iHealthAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ClinicsController : ControllerBase
    {
        private readonly AppDbContext dbContext;
        private readonly IReusableMethods reusable;

        public ClinicsController(AppDbContext dbContext, IReusableMethods reusable)
        {
            this.dbContext = dbContext;
            this.reusable = reusable;
        }

        [HttpPost]
        public IActionResult CreateClinic(Clinic newClinic)
        {
            var clinic = new Clinic
            {
                Name = newClinic.Name,
                PlaceId = newClinic.PlaceId,
                Email = newClinic.Email,
                PhoneNumber = newClinic.PhoneNumber,
                RegistrationNo = newClinic.RegistrationNo,
                ClinicType = newClinic.ClinicType,
                ClinicTypeString = newClinic.ClinicTypeString.ToString(),
                UserId = newClinic.UserId,
            };
            dbContext.Add(clinic);
            dbContext.SaveChanges();
            var result = new OkObjectResult(
                new
                {
                    message = "Status code 200. Clinic is created successfully!",
                    clinicId = clinic.Id
                }
            );
            return result;
        }

        [HttpGet]
        public IActionResult GetClinic(int Id)
        {
            var existingClinic = dbContext.Clinic.Where(x => x.Id == Id).FirstOrDefault();
            if (existingClinic != null)
            {
                var result = new ObjectResult(new { StatusCode = 200, clinic = existingClinic });
                return result;
            }
            return NotFound("The clinic is not found!");
        }

        [HttpPost]
        public IActionResult UpdateClinic(int Id, Clinic editClinic)
        {
            var existingClinic = dbContext.Clinic.Where(x => x.Id == Id).FirstOrDefault();
            if (existingClinic != null)
            {
                existingClinic.Name = editClinic.Name;
                existingClinic.PlaceId = editClinic.PlaceId;
                existingClinic.Email = editClinic.Email;
                existingClinic.PhoneNumber = editClinic.PhoneNumber;
                existingClinic.RegistrationNo = editClinic.RegistrationNo;
                existingClinic.ClinicType = editClinic.ClinicType;
                existingClinic.ClinicTypeString = editClinic.ClinicType.ToString();
                existingClinic.UserId = editClinic.UserId;

                dbContext.SaveChanges();
                var result = new ObjectResult(new { StatusCode = 200, clinic = existingClinic });
                return result;
            }
            return NotFound("The clinic is not found!");
        }
    }
}

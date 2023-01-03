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
        private readonly IHostEnvironment hostingEnvironment;

        public ClinicsController(AppDbContext dbContext, IReusableMethods reusable, IHostEnvironment hostingEnvironment)
        {
            this.dbContext = dbContext;
            this.reusable = reusable;
            this.hostingEnvironment = hostingEnvironment;
        }

        [HttpPost]
        public async Task<IActionResult> CreateClinicAsync(Clinic newClinic)
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
            var files = HttpContext.Request.Form.Files;
            if (files.Count != 0)
            {
                foreach (var Image in files)
                {
                    var file = Image;
                    string webRootPath = hostingEnvironment.ContentRootPath;
                    if (file.Length > 0)
                    {
                        var newFileName = Image.FileName;
                        if (!Directory.Exists(Path.Combine(webRootPath, "Images", "CompanyLogos")))
                        {
                            Directory.CreateDirectory(Path.Combine(webRootPath, "Images", "CompanyLogos"));
                        }
                        if (System.IO.File.Exists(Path.Combine(webRootPath, "Images", "CompanyLogos", newFileName)))
                        {
                            newFileName = Guid.NewGuid() + newFileName;
                        }
                        using (var filestream = new FileStream(Path.Combine(webRootPath, "Images", "CompanyLogos", newFileName), FileMode.Create))
                        {
                            await file.CopyToAsync(filestream);
                            clinic.Image = newFileName;
                        }
                    }
                }
            }
            else
            {
                clinic.Image = "Logo-Placehoder.png";
            }
            dbContext.Add(clinic);
            dbContext.SaveChanges();
            var result = new OkObjectResult(new { message = "Status code 200. Clinic is created successfully!", clinicId = clinic.Id });
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
        public async Task<IActionResult> UpdateClinic(int Id, UpdateClinicModel updateClinic)
        {
            var existingClinic = dbContext.Clinic.Where(x => x.Id == Id).FirstOrDefault();
            if (existingClinic != null)
            {
                existingClinic.Name = updateClinic.Name;
                existingClinic.PlaceId = updateClinic.PlaceId;
                existingClinic.Email = updateClinic.Email;
                existingClinic.PhoneNumber = updateClinic.PhoneNumber;
                existingClinic.RegistrationNo = updateClinic.RegistrationNo;
                existingClinic.Image = updateClinic.Image;
                existingClinic.ClinicType = updateClinic.ClinicType;
                existingClinic.ClinicTypeString = updateClinic.ClinicType.ToString();

                var files = HttpContext.Request.Form.Files;
                if (files.Count != 0)
                {
                    foreach (var Image in files)
                    {
                        var file = Image;
                        string webRootPath = hostingEnvironment.ContentRootPath;
                        if (file.Length > 0)
                        {
                            var newFileName = Image.FileName;
                            if (!Directory.Exists(Path.Combine(webRootPath, "Images", "CompanyLogos")))
                            {
                                Directory.CreateDirectory(Path.Combine(webRootPath, "Images", "CompanyLogos"));
                            }
                            if (System.IO.File.Exists(Path.Combine(webRootPath, "Images", "CompanyLogos", newFileName)))
                            {
                                newFileName = Guid.NewGuid() + newFileName;
                            }
                            using (var filestream = new FileStream(Path.Combine(webRootPath, "Images", "CompanyLogos", newFileName), FileMode.Create))
                            {
                                await file.CopyToAsync(filestream);
                                existingClinic.Image = newFileName;
                            }
                        }
                    }
                }
                else
                {
                    existingClinic.Image = "Logo-Placehoder.png";
                }

                dbContext.SaveChanges();
                var result = new ObjectResult(new { StatusCode = 200, clinic = existingClinic });
                return result;
            }
            return NotFound("The clinic is not found!");
        }
    }
}

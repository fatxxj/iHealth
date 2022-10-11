using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using iHealthAPI.Data;
using iHealthAPI.Models;
using iHealthAPI.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace iHealthAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class PatientsController : ControllerBase
    {
        private readonly AppDbContext dbContext;
        private readonly IHostEnvironment hostingEnvironment;

        public PatientsController(AppDbContext dbContext, IHostEnvironment hostingEnvironment)
        {
            this.dbContext = dbContext;
            this.hostingEnvironment = hostingEnvironment;
        }

        [HttpPost]
        public IActionResult CreatePatient(Patient patient)
        {
            if (ModelState.IsValid)
            {
                var newPatient = new Patient
                {
                    Name = patient.Name,
                    Surname = patient.Surname,
                    EMBG = patient.EMBG,
                    Gender = patient.Gender,
                    BirthDate = patient.BirthDate,
                    PlaceId = patient.PlaceId,
                    PhoneNumber = patient.PhoneNumber,
                    Email = patient.Email,
                    ClinicId = patient.ClinicId,
                    DoctorId = patient.DoctorId
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
                            if (!Directory.Exists(Path.Combine(webRootPath, "Images", "PatientImages")))
                            {
                                Directory.CreateDirectory(Path.Combine(webRootPath, "Images", "PatientImages"));
                            }
                            if (System.IO.File.Exists(Path.Combine(webRootPath, "Images", "PatientImages", newFileName)))
                            {
                                newFileName = Guid.NewGuid() + newFileName;
                            }
                            using (var filestream = new FileStream(Path.Combine(webRootPath, "Images", "CompanyLogos", newFileName), FileMode.Create))
                            {
                                file.CopyToAsync(filestream);
                                newPatient.Image = newFileName;
                            }
                        }
                    }
                }
                else
                {
                    newPatient.Image = "Logo-Placehoder.png";
                }
                dbContext.Add(newPatient);
                dbContext.SaveChanges();
                var result = new ObjectResult(new { StatusCode = 200, message = "Patient is created successfully!", patient = patient });
                return result;
            }
            else
            {
                var result = new ObjectResult(new { StatusCode = 400, message = "The model is invalid!" });
                return result;
            }
        }

        [HttpGet]
        public IActionResult GetPatient(int Id)
        {
            var existingPatient = dbContext.Patient.Where(x => x.Id == Id).FirstOrDefault();
            if (existingPatient != null)
            {
                var result = new ObjectResult(new { StatusCode = 200, patient = existingPatient });
                return result;
            }
            else
            {
                return NotFound("The patient is not found!");
            }
        }

        [HttpPost]
        public IActionResult UpdatePatient(int Id, UpdatePatient updatePatient)
        {
            var existingPatient = dbContext.Patient.Where(x => x.Id == Id).FirstOrDefault();
            if (existingPatient != null)
            {
                existingPatient.Name = updatePatient.Name;
                existingPatient.Surname = updatePatient.Surname;
                existingPatient.EMBG = updatePatient.EMBG;
                existingPatient.Gender = updatePatient.Gender;
                existingPatient.BirthDate = updatePatient.BirthDate;
                existingPatient.PlaceId = updatePatient.PlaceId;
                existingPatient.PhoneNumber = updatePatient.PhoneNumber;
                existingPatient.Email = updatePatient.Email;
                existingPatient.DoctorId = updatePatient.DoctorId;

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
                            if (!Directory.Exists(Path.Combine(webRootPath, "Images", "PatientImages")))
                            {
                                Directory.CreateDirectory(Path.Combine(webRootPath, "Images", "PatientImages"));
                            }
                            if (System.IO.File.Exists(Path.Combine(webRootPath, "Images", "PatientImages", newFileName)))
                            {
                                newFileName = Guid.NewGuid() + newFileName;
                            }
                            using (var filestream = new FileStream(Path.Combine(webRootPath, "Images", "CompanyLogos", newFileName), FileMode.Create))
                            {
                                file.CopyToAsync(filestream);
                                existingPatient.Image = newFileName;
                            }
                        }
                    }
                }
                else
                {
                    existingPatient.Image = "Logo-Placehoder.png";
                }

                dbContext.SaveChanges();
                var result = new ObjectResult(new { StatusCode = 200, message = "Patient is edited successfully", patient = existingPatient });
                return result;
            }
            else
                return NotFound("Patient is not found!");
        }

        [HttpPost]
        public IActionResult DeletePatient(int Id)
        {
            var existingPatient = dbContext.Patient.Where(x => x.Id == Id).FirstOrDefault();
            if (existingPatient != null)
            {
                existingPatient.IsDeleted = true;
                dbContext.SaveChanges();
                return Ok("Patient is deleted successfully!");
            }
            else
                return NotFound("Patient is not found! Deletion failed!");
        }
    }
}

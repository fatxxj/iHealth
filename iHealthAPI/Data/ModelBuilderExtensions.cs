using iHealthAPI.Services;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;
using System.Text;
using System.Security.Cryptography;
using iHealthAPI.Models;
using ihealthapi.Models;

public static class ModelBuilderExtensions
{
    public static void Seed(this ModelBuilder modelBuilder)
    {
        string? HashString(string str)
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

        modelBuilder
            .Entity<Place>()
            .HasData(
                new Place
                {
                    Id = 1,
                    CityName = "Demo City",
                    Address = "Demo Address",
                    ZipCode = "Demo ZipCode",
                    CountyName = "Demo Country",
                    Region = "Demo Region",
                    MapsLink = "https://www.google.com/maps",
                    Latitude = "12.200",
                    Longitude = "12.200",
                    WorkerId = 1,
                    ClinicId = 1,
                    PatientId = 1,
                    UserId = 1
                }
            );

        modelBuilder
            .Entity<User>()
            .HasData(
                new User
                {
                    Id = 1,
                    Name = "Fat Main User",
                    Surname = "Halimi ",
                    Email = "halimifat@gmail.com",
                    Password = HashString("UserPassword "),
                    PlaceId = 1,
                    ClinicId = 1
                }
            );

        modelBuilder
            .Entity<Clinic>()
            .HasData(
                new Clinic
                {
                    Id = 1,
                    Name = "First Demo Clinic",
                    Email = "halimifat@gmail.com",
                    ClinicType = ClinicTypeEnum.GeneralPurposeClinic,
                    ClinicTypeString = ClinicTypeEnum.GeneralPurposeClinic.ToString(),
                    PhoneNumber = "070224560",
                    PlaceId = 1,
                    RegistrationNo = "0012343",
                    UserId = 1,
                    Image = "DemoClinic.png",
                    PatientId = 1,
                    WorkerId = 1
                }
            );

        modelBuilder
            .Entity<Patient>()
            .HasData(
                new Patient
                {
                    Id = 1,
                    Name = "Patient Fat",
                    Surname = "Patient Halimi",
                    Email = "halimifat@gmail.com",
                    PhoneNumber = "070224560",
                    PlaceId = 1,
                    EMBG = "0012343",
                    Gender = "Male",
                    BirthDate = new DateTime(2020, 1, 1),
                    ClinicId = 1,
                    Image = "DemoClinic.png",
                    IsDeleted = false,
                    WorkerId = 1
                }
            );
        modelBuilder
            .Entity<Doctor>()
            .HasData(
                new Doctor
                {
                    Id = 1,
                    Name = "Doctor Fat",
                    Surname = "Doctor Halimi",
                    Email = "halimifat@gmail.com",
                    PhoneNumber = "070224560",
                    Faksimil = "0012343",
                    Gender = "Male",
                    BirthDate = new DateTime(2020, 1, 1),
                    WorkerId = 1,
                    Image = "DemoClinic.png"
                }
            );

        modelBuilder
            .Entity<Worker>()
            .HasData(
                new Worker
                {
                    Id = 1,
                    DoctorId = 1,
                    ClinicId = 1,
                    Salary = 32000,
                    Bonuses = 300,
                    PatientId = 1,
                    WorkingDayAndStartTime = new DateTime(2020, 1, 1, 12, 10, 0),
                    WorkingDayAndEndTime = new DateTime(2020, 1, 1, 13, 10, 0),
                    IsDeleted = false,
                    IsEmployee = true,
                    NurseId = 1,
                    OtherStaffId = 1
                }
            );

        modelBuilder
            .Entity<Nurse>()
            .HasData(
                new Nurse
                {
                    Id = 1,
                    Name = "DemoNurse",
                    Surname = "DemoNurseSurname",
                    BirthDate = new DateTime(2020, 1, 1, 12, 10, 0),
                    Speciallity = "Orthodont",
                    Gender = "Female",
                    WorkerId = 1
                }
            );

        modelBuilder
            .Entity<OtherStaff>()
            .HasData(
                new OtherStaff
                {
                    Id = 1,
                    Name = "OtherStaffName",
                    Surname = "OtherStaffSurname",
                    BirthDate = new DateTime(2020, 1, 1, 12, 10, 0),
                    WorkingDescription = "Hygienist",
                    Gender = "Female",
                    WorkerId = 1
                }
            );
    }
}

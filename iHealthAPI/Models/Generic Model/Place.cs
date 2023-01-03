using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ihealthapi.Models;

namespace iHealthAPI.Models
{
    public class Place
    {
        [Key]
        [Required]
        public int Id { get; set; }

        public string CityName { get; set; }
        public string Address { get; set; }
        public string ZipCode { get; set; }
        public string CountyName { get; set; }
        public string Region { get; set; }
        public string? MapsLink { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }

        //Foreign Keys
        public int WorkerId { get; set; }
        public int ClinicId { get; set; }
        public int PatientId { get; set; }

        [ForeignKey("User")]
        public int UserId { get; set; }

        //Referenced Tables
        public virtual ICollection<Worker>? Workers { get; set; }
        public virtual ICollection<Clinic>? Clinics { get; set; }
        public virtual ICollection<Patient>? Patients { get; set; }
        public virtual User? User { get; set; }
    }
}

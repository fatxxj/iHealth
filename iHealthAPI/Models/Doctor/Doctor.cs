using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace iHealthAPI.Models
{
    public class Doctor
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Surname { get; set; }

        [Required]
        public string Gender { get; set; }

        [Required]
        public string BirthDate { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string PhoneNumber { get; set; }

        [Required]
        public string Faksimil { get; set; }

        public string Image { get; set; }

        //Table references below ⤵

        //TODO: Link JOBS

        public int? PlaceId { get; set; }
        public int? ClinicId { get; set; }

        public int? PatientId { get; set; }

        public virtual Place? Place { get; set; }
        public virtual Clinic? Clinic { get; set; }

        public virtual ICollection<Patient>? Patients { get; set; }
    }
}

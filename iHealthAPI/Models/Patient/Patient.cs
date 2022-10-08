using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace iHealthAPI.Models
{
    public class Patient
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Surname { get; set; }

        public string EMBG { get; set; }

        public string Image { get; set; }

        public string Gender { get; set; }

        public string BirthDate { get; set; }

        public string PhoneNumber { get; set; }

        public string Email { get; set; }

        public int? PlaceId { get; set; }

        // [Required]
        // public int? DoctorId { get; set; }

        [Required]
        public int ClinicId { get; set; }

        public virtual Place Place { get; set; }

        //TODO: Link doctor
        public virtual Clinic Clinic { get; set; }
    }
}

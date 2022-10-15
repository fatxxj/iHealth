using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ihealthapi.Models;

namespace iHealthAPI.Models
{
    public class Clinic
    {
        [Key]
        [Display(Name = "Id")]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Name")]
        public string Name { get; set; }

        [Display(Name = "Email")]
        public string Email { get; set; }

        [Display(Name = "PhoneNumber")]
        public string PhoneNumber { get; set; }

        [Required]
        [Display(Name = "RegistrationNo")]
        public string RegistrationNo { get; set; }

        [Required]
        [Display(Name = "ClinicTypeEnum")]
        public ClinicTypeEnum ClinicType { get; set; }

        [Display(Name = "ClinicTypeString")]
        public string ClinicTypeString { get; set; }

        [Display(Name = "Image")]
        public string Image { get; set; }

        //Reference Tables

        //Foreign Keys
        [Required]
        public int UserId { get; set; }

        public int? PlaceId { get; set; }

        public int? PatientId { get; set; }
        public int? WorkerId { get; set; }

        //Referenced tables
        public virtual User? User { get; set; }
        public virtual Place? Place { get; set; }
        public virtual ICollection<Patient>? Patients { get; set; }

        public virtual ICollection<Worker>? Workers { get; set; }

        //TODO: Link Finances after creating finances
        //TODO: Link Archive after creating archive
        //TODO: Link Storage after creating storage
    }
}

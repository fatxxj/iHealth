using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace iHealthAPI.Models
{
    public class User
    {
        [Key]
        [Display(Name = "Id")]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Name")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Surname")]
        public string Surname { get; set; }

        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        public int? PlaceId { get; set; }

        [Display(Name = "ClinicId")]
        public int ClinicId { get; set; }

        public string? Token { get; set; }

        public virtual ICollection<Clinic>? Clinics { get; set; }
        public virtual Place? Place { get; set; }
    }
}

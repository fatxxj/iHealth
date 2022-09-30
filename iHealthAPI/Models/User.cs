using System.ComponentModel.DataAnnotations;

namespace iHealthAPI.Models
{
    public class User
    {
        [Key]
        [Required]
        [Display(Name = "Id")]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Name")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Surname")]
        public string Surname { get; set; }

        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [Display(Name = "ClinicId")]
        public int ClinicId { get; set; }

        public virtual ICollection<Clinic> Clinics { get; set; }
    }
}

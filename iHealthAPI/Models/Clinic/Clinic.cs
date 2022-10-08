using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace iHealthAPI.Models
{
    public class Clinic
    {
        [Key]
        [Required]
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

        [Required]
        [Display(Name = "UserId")]
        public int UserId { get; set; }

        [Display(Name = "PlaceId")]
        public int? PlaceId { get; set; }

        [Display(Name = "User")]
        public virtual User User { get; set; }

        [Display(Name = "Place")]
        public virtual Place Place { get; set; }

        //TODO: Link Worker after creating worker
        //TODO: Link Finances after creating finances
        //TODO: Link Archive after creating archive
        //TODO: Link Storage after creating storage
    }
}

using System.ComponentModel.DataAnnotations;

namespace iHealthAPI.Models
{
    public class UserPersonalInfo
    {
        [Required]
        [Display(Name = "Name")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Username")]
        public string Surname { get; set; }
    }
}

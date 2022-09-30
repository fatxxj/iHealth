
using System.ComponentModel.DataAnnotations;

namespace iHealthAPI.Models
{
    public class Contact
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [Display(Name = "FullName")]
        public string FullName { get; set; }

        [Display(Name = "Email")]
        public string Email { get; set; }

        [Display(Name = "Phone")]
        public long Phone { get; set; }

        [Display(Name = "Address")]
        public string Address { get;set; }
       
    }
}

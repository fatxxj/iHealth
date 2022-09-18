using System.ComponentModel.DataAnnotations;

namespace iHealthAPI.Models.User
{
    public class UserPersonalInfo
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string Surname { get; set; }
    }
}

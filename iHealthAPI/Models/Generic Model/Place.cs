using System.ComponentModel.DataAnnotations;

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


    }
}

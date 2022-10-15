using System.ComponentModel.DataAnnotations;
using ihealthapi.Models;

namespace iHealthAPI.Models
{
    public class Nurse
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime? BirthDate { get; set; }
        public string? Speciallity { get; set; }

        //Refrence tables
        //Foregin Keys
        public int WorkerId { get; set; }

        //link job foreign key

        //Referenced Tables
        public virtual Worker Worker { get; set; }
        // link job
    }
}

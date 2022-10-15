using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using ihealthapi.Models;

namespace iHealthAPI.Models
{
    public class Doctor
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Surname { get; set; }

        [Required]
        public string Gender { get; set; }

        [Required]
        public string BirthDate { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string PhoneNumber { get; set; }

        [Required]
        public string Faksimil { get; set; }

        public string Image { get; set; }

        //Table references below ⤵

        //TODO: Link JOBS

        //Foregin keys
        public int? PlaceId { get; set; }
        public int? WorkerId { get; set; }

        //Referenced tables

        public virtual Place? Place { get; set; }

        public virtual Worker? Worker { get; set; }
    }
}

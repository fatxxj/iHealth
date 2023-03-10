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
        public DateTime BirthDate { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string PhoneNumber { get; set; }

        [Required]
        public string Faksimil { get; set; }

        public string? Image { get; set; }
        
        public string? Token { get; set; }

        //Table references below ⤵

        //TODO: Link JOBS

        //Foregin keys
        public int? WorkerId { get; set; }

        //Referenced tables


        public virtual Worker? Worker { get; set; }
    }
}

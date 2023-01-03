using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using ihealthapi.Models;

namespace iHealthAPI.Models
{
    public class OtherStaff
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime BirthDate { get; set; }
        public string WorkingDescription { get; set; }
        public string Gender { get; set; }

        //Foregin Keys
        public int WorkerId { get; set; }

        //Referebced Tabkes
        public virtual Worker? Worker { get; set; }
    }
}

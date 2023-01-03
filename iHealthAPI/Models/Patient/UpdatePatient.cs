using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace iHealthAPI.Models
{
    public class UpdatePatient
    {
        public string Name { get; set; }

        public string Surname { get; set; }

        public string EMBG { get; set; }

        public string Image { get; set; }

        public string Gender { get; set; }

        public DateTime BirthDate { get; set; }

        public string PhoneNumber { get; set; }

        public string Email { get; set; }

        public int? PlaceId { get; set; }

        public int? WorkerId { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace iHealthAPI.Models
{
    public class UpdateClinicModel
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public int? PlaceId { get; set; }
        public string PhoneNumber { get; set; }
        public string RegistrationNo { get; set; }
        public ClinicTypeEnum ClinicType { get; set; }
    }
}

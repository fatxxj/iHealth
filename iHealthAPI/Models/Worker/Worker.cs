using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using iHealthAPI.Models;

namespace ihealthapi.Models
{
    public class Worker
    {
        [Key]
        public int Id { get; set; }

        //Table references

        //Foregin Keys
        public int? DoctorId { get; set; }
        public int? ClinicId { get; set; }

        //public int? StaffIf { get; set; }
        //public int? NurseId { get; set; }

        //Referenced tables
        public virtual ICollection<Doctor>? Doctors { get; set; }
        public virtual ICollection<Clinic>? Clinics { get; set; }
        //public virtual Staff? Staff { get; set; }
        //public virtual Nurse? Nurse { get; set; }
    }
}

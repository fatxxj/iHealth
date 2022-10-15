using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using iHealthAPI.Models;

namespace ihealthapi.Models
{
    public class Worker
    {
        [Key]
        public int Id { get; set; }
        public float Salary { get; set; }
        public float Bonuses { get; set; }
        public DateTime? WorkingDayAndStartTime { get; set; }
        public DateTime? WorkingDayAndEndTime { get; set; }

        [DefaultValue(true)]
        public bool? IsEmployee { get; set; }

        [DefaultValue(false)]
        public bool? IsDeleted { get; set; }

        //Foregin Keys
        public int? DoctorId { get; set; }
        public int? ClinicId { get; set; }
        public int? NurseId { get; set; }
        public int? PatientId { get; set; }
        public int? OtherStaffId { get; set; }

        //Referenced tables
        public virtual ICollection<Doctor>? Doctors { get; set; }
        public virtual ICollection<Clinic>? Clinics { get; set; }
        public virtual ICollection<Nurse>? Nurses { get; set; }
        public virtual ICollection<Patient>? Patients { get; set; }
        public virtual ICollection<OtherStaff>? OtherStaff { get; set; }
    }
}

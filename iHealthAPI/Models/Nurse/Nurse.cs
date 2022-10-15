using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace iHealthAPI.Models
{
    public class Nurse
    {
        [Key]
        public int Id{get;set; }
        public string Name {get;set; }
        public string Surname {get;set; }
        public DateTime? BirthDate {get;set; }
        public string? Speciallity {get;set; }



        //Refrence tables
        //Foregin Keys
        public int WorkerId {get;set; }
        

        //Referenced Tables
    }
}
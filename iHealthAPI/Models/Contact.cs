﻿
using System.ComponentModel.DataAnnotations;

namespace iHealthAPI.Models
{
    public class Contact
    {
        [Key]
        [Required]
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; } 
        public long Phone { get; set; }
        public string Address { get;set; }
       
    }
}

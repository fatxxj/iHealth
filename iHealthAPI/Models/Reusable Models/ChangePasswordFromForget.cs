using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace iHealthAPI.Models
{
    public class ChangePasswordFromForget
    {
        public int? userId { get; set; }

        public string token { get; set; }
        public string? Password { get; set; }
        public string? ConfirmPassword { get; set; }
    }
}

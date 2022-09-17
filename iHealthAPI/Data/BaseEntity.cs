using iHealthAPI.Services.Interfaces;
using System.ComponentModel.DataAnnotations;
using System.Security.Principal;

namespace iHealth.Data
{
    public abstract class BaseEntity : IEntity
    {
        [Required]
        [Key]
        public int Id { get; set; }



        [Required]
        public string CreatedBy { get; set; }

        [Required]
        public DateTime CreatedOnUtc { get; set; }

        public string LastModifiedBy { get; set; }

        public DateTime? LastModifiedOnUtc { get; set; }

        public string IPAddress { get; set; }

        public bool IsDeleted { get; set; }
    }
}

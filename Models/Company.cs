// Models/Company.cs
using System.ComponentModel.DataAnnotations;

namespace VCQRU.Models
{
    public class Company
    {

        [Key]
        public int CompanyId { get; set; }
        [Required]
        public string CompanyName { get; set; }
        [Required]
        public string ContactEmail { get; set; }
        [Required]
        public string PhoneNumber { get; set; }
        [Required]
        public string Address { get; set; }
    }
}

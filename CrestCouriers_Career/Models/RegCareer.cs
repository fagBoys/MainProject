using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace CrestCouriers_Career.Models
{
    public class RegCareer
    {
        [Required]
        [MaxLength(50)]
        public string FirstName { get; set; }
        [Required]
        [MaxLength(50)]
        public string LastName { get; set; }
        [Required]
        public string Gender { get; set; }
        [Required]
        public string Age { get; set; }
        [Required]
        public string Married { get; set; }
        [Required]
        public string HouseNumber { get; set; }
        [Required]
        [MaxLength(10)]
        public string RoadName { get; set; }
        [Required]
        [MaxLength(20)]
        public string City { get; set; }
        [Required]
        public string PostCode { get; set; }
        [Required]
        public string DriverLicence { get; set; }
        [Required]
        public string Accident { get; set; }
        [Required]
        public string DBS { get; set; }
        [Required]
        public string PhoneNumber { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        public string UploadCV { get; set; }

    }
}

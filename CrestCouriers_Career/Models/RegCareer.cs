using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace CrestCouriers_Career.Models
{
    public class RegCareer
    {
        [Key]
        public int RegId { get; set; }
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
        [MaxLength(30)]
        public string RoadName { get; set; }
        [Required]
        [MaxLength(30)]
        public string City { get; set; }
        [Required]
        public string PostCode { get; set; }
        [Required]
        [RegularExpression("Yes", ErrorMessage = "You have no competence for this job")]
        public string DriverLicence { get; set; }
        [Required]
        [RegularExpression("No", ErrorMessage = "You have no competence for this job")]
        public string Accident { get; set; }
        [Required]
        [RegularExpression("Yes", ErrorMessage = "You have no competence for this job")]
        public string DBS { get; set; }
        [Required]
        public string PhoneNumber { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        
        public string UploadCV { get; set; }
        
        public string CityRequest { get; set; }

    }
}

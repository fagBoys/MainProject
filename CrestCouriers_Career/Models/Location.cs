using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CrestCouriers_Career.Models
{
    public class Location
    {
        [Key]
        public int AddressId { get; set; }

        [MaxLength(20)]
        public string? Recipient { get; set; }

        [MaxLength(20)]
        public string? Company { get; set; }

        [Required]
        [MaxLength(20)]
        public ICollection<Address> Addresses { get; set; }

        [Required]
        [MaxLength(20)]
        public string Town { get; set; }

        [Required]
        [MaxLength(20)]
        public string Postcode { get; set; }
    }
}
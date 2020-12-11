using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CrestCouriers_Career.Models
{
    public class Location
    {
        [Key]
        public int LocationId { get; set; }

        [MaxLength(20)]
        public string? Recipient { get; set; }

        [MaxLength(20)]
        public string? Company { get; set; }

        [Required]
        [MaxLength(20)]
        public string Town { get; set; }

        [Required]
        [MaxLength(20)]
        public string Postcode { get; set; }

        [Required]
        [MaxLength(20)]
        public string LocationType { get; set; }

        public int OrderId { get; set; }
        public Order Order { get; set; }

        public ICollection<Address> Addresses { get; set; }
    }
}

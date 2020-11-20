using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;
using System.Linq;
using System.Threading.Tasks;

namespace CrestCouriers_Career.Models
{
    public class Address

    {
         [Key]
        public int AddressId { get; set; }

        [MaxLength(20)]
        public string? Recipient { get; set; }

        [MaxLength(20)]
        public string? Company { get; set; }

        [Required]
        [MaxLength(20)]
        public string Street { get; set; }


        [Required]
        [MaxLength(20)]
        public string Town { get; set; }

        [Required]
        [MaxLength(20)]
        public string Postcode { get; set; }

    }
}

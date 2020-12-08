using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace CrestCouriers_Career.Models
{
    public class Address
    {
        [Key]
        public int AddressId { get; set; }

        [MaxLength(200)]
        public string AddressBody { get; set; }

        public Place Place { get; set; }
    }
}

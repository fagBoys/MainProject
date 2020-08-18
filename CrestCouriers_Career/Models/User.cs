using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using CrestCouriers_Career.Data;
using Microsoft.AspNetCore.Identity;

namespace CrestCouriers_Career.Models
{
    public class User : IdentityUser
    {
        [Required]
        [MaxLength(50)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(50)]
        public string LastName { get; set; }

        [Required]
        [MaxLength(50)]
        public string Level { get; set; }

        public ICollection<Order> Orders { get; set; }
    }
}


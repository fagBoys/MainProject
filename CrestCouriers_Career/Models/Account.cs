using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace CrestCouriers_Career.Models
{
    public class Account : IdentityUser
    {
        [Required]
        [MaxLength(50)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(50)]
        public string LastName { get; set; }

        public bool IsUser { get; set; }

        public bool IsAdmin { get; set; }

        public bool IsActive { get; set; }

        public bool AdminType { get; set; }

        public string Level { get; set; }

        public ICollection<Order> Orders { get; set; }
    }
}

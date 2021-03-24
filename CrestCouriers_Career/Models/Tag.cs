using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace CrestCouriers_Career.Models
{
    public class Tag:IdentityUser
    {
        [Key]
        public int Tagid { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
    }
}

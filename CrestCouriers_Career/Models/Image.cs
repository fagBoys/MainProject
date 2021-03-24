using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace CrestCouriers_Career.Models
{
    public class Image:IdentityUser
    {
        [Key]
        public int Imageid { get; set; }

        [Required]
        [MaxLength(50)]
        public string ImageName { get; set; }

        public string Article { get; set; }

    }
}

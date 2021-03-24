using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace CrestCouriers_Career.Models
{
    public class Article:IdentityUser
    {
        [Key]
        public int Articleid { get; set; }

        public string  AoutherAccount { get; set; }

        public string   Body { get; set; }

        public string ShortBody { get; set; }

        [Required]
        [MaxLength(200)]
        public string Title { get; set; }

        public DateTime Date { get; set; }

        public bool Active { get; set; }

        [Required]
        [MaxLength(200)]
        public string CloseComment { get; set; }

    }
}

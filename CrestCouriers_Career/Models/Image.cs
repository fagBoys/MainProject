using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace CrestCouriers_Career.Models
{
    public class Image
    {
        [Key]
        public int ImageId { get; set; }

        [Required]
        [MaxLength(100)]
        public string ImageName { get; set; }
        
        public int ArticleId { get; set; }
        
        public Article Article { get; set; }

    }
}

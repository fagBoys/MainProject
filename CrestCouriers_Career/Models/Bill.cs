using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;
using System.IO;
using Microsoft.EntityFrameworkCore;

namespace CrestCouriers_Career.Models
{
    public class Bill

    {
        [Key]
        public int BillID { get; set; }

        [Required]
        [MaxLength(50)]
        public DateTime Date { get; set; }

        [Required]
        [MaxLength(50)]
        public string filename { get; set; }

        [MaxLength(20)]
        public string Confirmation { get; set; }

        [Required]
        public byte[] File { get; set; }
    }
}

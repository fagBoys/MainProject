using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace CrestCouriers_Career.Models
{
    public class Comment:IdentityUser
    {
        [Key]
        public int Commentid { get; set; }

        public int Replyid { get; set; }

        public int Articleid { get; set; }

        public int Accountid { get; set; }

        [Required]
        [MaxLength(200)]
        public string Message { get; set; }

        public DateTime Date { get; set; }

        public string IsReply { get; set; }
    }
}

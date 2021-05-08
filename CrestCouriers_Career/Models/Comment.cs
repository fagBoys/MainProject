using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace CrestCouriers_Career.Models
{
    public class Comment
    {
        [Key]
        public int CommentId { get; set; }

        public int ReplyId { get; set; }

        public int AccountId { get; set; }

        [Required]
        [MaxLength(2000)]
        public string Message { get; set; }

        public DateTime Date { get; set; }

        public bool IsReply { get; set; }

        public int ArticleId { get; set; }

        public Article Article { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace CrestCouriers_Career.Models
{
    public class Article
    {
        [Key]
        public int ArticleID { get; set; }

        [Required]
        [MaxLength(200)]
        public string  AuthorAccount { get; set; }

        [Required]
        [MaxLength(50000)]
        public string   Body { get; set; }

        [Required]
        [MaxLength(5000)]
        public string ShortBody { get; set; }

        [Required]
        [MaxLength(200)]
        public string Title { get; set; }

        public DateTime Date { get; set; }

        public bool Active { get; set; }

        public bool CloseComment { get; set; }

        public ICollection<Image> images { get; set; }

        public ICollection<Comment> comments { get; set; }

        public ICollection<ArticleTag> articleTags { get; set; }

    }
}

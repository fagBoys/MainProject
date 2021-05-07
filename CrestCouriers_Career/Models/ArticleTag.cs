using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace CrestCouriers_Career.Models
{
    public class ArticleTag
    {
       public int ArticleTagId { get; set; }

       public int ArticleId { get; set; }

        public int TagId { get; set; }

        public int ArticleID { get; set; }
        
        public Article article { get; set; }

        public ICollection<Tag> tags { get; set; }

    }
}

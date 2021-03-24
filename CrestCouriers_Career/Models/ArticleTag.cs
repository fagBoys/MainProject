using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace CrestCouriers_Career.Models
{
    public class ArticleTag:IdentityUser
    {
       public int ArticleTagid { get; set; }

       public int Articleid { get; set; }

        public int Tagid { get; set; }

    }
}

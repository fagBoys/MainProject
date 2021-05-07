using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace CrestCouriers_Career.Models
{
    public class Like:IdentityUser

    {
        [Key]
        public int LikeId { get; set; }

        public int ArticleId { get; set; }

        public int AccountId { get; set; }


    }
}

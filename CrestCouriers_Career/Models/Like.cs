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
        public int Likeid { get; set; }

        public int Articleid { get; set; }

        public int Accountid { get; set; }


    }
}

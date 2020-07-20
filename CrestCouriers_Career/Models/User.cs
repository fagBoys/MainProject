using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace CrestCouriers_Career.Models
{
    public class User
    {

        [Key]
        public int Userid { get; set; }

        [Required]
        [MaxLength(50)]
        public string UserName { get; set; }


        [Required]
        [MaxLength(50)]
        public string Password { get; set; }


        [Required]
        [MaxLength(50)]
        public string FirstName { get; set; }


        [Required]
        [MaxLength(50)]
        public string LastName { get; set; }


        [MaxLength(50)]
        public string Active { get; set; }

        [Required]
        [MaxLength(50)]
        public string PhoneNumber { get; set; }

        [Required]
        [EmailAddress]
        public string EmailAddress { get; set; }



    }
}


using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace CrestCouriers_Career.Models
{
    public class Order
    {
        [Key]
        public string Orderid { get; set; }

        [Required]
        [MaxLength(50)]
        public string OrderDate { get; set; }

        [Required]
        [MaxLength(50)]
        public string Origin { get; set; }

        [Required]
        [MaxLength(50)]
        public string Destination { get; set; }

        [Required]
        [MaxLength(50)]
        public string ReceiveDate { get; set; }

        [Required]
        [MaxLength(50)]
        public string DeliveryDate { get; set; }

        [Required]
        [MaxLength(50)]
        public string CarType { get; set; }

        [Required]
        [MaxLength(50)]
        public string UserId { get; set; }

        [Required]
        [MaxLength(50)]
        public string Price { get; set; }

        [Required]
        [MaxLength(50)]
        public string State { get; set; }




    }
}

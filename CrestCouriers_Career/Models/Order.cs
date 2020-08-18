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
        public int  OrderId { get; set; }

        [Required]
        public DateTime OrderDate { get; set; }

        [Required]
        [MaxLength(50)]
        public string Origin { get; set; }

        [Required]
        [MaxLength(50)]
        public string Destination { get; set; }

        [Required]
        public DateTime CollectionDate { get; set; }

        [Required]
        public DateTime DeliveryDate { get; set; }

        [Required]
        [MaxLength(50)]
        public string CarType { get; set; }

        [MaxLength(50)]
        public string Price { get; set; }

        [MaxLength(50)]
        public string State { get; set; }

        public Account Account { get; set; }
    }
}

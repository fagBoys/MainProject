using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CrestCouriers_Career.Models
{
    public class Order
    {
        [Key]
        public int  OrderId { get; set; }

        [Required]
        public DateTime OrderDate { get; set; }

        public ICollection<Place> Places { get; set; }

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

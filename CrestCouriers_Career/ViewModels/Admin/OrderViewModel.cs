using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;


namespace CrestCouriers_Career.ViewModels.Admin
{
    public class OrderViewModel
    {
        [Required]
        public string OriginAddress { get; set; }

        [Required]
        public string DestinationAddress { get; set; }

        [Required]
        public DateTime CollectionDate { get; set; }

        [Required]
        public DateTime DeliveryDate { get; set; }

        [Required]
        public string CarType { get; set; }

    }
}

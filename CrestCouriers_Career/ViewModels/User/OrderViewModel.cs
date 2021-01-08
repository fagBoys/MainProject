using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CrestCouriers_Career.ViewModels.User
{
    public class OrderViewModel
    {

        [Required]
        public string OriginRecipient { get; set; }

        [Required]
        public string? OriginCompany { get; set; }

        [Required]
        public string OriginAddress { get; set; }

        [Required]
        public string OriginAddress2 { get; set; }

        [Required]
        public string OriginAddress3 { get; set; }

        [Required]
        public string OriginTown { get; set; }

        [Required]
        public string OriginPostcode { get; set; }

        [Required]
        public DateTime CollectionDate { get; set; }

        [Required]
        public string DestinationRecipient { get; set; }

        [Required]
        public string? DestinationCompany { get; set; }

        [Required]
        public string DestinationAddress { get; set; }

        [Required]
        public string DestinationAddress2 { get; set; }

        [Required]
        public string DestinationAddress3 { get; set; }

        [Required]
        public string DestinationTown { get; set; }

        [Required]
        public string DestinationPostcode { get; set; }

        [Required]
        public DateTime DeliveryDate { get; set; }

        [Required]
        public string CarType { get; set; }

    }
}

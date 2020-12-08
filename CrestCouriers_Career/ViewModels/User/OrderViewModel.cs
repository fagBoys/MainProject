using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CrestCouriers_Career.ViewModels.User
{
    public class OrderViewModel
    {
        [MaxLength(20)]
        public string OriginRecipient { get; set; }

        [MaxLength(20)]
        public string? OriginCompany { get; set; }

        [MaxLength(200)]
        public string OriginAddress { get; set; }

        [MaxLength(200)]
        public string OriginAddress2 { get; set; }

        [MaxLength(200)]
        public string OriginAddress3 { get; set; }

        [MaxLength(20)]
        public string OriginTown { get; set; }

        [MaxLength(20)]
        public string OriginPostcode { get; set; }

        [Required]
        public DateTime CollectionDate { get; set; }

        [MaxLength(20)]
        public string DestinationRecipient { get; set; }

        [MaxLength(20)]
        public string? DestinationCompany { get; set; }

        [MaxLength(200)]
        public string DestinationAddress { get; set; }

        [MaxLength(200)]
        public string DestinationAddress2 { get; set; }

        [MaxLength(200)]
        public string DestinationAddress3 { get; set; }

        [MaxLength(20)]
        public string DestinationTown { get; set; }

        [MaxLength(20)]
        public string DestinationPostcode { get; set; }

        [Required]
        public DateTime DeliveryDate { get; set; }

        [Required]
        [MaxLength(20)]
        public string CarType { get; set; }

    }
}

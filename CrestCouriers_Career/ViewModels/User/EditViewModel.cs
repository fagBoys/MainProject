using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CrestCouriers_Career.ViewModels.User
{
    public class EditViewModel
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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;


namespace CrestCouriers_Career.ViewModels.Admin
{
    public class BillViewModel
    {
        [Required]
        
        public byte File { get; set; }
    }
}

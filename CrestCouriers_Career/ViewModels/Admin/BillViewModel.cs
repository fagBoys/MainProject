using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace CrestCouriers_Career.ViewModels.Admin
{
    public class BillViewModel
    {
        [Required]
        public IFormFile File { get; set; }
    }
}

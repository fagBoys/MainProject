using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CrestCouriers_Career.Models;

namespace CrestCouriers_Career.Models
{
    public class AdminAccountsViewModel
    {
        public Admin admin { get; set; }

        public IEnumerable<Admin> adminList { get; set; }
    }
}

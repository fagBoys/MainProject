using CrestCouriers_Career.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrestCouriers_Career.ViewModels
{
    public class DashboardViewModel
    {
        public IEnumerable<Order> orders { get; set; }

        public IEnumerable<Location> locations { get; set; }
    }
}

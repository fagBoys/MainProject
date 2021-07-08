using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CrestCouriers_Career.Models;

namespace CrestCouriers_Career.ViewModels.Home
{
    public class DetailsViewModel
    {

        public Article article { get; set; }

        public IEnumerable<Article> articlesList { get; set; }

    }
}

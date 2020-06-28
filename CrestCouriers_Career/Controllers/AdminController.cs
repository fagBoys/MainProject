using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace CrestCouriers_Career.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Dashboard()
        {
            return View();
        }

        public IActionResult Order()
        {
            return View();
        }
        public IActionResult AdminSetting()
        {
            return View();
        }
        public IActionResult AdminAccounts()
        {
            return View();
        }
        public IActionResult UserAccounts()
        {
            return View();
        }
    }
}
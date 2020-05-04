using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace CrestCouriers_Career.Controllers
{
    public class UserController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult register()
        {
            return View();
        }

        public IActionResult login()
        {
            return View();
        }

        public IActionResult dashboard()
        {
            return View();
        }

        public IActionResult neworder()
        {
            return View();
        }

        public IActionResult orderlist()
        {
            return View();
        }

        public IActionResult userinformation()
        {
            return View();
        }

    }
}
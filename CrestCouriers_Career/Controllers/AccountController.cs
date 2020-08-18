using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

using Microsoft.AspNetCore.Identity;
using CrestCouriers_Career.Models;
using Microsoft.AspNetCore.Authorization;
using CrestCouriers_Career.ViewModels.AccountViewModels;
using Microsoft.Extensions.Logging;


namespace CrestCouriers_Career.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
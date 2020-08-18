using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CrestCouriers_Career.Models;
using System.Data.SqlClient;
using System.Data;
using System.IO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Hosting;
using MailKit.Net.Smtp;
using MimeKit;
using reCAPTCHA.AspNetCore;
using Microsoft.IdentityModel.Protocols;
using System.Configuration;
using MimeKit.Utils;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Authorization;
using CrestCouriers_Career.ViewModels;
using CrestCouriers_Career.Data;
using Microsoft.EntityFrameworkCore;

using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using CrestCouriers_Career.ViewModels.AccountViewModels;
using Microsoft.Extensions.Logging;
using System.Security.Claims;

namespace CrestCouriers_Career.Controllers
{
    public class AdminController : Controller
    {
        private IHostingEnvironment _environment;

        private IRecaptchaService _recaptcha;

        private readonly UserManager<Account> _userManager;

        private readonly SignInManager<Account> _signInManager;

        private readonly ILogger _logger;


        public AdminController(IHostingEnvironment environment, IRecaptchaService recaptcha, UserManager<Account> userManager, SignInManager<Account> signInManager, ILogger<Account> logger)
        {
            _environment = environment;

            _recaptcha = recaptcha;

            _userManager = userManager;

            _signInManager = signInManager;

            _logger = logger;
        }

        private void AddErrors(IdentityResult result)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(string.Empty, error.Description);
            }
        }

        private IActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            else
            {
                return RedirectToAction(nameof(HomeController.Index), "Home");
            }
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Dashboard()
        {
            //EF core start

            CrestContext context = new CrestContext();
            IEnumerable<Order> orders = context.Order.Include(O=>O.Account).ToList();
            
            //EF core end

            return View(orders);
        }

        public ActionResult Delete(int id)
        {

            //EF core start
            CrestContext context = new CrestContext();
            Order order = context.Order.FirstOrDefault(o => o.OrderId == id);
            context.Order.Remove(order);
            context.SaveChangesAsync();
            //EF core end

            return new RedirectResult("/Admin/Dashboard");
        }

        public IActionResult Edit(int id)
        {

            //EF core start
            CrestContext context = new CrestContext();
            Order order = context.Order.FirstOrDefault(o => o.OrderId == id);
            //EF core end

            return View(order);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult EditOrder(Order editedorder)
        {

            //string myurl = $"{this.Request.Scheme}://{this.Request.Host}{this.Request.PathBase}";
            //Dal connection = new Dal(myurl);
            //SqlDataAdapter da = new SqlDataAdapter();
            //DataTable dt = new DataTable();
            //SqlCommand cmd = new SqlCommand("sp_Crest_UpdateOrder", connection.connect());
            //cmd.CommandType = CommandType.StoredProcedure;
            //cmd.Parameters.AddWithValue("@Orderid", order.OrderId);
            //cmd.Parameters.AddWithValue("@Origin", order.Origin);
            //cmd.Parameters.AddWithValue("@Destination", order.Destination);
            //cmd.Parameters.AddWithValue("@ReceiveDate", order.CollectionDate);
            //cmd.Parameters.AddWithValue("@DeliveryDate", order.DeliveryDate);
            //cmd.Parameters.AddWithValue("@CarType", order.CarType);

            //cmd.ExecuteNonQuery();
            //EF core start
            CrestContext context = new CrestContext();
            Order order = new Order();
            order = context.Order.FirstOrDefault(O => O.OrderId == editedorder.OrderId);
            editedorder.OrderDate = order.OrderDate;
            editedorder.Price = order.Price;
            editedorder.State = order.State;
            CrestContext editcontext = new CrestContext();
            editcontext.Attach(editedorder).State = EntityState.Modified;
            editcontext.SaveChangesAsync();
            //EF core end

            return new RedirectResult("~/Admin/dashboard");
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Order()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Order(Order order)
        {
            ViewData["Title"] = "Order";

            //Recaptcha code begins here


            //var recaptcha = await _recaptcha.Validate(Request);
            //if (!recaptcha.success)
            //    ModelState.AddModelError("Recaptcha", "There was an error validating recatpcha. Please try again!");


            //Recaptcha code ends here

            //EF CORE START

            CrestContext context = new CrestContext();
            Account curaccount = context.Account.FirstOrDefault(A => A.Id == _userManager.GetUserId(User as ClaimsPrincipal));
            context.Attach(curaccount).State = EntityState.Unchanged;
            order.Account = curaccount as Account;
            context.Order.Add(order);
            context.SaveChanges();

            //EF CORE END

            return View(!ModelState.IsValid ? order : new Order());

        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult AdminSetting()
        {
            //EF
            CrestContext context = new CrestContext();
            Account Account = context.Account.FirstOrDefault(A => A.Id == _userManager.GetUserId(User as ClaimsPrincipal));
            //EF

            return View(Account);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AdminSetting(Account UpdatedAccount)
        {

            ////EF core start
            CrestContext context = new CrestContext();
            Account CurrentAccount = context.Account.FirstOrDefault(A => A.Id == _userManager.GetUserId(User as ClaimsPrincipal));

            CurrentAccount.UserName = UpdatedAccount.UserName;
            CurrentAccount.PasswordHash = UpdatedAccount.PasswordHash;
            CurrentAccount.FirstName = UpdatedAccount.FirstName;
            CurrentAccount.LastName = UpdatedAccount.LastName;
            CurrentAccount.PhoneNumber = UpdatedAccount.PhoneNumber;

            _userManager.UpdateAsync(CurrentAccount);

            context.SaveChangesAsync();
            ////EF core end



            return new RedirectResult("/Admin/AdminSetting");
        }

        public IActionResult AdminAccounts()
        {

            //EF core start

            CrestContext context = new CrestContext();
            IEnumerable<Account> accounts = context.Account.Where(A=>A.IsAdmin == true).ToList();

            //EF core end

            return View(accounts);
        }


        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AdminAccounts(string UserName, string Password, string FirstName, string LastName, string PhoneNumber ,string EmailAddress, string returnUrl = null)
        {

            ViewData["Title"] = "AdminAccounts";
            ViewData["ReturnUrl"] = returnUrl;
            if(ModelState.IsValid)
            { 
                //EF core code

                var user = new Account { UserName = EmailAddress};
                var result = await _userManager.CreateAsync(user, Password);
                if(result.Succeeded)
                {
                    _logger.LogInformation("User created a new account with password.");
                    await _signInManager.SignInAsync(user, isPersistent: false);

                    _logger.LogInformation("User created new account with password.");
                    return RedirectToAction(nameof(AdminAccounts));
                }
                AddErrors(result);
            }
            else
            {
                return View();
            }
            //EF core code ends

            return RedirectToAction("AdminAccounts");


        }

        public ActionResult AdminDelete(int id)
        {
            //EF core start
            CrestContext context = new CrestContext();
            //Admin admin = context.Admin.FirstOrDefault(o => o.AdminId == id);
            //context.Admin.Remove(admin);
            context.SaveChangesAsync();
            //EF core end

            return RedirectToAction("AdminAccounts");
        }


        public IActionResult AdminAccountEdit( string UserName)
        {
            //if (HttpContext.Session.GetString("AdminSession") == null)
            //{
            //    return new RedirectResult("/Admin/Login");
            //}
            //{
            //    ViewData["Username"] = HttpContext.Session.GetString("AdminSession");
            //}

            //string myurl = $"{this.Request.Scheme}://{this.Request.Host}{this.Request.PathBase}";
            //Dal connection = new Dal(myurl);
            //SqlDataAdapter da = new SqlDataAdapter();
            //DataTable dt = new DataTable();
            //SqlCommand cmd = new SqlCommand("sp_Crest_MyAdmin", connection.connect());
            //cmd.CommandType = CommandType.StoredProcedure;
            //cmd.Parameters.AddWithValue("@UserName", UserName);
            //da.SelectCommand = cmd;
            //da.Fill(dt);

            //ViewData["Adminid"] = dt.Rows[0][0];
            //ViewData["UserName"] = dt.Rows[0][1];
            //ViewData["Password"] = dt.Rows[0][2];
            //ViewData["FirstName"] = dt.Rows[0][3];
            //ViewData["Lastname"] = dt.Rows[0][4];
            //ViewData["PhoneNumber"] = dt.Rows[0][5];
            //ViewData["Email"] = dt.Rows[0][6];

            //EF core start
            CrestContext context = new CrestContext();
            //Admin admin= context.Admin.FirstOrDefault(o => o.UserName== UserName);

            //ViewData["Adminid"] = admin.AdminId;
            //ViewData["UserName"] = admin.UserName;
            //ViewData["Password"] = admin.Password;
            //ViewData["FirstName"] = admin.FirstName;
            //ViewData["Lastname"] = admin.Lastname;
            //ViewData["PhoneNumber"] = admin.PhoneNumber;
            //ViewData["Email"] = admin.EmailAddress;

            //EF core end



            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AdminEdit(Admin EditedAdmin)
        {
            //if (HttpContext.Session.GetString("AdminSession") == null)
            //{
            //    return new RedirectResult("/Admin/Login");
            //}
            //{
            //    ViewData["Username"] = HttpContext.Session.GetString("AdminSession");
            //}

            //string myurl = $"{this.Request.Scheme}://{this.Request.Host}{this.Request.PathBase}";
            //Dal connection = new Dal(myurl);
            //SqlDataAdapter da = new SqlDataAdapter();
            //DataTable dt = new DataTable();
            //SqlCommand cmd = new SqlCommand("sp_Crest_UpdateAdmin", connection.connect());
            //cmd.CommandType = CommandType.StoredProcedure;
            //cmd.Parameters.AddWithValue("@UserName", admin.UserName);
            //cmd.Parameters.AddWithValue("@Password", admin.Password);
            //cmd.Parameters.AddWithValue("@FirstName", admin.FirstName);
            //cmd.Parameters.AddWithValue("@LastName", admin.Lastname);
            //cmd.Parameters.AddWithValue("@PhoneNumber", admin.PhoneNumber);
            //cmd.Parameters.AddWithValue("@Email", admin.EmailAddress);
            //cmd.ExecuteNonQuery();

            //EF core start
            CrestContext context = new CrestContext();
            Admin admin = new Admin();
            //admin = context.Admin.FirstOrDefault(O => O.AdminId == EditedAdmin.AdminId);
            EditedAdmin.Level = admin.Level;
            CrestContext editcontext = new CrestContext();
            editcontext.Attach(EditedAdmin).State = EntityState.Modified;
            editcontext.SaveChangesAsync();
            //EF core end
            return new RedirectResult("/Admin/AdminAccounts");
        }

        public IActionResult AdminAccountActive(bool IsActive, int Adminid)
        {
            //string myurl = $"{this.Request.Scheme}://{this.Request.Host}{this.Request.PathBase}";
            //Dal connection = new Dal(myurl);
            //SqlDataAdapter da = new SqlDataAdapter();
            //DataTable dt = new DataTable();
            //SqlCommand cmd = new SqlCommand("sp_Crest_AdminActive", connection.connect());
            //cmd.CommandType = CommandType.StoredProcedure;
            //cmd.Parameters.AddWithValue("@Adminid", Adminid);
            //if (Level == "0")
            //{
            //    cmd.Parameters.AddWithValue("@Level", "2");
            //}
            //else if (Level == "2")
            //{
            //    cmd.Parameters.AddWithValue("@Level", "0");
            //}
            //cmd.ExecuteNonQuery();

            //EF core start
            CrestContext context = new CrestContext();
            Admin admin = new Admin();
            //admin = context.Admin.FirstOrDefault(O => O.AdminId == Adminid);
            //if (Level == "0")
            //{
            //    admin.Level = "2";
            //}
            //else if (Level == "2")
            //{
            //    admin.Level = "0";
            //}
            CrestContext editcontext = new CrestContext();
            editcontext.Attach(admin).State = EntityState.Modified;
            editcontext.SaveChangesAsync();
            //EF core end

            return new RedirectResult("/Admin/AdminAccounts");
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult UserAccounts()
        {
            //EF core start

            CrestContext context = new CrestContext();
            IEnumerable<Account> accounts = context.Account.ToList();

            //EF core end

            return View(accounts);
        }

        public async Task<ActionResult> SystemUserDelete(string id)
        {

            Account account = await _userManager.FindByIdAsync(id);
            await _userManager.DeleteAsync(account);

            return RedirectToAction("UserAccounts");
        }

        public async Task<IActionResult> SystemUserEdit(string id)
        {


            //EF core start
            Account account = await _userManager.FindByIdAsync(id);
            //EF core end

            return View(account);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SystemUserEdite(Account UpdatedAccount)
        {


            //EF core start
            Account OldAccount = await _userManager.FindByIdAsync(UpdatedAccount.Id);

            OldAccount.UserName = UpdatedAccount.UserName;
            OldAccount.PasswordHash = UpdatedAccount.PasswordHash;
            OldAccount.FirstName = UpdatedAccount.FirstName;
            OldAccount.LastName = UpdatedAccount.LastName;
            OldAccount.PhoneNumber = UpdatedAccount.PhoneNumber;

            _userManager.UpdateAsync(OldAccount);
            //EF core end

            return new RedirectResult("/Admin/UserAccounts");
        }

        public IActionResult UserAccountActive(string Active, int Userid)
        {

            //EF core start
            CrestContext context = new CrestContext();
            User user= new User();

            //user = context.User.FirstOrDefault(O => O.Id == Userid);
            //if (Active == "0")
            //{
            //    user.Active= "1";
            //}
            //else if (Active == "1")
            //{
            //    user.Active= "0";
            //}

            CrestContext editcontext = new CrestContext();
            editcontext.Attach(user).State = EntityState.Modified;
            editcontext.SaveChangesAsync();
            //EF core end

            return new RedirectResult("/Admin/UserAccounts");
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> Login(string returnUrl = null)
        {
            await HttpContext.SignOutAsync(IdentityConstants.ExternalScheme);

            ViewData["ReturnUrl"] = returnUrl;
            return View();
        }


        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel model, string returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl;

            if (ModelState.IsValid)
            {
                CrestContext context = new CrestContext();
                var result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, lockoutOnFailure: false);
                Account Account = await context.Account.Where(A => A.Email == model.Email).FirstOrDefaultAsync();
                if (result.Succeeded && Account.IsAdmin && Account.IsActive)
                {
                    _logger.LogInformation("User logged in.");
                    return RedirectToAction(nameof(Dashboard));

                }
                if (result.IsLockedOut)
                {
                    _logger.LogWarning("User account locked out.");
                    return RedirectToLocal(nameof(Lockout));
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Invalid login attempt.");
                    return View(model);
                }
            }

            return View();
        
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Lockout()
        {
            return View();
        }

    }
}
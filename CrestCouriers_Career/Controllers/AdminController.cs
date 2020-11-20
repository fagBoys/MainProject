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

using System.Net.Mime;

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
            IEnumerable<Order> orders = context.Order.Include(O => O.Account).ToList();

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
            order.Price = "0";
            order.State = "1";
            context.Order.Add(order);
            context.SaveChanges();

            //EF CORE END

            return View(!ModelState.IsValid ? order : new Order());

        }



        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> AdminSetting()
        {
            //EF
            CrestContext context = new CrestContext();
            Account Account = context.Account.FirstOrDefault(A => A.Id == _userManager.GetUserId(User as ClaimsPrincipal));
            ViewData["CurrentUser"] = Account;
            //EF

            return View(Account);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AdminSetting(Account UpdatedAccount)
        {

            ////EF core start
            CrestContext context = new CrestContext();
            Account CurrentAccount = await _userManager.FindByIdAsync(_userManager.GetUserId(User as ClaimsPrincipal));

            CurrentAccount.UserName = UpdatedAccount.UserName;
            CurrentAccount.PhoneNumber = UpdatedAccount.PhoneNumber;
            CurrentAccount.FirstName = UpdatedAccount.FirstName;
            CurrentAccount.LastName = UpdatedAccount.LastName;


            await _userManager.UpdateAsync(CurrentAccount);
            ////EF core end


            return RedirectToAction("AdminSetting");

        }

        //public async Task<IActionResult> ChangePassword(string OldPassword, string NewPassword)
        //{
        //    CrestContext context = new CrestContext();
        //    Account ThisUser = context.Account.FirstOrDefault(A => A.Id == _userManager.GetUserId(User as ClaimsPrincipal));
        //    if (result.Succeeded)
        //    {
        //        foreach (var error in result.Errors)
        //        {
        //            ModelState.AddModelError(string.Empty, error.Description);
        //        }
        //        return RedirectToAction("AdminSetting");
        //    }
        //    return RedirectToAction("AdminSetting");
        //}




        public IActionResult AdminAccounts()
        {

            //EF core start

            CrestContext context = new CrestContext();
            IEnumerable<Account> accounts = context.Account.Where(A => A.IsAdmin == true).ToList();

            //EF core end

            return View(accounts);
        }


        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AdminAccounts(string UserName, string EmailAddress, string Password, string ConfirmPassword, string FirstName, string MyType, string LastName, string returnUrl = null)
        {

            ViewData["Title"] = "AdminAccounts";
            ViewData["ReturnUrl"] = returnUrl;
            if (ModelState.IsValid)
            {
                //EF core code

                var user = new Account { UserName = UserName, Email = EmailAddress, FirstName = FirstName, LastName = LastName, IsAdmin = true, IsActive = false, IsUser = false, AdminType = MyType };
                var result = await _userManager.CreateAsync(user, Password);
                if (result.Succeeded)
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



        [HttpPost]
        public async Task<IActionResult> AdminAccountEdit(string Id)
        {
            //if (HttpContext.Session.GetString("AdminSession") == null)
            //{
            //    return new RedirectResult("/Admin/Login");
            //}
            //{
            //    ViewData["Username"] = HttpContext.Session.GetString("AdminSession");
            //}

            //EF core start
            Account Account = await _userManager.FindByIdAsync(Id);
            //ViewData["Adminid"] = admin.AdminId;
            //ViewData["UserName"] = admin.UserName;
            //ViewData["Password"] = admin.Password;
            //ViewData["FirstName"] = admin.FirstName;
            //ViewData["Lastname"] = admin.Lastname;
            //ViewData["PhoneNumber"] = admin.PhoneNumber;
            //ViewData["Email"] = admin.EmailAddress;

            //EF core end



            return View(Account);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AdminEdit(Account EditedAdmin)
        {
            //if (HttpContext.Session.GetString("AdminSession") == null)
            //{
            //    return new RedirectResult("/Admin/Login");
            //}
            //{
            //    ViewData["Username"] = HttpContext.Session.GetString("AdminSession");
            //}

            //EF core start
            Account Account = await _userManager.FindByIdAsync(EditedAdmin.Id);
            Account.UserName = EditedAdmin.UserName;
            Account.FirstName = EditedAdmin.FirstName;
            Account.LastName = EditedAdmin.LastName;
            Account.PhoneNumber = EditedAdmin.PhoneNumber;
            Account.Email = EditedAdmin.Email;
            await _userManager.UpdateAsync(Account);
            //EF core end
            return new RedirectResult("/Admin/AdminAccounts");
        }

        [HttpPost]
        public async Task<IActionResult> AdminAccountActive(string Id)
        {

            //EF core start

            Account Account = await _userManager.FindByIdAsync(Id);

            if (Account.IsActive == true)
            {
                Account.IsActive = false;
            }
            else if (Account.IsActive == false)
            {
                Account.IsActive = true;
            }
            await _userManager.UpdateAsync(Account);

            //EF core end

            return new RedirectResult("/Admin/AdminAccounts");
        }

        //[HttpPost]
        //public async Task<ActionResult> AdminDelete(string Id)
        //{
        //    //EF core start
        //    Account Account = await _userManager.FindByIdAsync(Id);
        //    await _userManager.DeleteAsync(Account);
        //    //EF core end

        //    return RedirectToAction("AdminAccounts");
        //}

        [HttpGet]
        [AllowAnonymous]
        public IActionResult UserAccounts()
        {
            //EF core start

            CrestContext context = new CrestContext();
            IEnumerable<Account> accounts = context.Account.Where(A => A.IsUser == true).ToList();

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
            //string userid = UpdatedAccount.Id;
            Account OldAccount = await _userManager.FindByIdAsync(UpdatedAccount.Id);

            OldAccount.UserName = UpdatedAccount.UserName;
            OldAccount.PasswordHash = UpdatedAccount.PasswordHash;
            OldAccount.FirstName = UpdatedAccount.FirstName;
            OldAccount.LastName = UpdatedAccount.LastName;
            OldAccount.PhoneNumber = UpdatedAccount.PhoneNumber;
            OldAccount.Email = UpdatedAccount.Email;

            await _userManager.UpdateAsync(OldAccount);
            //EF core end

            return new RedirectResult("/Admin/UserAccounts");
        }

        public async Task<IActionResult> UserAccountActive(string Userid)
        {

            //EF core start
            //CrestContext context = new CrestContext();
            //User user= new User();

            Account Account = await _userManager.FindByIdAsync(Userid);
            //user = context.User.FirstOrDefault(O => O.Id == Userid);

            if (Account.IsActive == true)
            {
                Account.IsActive = false;
            }
            else if (Account.IsActive == false)
            {
                Account.IsActive = true;
            }

            await _userManager.UpdateAsync(Account);

            //CrestContext editcontext = new CrestContext();
            //editcontext.Attach(user).State = EntityState.Modified;
            //editcontext.SaveChangesAsync();
            //EF core end

            return new RedirectResult("/Admin/UserAccounts");
        }

        [HttpGet]
        public async Task<IActionResult> Login()
        {
            await HttpContext.SignOutAsync(IdentityConstants.ExternalScheme);

            //ViewData["ReturnUrl"] = returnUrl;
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel model, string returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl;

            if (ModelState.IsValid)
            {
                CrestContext context = new CrestContext();
                var result = await _signInManager.PasswordSignInAsync(model.Username, model.Password, model.RememberMe, lockoutOnFailure: false);
                Account Account = await context.Account.Where(A => A.UserName == model.Username).FirstOrDefaultAsync();
                if (result.Succeeded && Account.IsAdmin && Account.IsActive && Account.AdminType == "Admin")
                {
                    _logger.LogInformation("User logged in.");
                    return RedirectToAction(nameof(Dashboard));

                }
                if (result.Succeeded && Account.IsAdmin && Account.IsActive && Account.AdminType == "Limited")
                {
                    _logger.LogInformation("User logged in.");
                    return RedirectToAction(nameof(Dashboard));

                }
                if (result.Succeeded && Account.IsAdmin && Account.IsActive && Account.AdminType == "Accountancy")
                {
                    _logger.LogInformation("User logged in.");
                    return RedirectToAction(nameof(Bill));

                }
                if (result.Succeeded && Account.IsAdmin && Account.IsActive && Account.AdminType == "Secretary")
                {
                    _logger.LogInformation("User logged in.");
                    return RedirectToAction(nameof(Bill));

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
        public IActionResult ForgotPassword()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> ForgotPassword(ForgotPasswordViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByEmailAsync(model.Email);
                if (user != null && await _userManager.IsEmailConfirmedAsync(user))
                {
                    var token = await _userManager.GeneratePasswordResetTokenAsync(user);

                    var passwordResetLink = Url.Action("ResetPassword", "User", new { email = model.Email, token = token }, Request.Scheme);

                    //Logge(LogLevel.Warning, passwordResetLink);

                    //  Send Email  //
                    MailboxAddress from = new MailboxAddress("Crest Couriers", "contact@crestcouriers.co.uk");

                    MailboxAddress to = new MailboxAddress(user.FirstName + " " + user.LastName, user.Email);

                    MimeMessage message = new MimeMessage();
                    message.Subject = "Resset Password";
                    BodyBuilder bodyBuilder = new BodyBuilder();
                    var mybody = @System.IO.File.ReadAllText(_environment.WebRootPath + @"\Email\emailreply-forgotpassword.html");
                    mybody = mybody.Replace("Value00", user.FirstName + " " + user.LastName);
                    mybody = mybody.Replace("Value01", passwordResetLink);

                    bodyBuilder.HtmlBody = mybody;
                    var usericon = bodyBuilder.LinkedResources.Add(_environment.WebRootPath + @"/Email/newuser.png");
                    usericon.ContentId = MimeUtils.GenerateMessageId();

                    bodyBuilder.HtmlBody = bodyBuilder.HtmlBody.Replace("{", "{{");
                    bodyBuilder.HtmlBody = bodyBuilder.HtmlBody.Replace("}", "}}");
                    bodyBuilder.HtmlBody = bodyBuilder.HtmlBody.Replace("{{0}}", "{0}");

                    bodyBuilder.HtmlBody = string.Format(bodyBuilder.HtmlBody, usericon.ContentId);

                    message.Body = bodyBuilder.ToMessageBody();

                    SmtpClient client = new SmtpClient();
                    client.Connect("smtp.gmail.com", 465, true);
                    client.Authenticate("crestcouriers@gmail.com", "CRESTcouriers123");

                    message.From.Add(from);
                    message.To.Add(to);

                    client.Send(message);
                    //  Send Email ends here    //

                    return View();
                }
                return View();
            }

            return View(model);
        }

        public IActionResult ResetPassword(string token, string email)
        {
            if (token == null || email == null)
            {
                ModelState.AddModelError("", "Invalid password reset token.");
            }
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> ResetPassword(ResetPasswordViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByEmailAsync(model.Email);
                if (user != null)
                {
                    var result = await _userManager.ResetPasswordAsync(user, model.Token, model.Password);
                    if (result.Succeeded)
                    {
                        return View();
                    }
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }
                    return View();
                }
                return View();
            }
            return View(model);
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Lockout()
        {
            return View();
        }

        public async Task<IActionResult> Logout()
        {
            if (User.Identity.IsAuthenticated)
            {
                await HttpContext.SignOutAsync();
                return RedirectToAction("Login");
            }
            return RedirectToAction("Login");
        }

        public async Task<IActionResult> ListOfBills(string currentFilter, int? pageNumber)
        {
            CrestContext context = new CrestContext();

            //IEnumerable<Bill> bills = context.Bill.ToList();

            var bills = from B in context.Bill select B;

            return View(await PaginatefList<Bill>.CreateAsunc(bills, pageNumber ?? 1, 5));
        }

        //public async Task<IActionResult> ListOfBills(Bill bill)
        //{
        //    return View(bill);
        //}

        [HttpGet]
        public async Task<IActionResult> DownloadBill(int id, DateTime date)
        {
            CrestContext context = new CrestContext();
            Bill bill = context.Bill.FirstOrDefault(B => B.BillID == id);
            var myfile = Convert.ToBase64String(bill.File);

            return File(bill.File, "application/pdf", date.ToShortDateString() + ".pdf");
        }

        public IActionResult DisplayBill(Bill bill)
        {
            //CrestContext context = new CrestContext();
            //Bill bill = context.Bill.FirstOrDefault(B => B.BillID == id);
            var fileS = new FileStreamResult(new MemoryStream(bill.File), "application/pdf");
            return View(bill.File);
        }

        public IActionResult Bill()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Bill(IFormFile file)
        {
            CrestContext Context = new CrestContext();
            Bill CreateBill = new Bill();
            CreateBill.Date = DateTime.Now;
            if (file.Length > 0)
            {
                using (var ms = new MemoryStream())
                {
                    file.CopyTo(ms);
                    var FileByte = ms.ToArray();
                    CreateBill.File = FileByte;
                }
            }
            Context.Bill.Add(CreateBill);
            Context.SaveChangesAsync();
            return View();
        }
    }
}
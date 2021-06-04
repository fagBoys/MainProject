using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CrestCouriers_Career.Models;
using CrestCouriers_Career.ViewModels.Admin;
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

        [Route("Dashboard")]
        public IActionResult Dashboard()
        {
            //EF core start

            CrestContext context = new CrestContext();
            DashboardViewModel DVM = new DashboardViewModel();
            DVM.orders = context.Order.Include(O => O.Locations).Include(O => O.Account);

            DVM.locations = context.Location.ToList();

            //EF core end

            return View(DVM);
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {

            //EF core start
            CrestContext context = new CrestContext();
            Order order = context.Order.FirstOrDefault(o => o.OrderId == id);
            context.Order.Remove(order);
            context.SaveChangesAsync();
            //EF core end

            return new RedirectResult("/Admin/UserAccounts");
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
        public IActionResult EditOrder(Order editedorder, int UpdateId, string UpdatedCarType, string UpdatedLocations, string UpdatedAccount, string UpdatedOrigin, string UpdatedDestination, string UpdatedReceiveDate, string UpdatedDeliveryDate)
        {

            ////EF core start
            editedorder.OrderId = UpdateId;
            CrestContext context = new CrestContext();
            Order order = new Order();
            Location location = new Location();
            var Origin = context.Location.Where(a => a.OrderId == editedorder.OrderId).Where(a => a.LocationType == "Origin").FirstOrDefault();
            var Destination = context.Location.Where(a => a.OrderId == editedorder.OrderId).Where(a => a.LocationType == "Destination").FirstOrDefault();
            Origin.Town = UpdatedOrigin;
            Destination.Town = UpdatedDestination;

            order = context.Order.FirstOrDefault(O => O.OrderId == editedorder.OrderId);
            order.CarType = UpdatedCarType;
            order.CollectionDate = System.DateTime.Parse(UpdatedReceiveDate);
            order.DeliveryDate = System.DateTime.Parse(UpdatedDeliveryDate);
            context.Order.Update(order);
            context.Location.Update(Origin);
            context.Location.Update(Destination);
            context.SaveChanges();
            ////EF core end





            return RedirectToAction("Dashboard");
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Order()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Order(OrderViewModel orderviewmodel)
        {
            ViewData["Title"] = "Order";

            //Recaptcha code begins here


            //var recaptcha = await _recaptcha.Validate(Request);
            //if (!recaptcha.success)
            //    ModelState.AddModelError("Recaptcha", "There was an error validating recatpcha. Please try again!");


            //Recaptcha code ends here


            //EF CORE START

            if(!ModelState.IsValid)
            {
                return View(!ModelState.IsValid ? orderviewmodel : new OrderViewModel());
            }
            else
            {

                CrestContext Ordercontext = new CrestContext();
                CrestContext Placecontext = new CrestContext();
                CrestContext Addresscontext = new CrestContext();

                CrestContext FindOrder = new CrestContext();

                Order order = new Order();

                Location origin = new Location();
                Location destination = new Location();

                Address originaddress1 = new Address();
                Address originaddress2 = new Address();
                Address originaddress3 = new Address();

                Address destinationaddress1 = new Address();
                Address destinationaddress2 = new Address();
                Address destinationaddress3 = new Address();

                Account curaccount = Ordercontext.Account.FirstOrDefault(A => A.Id == _userManager.GetUserId(User as ClaimsPrincipal));
                Ordercontext.Attach(curaccount).State = EntityState.Unchanged;
                order.Account = curaccount as Account;


                originaddress1.AddressBody = orderviewmodel.OriginAddress;

                originaddress2.AddressBody = orderviewmodel.OriginAddress2;

                originaddress3.AddressBody = orderviewmodel.OriginAddress3;



                destinationaddress1.AddressBody = orderviewmodel.DestinationAddress;

                destinationaddress2.AddressBody = orderviewmodel.DestinationAddress2;

                destinationaddress3.AddressBody = orderviewmodel.DestinationAddress3;

                origin.Recipient = orderviewmodel.OriginRecipient;
                origin.Company = orderviewmodel.OriginCompany;
                origin.Town = orderviewmodel.OriginTown;
                origin.PostCode = orderviewmodel.OriginPostcode;
                origin.LocationType = "Origin";


                destination.Recipient = orderviewmodel.DestinationRecipient;
                destination.Company = orderviewmodel.DestinationCompany;
                destination.Town = orderviewmodel.DestinationTown;
                destination.PostCode = orderviewmodel.DestinationPostcode;
                destination.LocationType = "Destination";

                order.OrderDate = System.DateTime.Now;
                order.CollectionDate = orderviewmodel.CollectionDate;
                order.DeliveryDate = orderviewmodel.DeliveryDate;
                order.CarType = orderviewmodel.CarType;
                order.Price = "0";
                order.State = "1";

                Ordercontext.Order.Add(order);
                Ordercontext.SaveChanges();

                Order savedOrder = FindOrder.Order.LastOrDefault();
                FindOrder.Attach(savedOrder).State = EntityState.Unchanged;

                origin.OrderId = order.OrderId;
                destination.OrderId = order.OrderId;

                IList<Location> locations = new List<Location>();
                locations.Add(origin);
                locations.Add(destination);

                Placecontext.Location.AddRange(locations);
                Placecontext.SaveChanges();

                originaddress1.LocationId = origin.LocationId;
                originaddress2.LocationId = origin.LocationId;
                originaddress3.LocationId = origin.LocationId;

                destinationaddress1.LocationId = destination.LocationId;
                destinationaddress2.LocationId = destination.LocationId;
                destinationaddress3.LocationId = destination.LocationId;

                IList<Address> addresses = new List<Address>();
                addresses.Add(originaddress1);
                if (originaddress2.AddressBody != null)
                {
                    addresses.Add(originaddress2);
                }
                if (originaddress3.AddressBody != null)
                {
                    addresses.Add(originaddress3);
                }
                addresses.Add(destinationaddress1);
                if (destinationaddress2.AddressBody != null)
                {
                    addresses.Add(destinationaddress2);
                }
                if (destinationaddress3 != null)
                {
                    addresses.Add(destinationaddress3);
                }

                Addresscontext.Address.AddRange(addresses);
                Addresscontext.SaveChanges();

                return View();

                //EF CORE END
            }




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

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> AdminSettingBill()
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
        public async Task<IActionResult> AdminSettingBill(Account UpdatedAccount)
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


            return RedirectToAction("AdminSettingBill");

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
        public async Task<IActionResult> AdminAccounts(string MyType, string UserName, string EmailAddress, string Password, string ConfirmPassword, string FirstName, string LastName, string returnUrl = null)
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
        public async Task<IActionResult> AdminAccountEdit(string UpdateId, string UpdatedUserName, string UpdatedFirstName, string UpdatedLastName, string UpdatedAdminType)
        {

            //EF core start
            Account Account = await _userManager.FindByIdAsync(UpdateId);

            Account.UserName = UpdatedUserName;
            Account.FirstName = UpdatedFirstName;
            Account.LastName = UpdatedLastName;
            Account.AdminType = UpdatedAdminType;
            Account.Level = UpdatedAdminType;

            await _userManager.UpdateAsync(Account);

            //EF core end


            return new RedirectResult("/Admin/AdminAccounts");
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
        public async Task<IActionResult> AdminAccountActive(string AdminId)
        {
            
            //EF core start

            Account Account = await _userManager.FindByIdAsync(AdminId);

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

        public async Task<ActionResult> SystemUserDelete(string DeleteId, string returnUrl)
        {

            Account account = await _userManager.FindByIdAsync(DeleteId);
            await _userManager.DeleteAsync(account);

            return RedirectToAction(returnUrl);
        }

        public async Task<IActionResult> SystemUserEdit(string UpdateId, string UserName, string FirstName, string Surname, string PhoneNumber, string EmailAddress)
        {


            //EF core start
            Account account = await _userManager.FindByIdAsync(UpdateId);

            account.UserName = UserName;
            account.FirstName = FirstName;
            account.LastName = Surname;
            account.PhoneNumber = PhoneNumber;
            account.Email = EmailAddress;

            await _userManager.UpdateAsync(account);
            //EF core end

            return new RedirectResult("/Admin/UserAccounts");
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

        [HttpPost]
        public async Task<IActionResult> UserAccountActive(string UserId)
        {

            //EF core start
            //CrestContext context = new CrestContext();
            //User user= new User();

            Account Account = await _userManager.FindByIdAsync(UserId);
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
        public async Task<IActionResult> Login(ViewModels.AccountViewModels.LoginViewModel model)
        {


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
                if (result.Succeeded && Account.IsAdmin && Account.IsActive && Account.AdminType == "Limited Admin")
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
        public async Task<IActionResult> ForgotPassword(ViewModels.ForgotPasswordViewModel model)
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
        public async Task<IActionResult> ResetPassword(ViewModels.ResetPasswordViewModel model)
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

        public async Task<IActionResult> ConfirmedBill(int? pageNumber)
        {
            CrestContext context = new CrestContext();

            IEnumerable<Bill> billss = context.Bill.Where(a => a.Confirmation == "Confirmed");
            ViewData["Title"] = "Confirmed";

            PaginatedList<Bill> BillList = await PaginatedList<Bill>.CreateAsunc((IQueryable<Bill>)billss, pageNumber ?? 1, 2);

            return View(BillList);
        }

        public async Task<IActionResult> NotConfirmedBill(int? pageNumber)
        {
            CrestContext context = new CrestContext();

            IEnumerable<Bill> billss = context.Bill.Where(a => a.Confirmation == "NotConfirmed");
            ViewData["Title"] = "NotConfirmed";

            PaginatedList<Bill> BillList = await PaginatedList<Bill>.CreateAsunc((IQueryable<Bill>)billss, pageNumber ?? 1, 2);

            return View(BillList);
        }

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
        public IActionResult Bill(BillViewModel NewBill)
        {
            CrestContext Context = new CrestContext();
            Bill CreateBill = new Bill();
            CreateBill.Date = DateTime.Now;
            CreateBill.Confirmation = "NotConfirmed";
            if (NewBill.File == null)
            {
                return new RedirectResult("~/Admin/Bill");
                ModelState.AddModelError("", "Please select a file.");
            }
            else if (NewBill.File.Length != null)
            {
            string filename = Path.GetFileNameWithoutExtension(NewBill.File.FileName);
            CreateBill.FileName = filename;
               
                using (var ms = new MemoryStream())
                {
                    NewBill.File.CopyTo(ms);
                    var FileByte = ms.ToArray();
                    CreateBill.File = FileByte;
                }
            }
            Context.Bill.Add(CreateBill);
            Context.SaveChanges();
            ModelState.AddModelError("", "file sent.");
            return new RedirectResult("~/Admin/Bill");
        }

        [HttpGet]
        public async Task<IActionResult> ConfirmBill(int id)
        {
            CrestContext context = new CrestContext();
            Bill mybill = new Bill();
            mybill = context.Bill.Where(B => B.BillID == id).SingleOrDefault();

            if(mybill.Confirmation == "NotConfirmed")
            { 
                mybill.Confirmation = "Confirmed";
                context.Update(mybill);
                context.SaveChanges();

                return RedirectToAction("NotConfirmedBill");
            }
            else
            {
                mybill.Confirmation = "NotConfirmed";
                context.Update(mybill);
                context.SaveChanges();

                return RedirectToAction("ConfirmedBill");
            }


        }

        [HttpGet]
        public IActionResult Articles()
        {
            //EF core start

            //CrestContext context = new CrestContext();
            //IEnumerable<Article> articles = context.Article.ToList();

            //EF core end
            return View();
        }

        [HttpGet]
        public IActionResult AddArticle()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddArticle(AddArticleViewModel NewArticle)
        {
            CrestContext Context = new CrestContext();

            Article article = new Article();

            Tag tag;

            ArticleTag articleTag;


            article.Date = DateTime.Now;

            article.Title = NewArticle.Title;
            article.ShortBody = NewArticle.ShortBody;
            article.Body = NewArticle.Body;
            Context.Article.Add(article);
            Context.SaveChanges();

            foreach(var item in NewArticle.Tags)
            {
                tag = new Tag { Name = item };
                Context.Tag.Add(tag);
                Context.SaveChanges();

                articleTag = new ArticleTag { ArticleId = article.ArticleId, TagId = tag.TagId};
                Context.ArticleTag.Add(articleTag);
                Context.SaveChanges();
            }

            //  Upload file started

            CrestContext context = new CrestContext();
            Image image = new Image();
            image.ImageName = NewArticle.ArticleImage.FileName;
            image.ArticleId = article.ArticleId;
            context.Image.Add(image);

            var uploadsRootFolder = Path.Combine(_environment.WebRootPath, "uploads");
            if (!Directory.Exists(uploadsRootFolder))
            {
                Directory.CreateDirectory(uploadsRootFolder);
            }


            if (NewArticle.ArticleImage == null || NewArticle.ArticleImage.Length == 0)
            {
                await Response.WriteAsync("Error");

            }

            var filePath = Path.Combine(uploadsRootFolder, NewArticle.ArticleImage.FileName);

            using (var fileStream = new FileStream(filePath, FileMode.Create))
            {
                await NewArticle.ArticleImage.CopyToAsync(fileStream).ConfigureAwait(false);
            }

            //Upload file ended

            Context.SaveChanges();
            return View();
        }
        [HttpPost]
        public IActionResult DeleteArticle(int id)
        {

            //EF core start
            CrestContext context = new CrestContext();
            Article article = context.Article.FirstOrDefault(o => o.ArticleId == id);
            context.Article.Remove(article);
            context.SaveChangesAsync();
            //EF core end

            return View();
        }

        [HttpGet]
        public IActionResult Article(int id)
        {
            return View();
        }

        [HttpPost]
        public IActionResult EditArticle(int id, Article article)
        {
            ////EF core start
            article.ArticleId = id;
            CrestContext context = new CrestContext();
            Article article1= new Article();

            article1 = context.Article.FirstOrDefault(O => O.ArticleId == article.ArticleId);
            article1.Body = article.Body;
            article1.Title = article.Title;
            context.Article.Update(article1);
            context.SaveChanges();
            ////EF core end
            return new RedirectResult("Admin/Articles");
        }
    }
}
using CrestCouriers_Career.Data;
using CrestCouriers_Career.Models;
using CrestCouriers_Career.ViewModels;
using CrestCouriers_Career.ViewModels.AccountViewModels;
using CrestCouriers_Career.ViewModels.User;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using MimeKit;
using MimeKit.Utils;
using MailKit.Net.Smtp;
using reCAPTCHA.AspNetCore;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace CrestCouriers_Career.Controllers
{
    public class UserController : Controller
    {

        private IHostingEnvironment _environment;

        private IRecaptchaService _recaptcha;

        private readonly UserManager<Account> _userManager;

        private readonly SignInManager<Account> _signInManager;

        private readonly ILogger _logger;
       
        public UserController(IHostingEnvironment environment, IRecaptchaService recaptcha, UserManager<Account> userManager, SignInManager<Account> signInManager, ILogger<Account> logger)
        {
            _environment = environment;

            _recaptcha = recaptcha;

            _userManager = userManager;

            _signInManager = signInManager;

            _logger = logger;
        }

        private void AddErrors(IdentityResult result)
        {
            foreach(var error in result.Errors)
            {
                ModelState.AddModelError(string.Empty, error.Description);
            }
        }

        private IActionResult RedirectToLocal(string returnUrl)
        {
            if(Url.IsLocalUrl(returnUrl))
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
        
        [HttpGet]
        [AllowAnonymous]
        public IActionResult Register(string returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl;
            return View();
        }


        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterViewModel model, string returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl;
            //ViewData["RepeatedUser"] = "no";

            if (ModelState.IsValid)
            {
                //ViewData["Title"] = "register";

                ////Recaptcha code begins here


                ////var recaptcha = await _recaptcha.Validate(Request);
                ////if (!recaptcha.success)
                ////    ModelState.AddModelError("Recaptcha", "There was an error validating recatpcha. Please try again!");


                ////Recaptcha code ends here

                var user = new Account { UserName = model.Username, Email = model.Email, IsUser = true, FirstName = model.Firstname, LastName = model.Lastname, IsActive = false, IsAdmin = false};
                var result = await _userManager.CreateAsync(user, model.Password);

                if(result.Succeeded)
                {
                    _logger.LogInformation("User created a new account with password.");

                    await _signInManager.SignInAsync(user, isPersistent: false);


                    _logger.LogInformation("User created new account with password.");
                    return RedirectToLocal(returnUrl);
                }
                AddErrors(result);
            }
                return View();
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
        public async Task<IActionResult> Login(LoginViewModel model)
        {

            if(ModelState.IsValid)
            {
                CrestContext context = new CrestContext();
                var result = await _signInManager.PasswordSignInAsync(model.Username,model.Password,model.RememberMe, lockoutOnFailure: false);
                Account Account = await context.Account.Where(A=>A.UserName == model.Username).FirstOrDefaultAsync();
                if(result.Succeeded && Account.IsUser && Account.IsActive)
                {
                    
                    _logger.LogInformation("User logged in.");
                    return RedirectToAction(nameof(Dashboard));

                }
                if(result.IsLockedOut)
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
            else
            { 

                return View();
            }
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
            if(ModelState.IsValid)
            {
                var user = await _userManager.FindByEmailAsync(model.Email);
                if(user != null && await _userManager.IsEmailConfirmedAsync(user))
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
            if(token == null || email == null)
            {
                ModelState.AddModelError("", "Invalid password reset token.");
            }
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> ResetPassword(ResetPasswordViewModel model)
        {
            if(ModelState.IsValid)
            {
                var user = await _userManager.FindByEmailAsync(model.Email);
                if(user != null)
                {
                    var result = await _userManager.ResetPasswordAsync(user, model.Token, model.Password);
                    if(result.Succeeded)
                    {
                        return View();
                    }
                    foreach(var error in result.Errors)
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

        public IActionResult Dashboard()
        {

            //EF core start

            CrestContext context = new CrestContext();
            Account Account = context.Account.FirstOrDefault(A => A.Id == _userManager.GetUserId(User as ClaimsPrincipal));

            CrestContext GetOrders = new CrestContext();
            DashboardViewModel DVM = new DashboardViewModel();

            DVM.orders = context.Order.Where(O => O.Account == Account).ToList();

            DVM.locations = context.Location.ToList();

            //EF core end

            return View(DVM);

        }

        public ActionResult Delete(int id)
        {

            //EF core start
            CrestContext context = new CrestContext();
            Order order = context.Order.FirstOrDefault(o => o.OrderId == id);
            context.Order.Remove(order);
            context.SaveChangesAsync();
            //EF core end

            return new RedirectResult("/User/Dashboard");
        }

        public IActionResult Edit(int id)
        {

            ViewData["Orderid"] = HttpContext.Session.GetString("OrderIDSession");

            //EF core start
            CrestContext context = new CrestContext();
            Order order = context.Order.FirstOrDefault(o => o.OrderId == id);

            //EF core end


            return View(order);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult EditOrder(Order editedorder,int UpdateId , string UpdatedCarType, string UpdatedLocations , string UpdatedAccount ,string UpdatedOrigin, string UpdatedDestination , string UpdatedReceiveDate ,  string UpdatedDeliveryDate)
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
            if(originaddress2.AddressBody != null)
            { 
                addresses.Add(originaddress2);
            }
            if (originaddress3.AddressBody != null)
            {
                addresses.Add(originaddress3);
            }
            addresses.Add(destinationaddress1);
            if(destinationaddress2.AddressBody != null)
            { 
                addresses.Add(destinationaddress2);
            }
            if(destinationaddress3 != null)
            { 
                addresses.Add(destinationaddress3);
            }

            Addresscontext.Address.AddRange(addresses);
            Addresscontext.SaveChanges();


            //EF CORE END

            return View(!ModelState.IsValid ? orderviewmodel : new OrderViewModel());

        }

        public IActionResult orderlist()
        {
            return View();
        }
        [HttpGet]
        [AllowAnonymous]
        public IActionResult UserInformation()
        {

            //EF
            CrestContext context = new CrestContext();
            Account Account = context.Account.FirstOrDefault(A => A.Id == _userManager.GetUserId(User as ClaimsPrincipal));
            //EF
            return View(Account);

        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UserInformation(Account UpdatedAccount)
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



            return new RedirectResult("/User/UserInformation");
        }

        public async Task<IActionResult> Logout()
        {
            if(User.Identity.IsAuthenticated)
            {
                await HttpContext.SignOutAsync();
                return RedirectToAction("Login");
            }
            return View();
        }
    }
}
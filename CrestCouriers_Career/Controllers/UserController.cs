using CrestCouriers_Career.Data;
using CrestCouriers_Career.Models;
using CrestCouriers_Career.ViewModels;
using CrestCouriers_Career.ViewModels.AccountViewModels;
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



                var user = new Account { UserName = model.Username, Email = model.Email, IsUser = true, FirstName = model.Firstname, LastName = model.Lastname, IsActive = false, IsAdmin = false, AdminType = false};
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
        public async Task<IActionResult> Login(LoginViewModel model,string returnUrl = null)
        {

            ViewData["ReturnUrl"] = returnUrl;

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
            IEnumerable<Order> orders = context.Order.Where(O => O.Account == Account);

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
        public IActionResult EditOrder(Order editedorder)
        {

            //EF core start
            CrestContext context = new CrestContext();
            Order order = new Order();
            order = context.Order.FirstOrDefault(O => O.OrderId == editedorder.OrderId);
            editedorder.OrderDate = order.OrderDate;
            editedorder.Price = order.Price;
            editedorder.State = order.State;
            //editedorder.Id = order.Id;
            CrestContext editcontext = new CrestContext();
            editcontext.Attach(editedorder).State = EntityState.Modified;
            editcontext.SaveChangesAsync();
            //EF core end

            return RedirectToAction("Dashboard");
        }


        public IActionResult Order()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Order(Order order)
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
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

namespace CrestCouriers_Career.Controllers
{
    public class HomeController : Controller
    {

        private IHostingEnvironment _environment;

        private IRecaptchaService _recaptcha;
        public HomeController(IHostingEnvironment environment, IRecaptchaService recaptcha)
        {
            _environment = environment;

            _recaptcha = recaptcha;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {

            ViewData["Message"] = "Your application description page.";

            return View();

        }

        public IActionResult Career_delivery()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Title"] = "contact";
            return View();

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Contact(Contact Contact, EmailRequest emailRequest)
        {

            ViewData["Title"] = "contact";

            //Recaptcha code begins here


            var recaptcha = await _recaptcha.Validate(Request);
            if (!recaptcha.success)
                ModelState.AddModelError("Recaptcha", "There was an error validating recatpcha. Please try again!");


            //Recaptcha code ends here


            string myurl = $"{this.Request.Scheme}://{this.Request.Host}{this.Request.PathBase}";
            Dal connection = new Dal(myurl);

            SqlCommand cmd = new SqlCommand("sp_Crest_contact", connection.connect())
            {
                CommandType = CommandType.StoredProcedure
            };
            cmd.Parameters.AddWithValue("@FullName", Contact.FullName);
            cmd.Parameters.AddWithValue("@EmailAddress", Contact.EmailAddress);
            cmd.Parameters.AddWithValue("@PhoneNumber", Contact.PhoneNumber);
            cmd.Parameters.AddWithValue("@Subject", Contact.Subject);
            cmd.Parameters.AddWithValue("@Message", Contact.Message);


            cmd.ExecuteNonQuery();

            connection.disconnect();


            ///////    Send Email     ///////
            MimeMessage message = new MimeMessage();

            MailboxAddress from = new MailboxAddress("CrestCouriers", "test@crestcouriers.com");
            message.From.Add(from);

            MailboxAddress to = new MailboxAddress("CrestCouriers", "test@crestcouriers.com");
            message.To.Add(to);

            message.Subject = " Contact";

            BodyBuilder bodyBuilder = new BodyBuilder();
            //ViewData["filepath"] = @"C:\Users\mjn110\Documents\GitHub\MainProject\CrestCouriers_Career\wwwroot\Email\newuser.png";
            var usericfile = System.IO.File.OpenRead(_environment.WebRootPath + @"\Email\newuser.png");
            MemoryStream newms = new MemoryStream();
            await usericfile.CopyToAsync(newms);


            var mybody = @System.IO.File.ReadAllText(_environment.WebRootPath + @"\Email\emailbody-contact.html");

            mybody = mybody.Replace("Value00", Contact.FullName);
            mybody = mybody.Replace("Value01", Contact.FullName);
            mybody = mybody.Replace("Value02", Contact.EmailAddress);
            mybody = mybody.Replace("Value03", Contact.PhoneNumber);
            mybody = mybody.Replace("Value04", Contact.Subject);
            mybody = mybody.Replace("Value05", Contact.Message);



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


            client.Send(message);
            //First email


            MimeMessage message2 = new MimeMessage();

            MailboxAddress from2 = new MailboxAddress("CrestCouriers", "test@crestcouriers.com");
            message2.From.Add(from2);

            MailboxAddress to2 = new MailboxAddress(Contact.FullName + " " + Contact.Subject, Contact.EmailAddress);
            message2.To.Add(to2);

            message2.Subject = "CrestCouriers";


            BodyBuilder bobu = new BodyBuilder
            {
                HtmlBody = @System.IO.File.ReadAllText(_environment.WebRootPath + @"\Email\emailreply-contact.html")
            };




            // var logo = System.IO.File.OpenRead(_environment.WebRootPath + @"/img/logo.png");
            MemoryStream myms = new MemoryStream();
            await usericfile.CopyToAsync(myms);

            var embedlogo = bobu.LinkedResources.Add(_environment.WebRootPath + @"/img/logo.png");
            embedlogo.ContentId = MimeUtils.GenerateMessageId();

            bobu.HtmlBody = bobu.HtmlBody.Replace("{", "{{");
            bobu.HtmlBody = bobu.HtmlBody.Replace("}", "}}");
            bobu.HtmlBody = bobu.HtmlBody.Replace("{{0}}", "{0}");

            bobu.HtmlBody = string.Format(bobu.HtmlBody, embedlogo.ContentId);


            message2.Body = bobu.ToMessageBody();

            SmtpClient client2 = new SmtpClient();
            client2.Connect("smtp.gmail.com", 465, true);
            client2.Authenticate("crestcouriers@gmail.com", "CRESTcouriers123");


            client2.Send(message2);
            client2.Disconnect(true);
            client2.Dispose();
            ///////   End Send Email    //////////






            return View(!ModelState.IsValid ? Contact : new Contact());
            return new RedirectResult("/Home/Career_delivery");

        }


        public IActionResult Privacy()
        {


            return View();
        }

        public IActionResult Services()
        {

            return View();

        }

        public IActionResult branches()
        {
            return View();
        }

        public IActionResult careerinfo(string id)
        {
            if (id == null)
            {
                return new RedirectResult("/Home/careertype");
            }
            else
            {

                ViewData["City"] = id;
                if (id == "Birmingham")
                {
                    ViewData["CityMap"] = "https://www.google.com/maps/embed?pb=!1m18!1m12!1m3!1d155526.29467269467!2d-2.003714890183722!3d52.47735487694842!2m3!1f0!2f0!3f0!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0x4870942d1b417173%3A0xca81fef0aeee7998!2sBirmingham!5e0!3m2!1sen!2suk!4v1586544000369!5m2!1sen!2suk";
                }
                else if (id == "Coventry")
                {
                    ViewData["Citymap"] = "https://www.google.com/maps/embed?pb=!1m18!1m12!1m3!1d77875.64936090495!2d-1.584957836701814!3d52.41367085814577!2m3!1f0!2f0!3f0!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0x4870b151656e22b7%3A0x4f660f5564f0689!2sCoventry!5e0!3m2!1sen!2suk!4v1586544031949!5m2!1sen!2suk";
                }
                else if (id == "Leeds")
                {
                    ViewData["Citymap"] = "https://www.google.com/maps/embed?pb=!1m18!1m12!1m3!1d150788.90157917945!2d-1.6758143576752904!3d53.80592089177427!2m3!1f0!2f0!3f0!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0x48793e4ada64bd99%3A0x51adbafd0213dca9!2sLeeds!5e0!3m2!1sen!2suk!4v1586543961493!5m2!1sen!2suk";
                }
                else if (id == "Oldham")
                {
                    ViewData["Citymap"] = "https://www.google.com/maps/embed?pb=!1m18!1m12!1m3!1d75878.79433501452!2d-2.1637169125702176!3d53.536123038778264!2m3!1f0!2f0!3f0!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0x487bb0aa67777af1%3A0x18b3b8d9a96b3258!2sOldham!5e0!3m2!1sen!2suk!4v1586543894888!5m2!1sen!2suk";
                }
                return View();

            }
        }

        public IActionResult careertype()
        {

            return View();

        }
        public IActionResult Career(string id)
        {
            if (id == null)
            {
                return new RedirectResult("/Home/careertype");
            }
            else
            {
                ViewData["City"] = id;
                HttpContext.Session.SetString("careertype", JsonConvert.SerializeObject(id));
            }
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Career(RegCareer career, IFormFile UploadCV , EmailRequest emailRequest)
        {

            

            //Recaptcha code begins here

            
            var recaptcha = await _recaptcha.Validate(Request);
            if (!recaptcha.success)
                ModelState.AddModelError("Recaptcha", "There was an error validating recatpcha. Please try again!");


            //Recaptcha code ends here

            string myurl = $"{this.Request.Scheme}://{this.Request.Host}{this.Request.PathBase}";
            Dal connection = new Dal(myurl);



            //Dal con = new Dal();
            SqlCommand cmd = new SqlCommand("sp_Crest_career", connection.connect())
            {
                CommandType = CommandType.StoredProcedure
            };
            cmd.Parameters.AddWithValue("@FirstName", career.FirstName);
            cmd.Parameters.AddWithValue("@LastName", career.LastName);
            cmd.Parameters.AddWithValue("@Gender", career.Gender);
            cmd.Parameters.AddWithValue("@Age", career.Age);
            cmd.Parameters.AddWithValue("@Married", career.Married);
            cmd.Parameters.AddWithValue("@HouseNumber", career.HouseNumber);
            cmd.Parameters.AddWithValue("@RoadName", career.RoadName);
            cmd.Parameters.AddWithValue("@City", career.City);
            cmd.Parameters.AddWithValue("@PostCode", career.PostCode);
            cmd.Parameters.AddWithValue("@DriverLicence", career.DriverLicence);
            cmd.Parameters.AddWithValue("@Accident", career.Accident);
            cmd.Parameters.AddWithValue("@DBS", career.DBS);
            cmd.Parameters.AddWithValue("@PhoneNumber", career.PhoneNumber);
            cmd.Parameters.AddWithValue("@Email", career.Email);
            cmd.Parameters.AddWithValue("@UploadCV", UploadCV.FileName);

            cmd.ExecuteNonQuery();
            connection.disconnect();

            //  Upload file started

            var uploadsRootFolder = Path.Combine(_environment.WebRootPath, "uploads");
            if (!Directory.Exists(uploadsRootFolder))
            {
                Directory.CreateDirectory(uploadsRootFolder);
            }


            if (UploadCV == null || UploadCV.Length == 0)
            {
                await Response.WriteAsync("Error");
            }

            var filePath = Path.Combine(uploadsRootFolder, UploadCV.FileName);

            using (var fileStream = new FileStream(filePath, FileMode.Create))
            {
                await UploadCV.CopyToAsync(fileStream).ConfigureAwait(false);
            }

            //Upload file ended


            ///////    Send Email     ///////
            MimeMessage message = new MimeMessage();

            MailboxAddress from = new MailboxAddress("CrestCouriers", "test@crestcouriers.com");
            message.From.Add(from);

            MailboxAddress to = new MailboxAddress("CrestCouriers", "test@crestcouriers.com");
            message.To.Add(to);

            message.Subject = "Register for career";

            BodyBuilder bodyBuilder = new BodyBuilder();
            //ViewData["filepath"] = @"C:\Users\mjn110\Documents\GitHub\MainProject\CrestCouriers_Career\wwwroot\Email\newuser.png";
            var usericfile = System.IO.File.OpenRead(_environment.WebRootPath + @"\Email\newuser.png");
            MemoryStream newms = new MemoryStream();
            await usericfile.CopyToAsync(newms);

            var careercity = JsonConvert.DeserializeObject<string>(HttpContext.Session.GetString("careertype"));

            var mybody = @System.IO.File.ReadAllText(_environment.WebRootPath + @"\Email\emailbody-career.html");
            
            mybody = mybody.Replace("Value00", career.FirstName + " " + career.LastName);
            mybody = mybody.Replace("Value01", career.FirstName);
            mybody = mybody.Replace("Value02", career.LastName);
            mybody = mybody.Replace("Value03", career.Gender);
            mybody = mybody.Replace("Value04", career.Age);
            mybody = mybody.Replace("Value05", career.Married);
            mybody = mybody.Replace("Value06", career.HouseNumber);
            mybody = mybody.Replace("Value07", career.RoadName);
            mybody = mybody.Replace("Value08", career.City);
            mybody = mybody.Replace("Value09", career.PostCode);
            mybody = mybody.Replace("Value10", career.DriverLicence);
            mybody = mybody.Replace("Value11", career.Accident);
            mybody = mybody.Replace("Value12", career.DBS);
            mybody = mybody.Replace("Value13", career.PhoneNumber);
            mybody = mybody.Replace("Value14", career.Email);
            mybody = mybody.Replace("Value15", careercity);


            bodyBuilder.HtmlBody = mybody;

            var usericon = bodyBuilder.LinkedResources.Add(_environment.WebRootPath + @"/Email/newuser.png");
            usericon.ContentId = MimeUtils.GenerateMessageId();

            bodyBuilder.HtmlBody = bodyBuilder.HtmlBody.Replace("{", "{{");
            bodyBuilder.HtmlBody = bodyBuilder.HtmlBody.Replace("}", "}}");
            bodyBuilder.HtmlBody = bodyBuilder.HtmlBody.Replace("{{0}}", "{0}");

            bodyBuilder.HtmlBody = string.Format(bodyBuilder.HtmlBody, usericon.ContentId);



            MemoryStream ms = new MemoryStream();
            await UploadCV.CopyToAsync(ms).ConfigureAwait(false);

            bodyBuilder.Attachments.Add(UploadCV.FileName, ms.ToArray()); //ToArray method = memorystream to byte


            message.Body = bodyBuilder.ToMessageBody();


            SmtpClient client = new SmtpClient();
            client.Connect("smtp.gmail.com",465,true);
            client.Authenticate("crestcouriers@gmail.com", "CRESTcouriers123");

            

            

            client.Send(message);
            //First email


            MimeMessage message2 = new MimeMessage();

            MailboxAddress from2 = new MailboxAddress("CrestCouriers", "test@crestcouriers.com");
            message2.From.Add(from2);

            MailboxAddress to2 = new MailboxAddress(career.FirstName + " " + career.LastName, career.Email);
            message2.To.Add(to2);

            message2.Subject = "CrestCouriers";


            BodyBuilder bobu = new BodyBuilder
            {
                HtmlBody = @System.IO.File.ReadAllText(_environment.WebRootPath + @"\Email\emailreply-career.html")
            };




            // var logo = System.IO.File.OpenRead(_environment.WebRootPath + @"/img/logo.png");
            MemoryStream myms = new MemoryStream();
            await usericfile.CopyToAsync(myms);

            var embedlogo = bobu.LinkedResources.Add(_environment.WebRootPath + @"/img/logo.png");
            embedlogo.ContentId = MimeUtils.GenerateMessageId();

            bobu.HtmlBody = bobu.HtmlBody.Replace("{", "{{");
            bobu.HtmlBody = bobu.HtmlBody.Replace("}", "}}");
            bobu.HtmlBody = bobu.HtmlBody.Replace("{{0}}", "{0}");

            bobu.HtmlBody = string.Format(bobu.HtmlBody, embedlogo.ContentId);


            message2.Body = bobu.ToMessageBody();

            SmtpClient client2 = new SmtpClient();
            client2.Connect("smtp.gmail.com",465,true);
            client2.Authenticate("crestcouriers@gmail.com", "CRESTcouriers123");


            client2.Send(message2);
            client2.Disconnect(true);
            client2.Dispose();
            ///////   End Send Email    //////////






            //return View(!ModelState.IsValid ? career : new RegCareer());
            return new RedirectResult("/Home/Career_delivery");

        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

﻿using System;
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
using CrestCouriers_Career.Data;
using AspNetCore.SEOHelper.Sitemap;
using Microsoft.EntityFrameworkCore;


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

        [Route("")]
        [Route("Index")]
        public IActionResult Index()
        {
            var list = new List<SitemapNode>();

            list.Add(new SitemapNode { LastModified = DateTime.UtcNow, Priority = 1.0, Url = "https://www.crestcouriers.co.uk", Frequency = SitemapFrequency.Yearly });
            list.Add(new SitemapNode { LastModified = DateTime.UtcNow, Priority = 0.7, Url = "https://www.crestcouriers.co.uk/About", Frequency = SitemapFrequency.Never });
            list.Add(new SitemapNode { LastModified = DateTime.UtcNow, Priority = 0.7, Url = "https://www.crestcouriers.co.uk/Services", Frequency = SitemapFrequency.Never });
            list.Add(new SitemapNode { LastModified = DateTime.UtcNow, Priority = 0.7, Url = "https://www.crestcouriers.co.uk/Branches", Frequency = SitemapFrequency.Yearly });
            list.Add(new SitemapNode { LastModified = DateTime.UtcNow, Priority = 0.7, Url = "https://www.crestcouriers.co.uk/Contact", Frequency = SitemapFrequency.Never });

            list.Add(new SitemapNode { LastModified = DateTime.UtcNow, Priority = 0.8, Url = "https://www.crestcouriers.co.uk/Blog", Frequency = SitemapFrequency.Weekly });

            list.Add(new SitemapNode { LastModified = DateTime.UtcNow, Priority = 0.5, Url = "https://www.crestcouriers.co.uk/Details?ArticleId=zero", Frequency = SitemapFrequency.Never });
            list.Add(new SitemapNode { LastModified = DateTime.UtcNow, Priority = 0.5, Url = "https://www.crestcouriers.co.uk/Details?ArticleId=one", Frequency = SitemapFrequency.Never });
            list.Add(new SitemapNode { LastModified = DateTime.UtcNow, Priority = 0.5, Url = "https://www.crestcouriers.co.uk/Details?ArticleId=two", Frequency = SitemapFrequency.Never });
            list.Add(new SitemapNode { LastModified = DateTime.UtcNow, Priority = 0.5, Url = "https://www.crestcouriers.co.uk/Details?ArticleId=three", Frequency = SitemapFrequency.Never });
            list.Add(new SitemapNode { LastModified = DateTime.UtcNow, Priority = 0.5, Url = "https://www.crestcouriers.co.uk/Details?ArticleId=four", Frequency = SitemapFrequency.Never });
            list.Add(new SitemapNode { LastModified = DateTime.UtcNow, Priority = 0.5, Url = "https://www.crestcouriers.co.uk/Details?ArticleId=five", Frequency = SitemapFrequency.Never });
            list.Add(new SitemapNode { LastModified = DateTime.UtcNow, Priority = 0.5, Url = "https://www.crestcouriers.co.uk/Details?ArticleId=six", Frequency = SitemapFrequency.Never });
            list.Add(new SitemapNode { LastModified = DateTime.UtcNow, Priority = 0.5, Url = "https://www.crestcouriers.co.uk/Details?ArticleId=seven", Frequency = SitemapFrequency.Never });
            list.Add(new SitemapNode { LastModified = DateTime.UtcNow, Priority = 0.5, Url = "https://www.crestcouriers.co.uk/Details?ArticleId=eight", Frequency = SitemapFrequency.Never });
            list.Add(new SitemapNode { LastModified = DateTime.UtcNow, Priority = 0.5, Url = "https://www.crestcouriers.co.uk/Details?ArticleId=nine", Frequency = SitemapFrequency.Never });
            list.Add(new SitemapNode { LastModified = DateTime.UtcNow, Priority = 0.5, Url = "https://www.crestcouriers.co.uk/Details?ArticleId=ten", Frequency = SitemapFrequency.Never });
            list.Add(new SitemapNode { LastModified = DateTime.UtcNow, Priority = 0.5, Url = "https://www.crestcouriers.co.uk/Details?ArticleId=eleven", Frequency = SitemapFrequency.Never });
            list.Add(new SitemapNode { LastModified = DateTime.UtcNow, Priority = 0.5, Url = "https://www.crestcouriers.co.uk/Details?ArticleId=twelve", Frequency = SitemapFrequency.Never });
            list.Add(new SitemapNode { LastModified = DateTime.UtcNow, Priority = 0.5, Url = "https://www.crestcouriers.co.uk/Details?ArticleId=thirteen", Frequency = SitemapFrequency.Never });
            list.Add(new SitemapNode { LastModified = DateTime.UtcNow, Priority = 0.5, Url = "https://www.crestcouriers.co.uk/Details?ArticleId=fourteen", Frequency = SitemapFrequency.Never });
            list.Add(new SitemapNode { LastModified = DateTime.UtcNow, Priority = 0.5, Url = "https://www.crestcouriers.co.uk/Details?ArticleId=fifteen", Frequency = SitemapFrequency.Never });
            list.Add(new SitemapNode { LastModified = DateTime.UtcNow, Priority = 0.5, Url = "https://www.crestcouriers.co.uk/Details?ArticleId=sixteen", Frequency = SitemapFrequency.Never });
            list.Add(new SitemapNode { LastModified = DateTime.UtcNow, Priority = 0.5, Url = "https://www.crestcouriers.co.uk/Details?ArticleId=seventeen", Frequency = SitemapFrequency.Never });
            list.Add(new SitemapNode { LastModified = DateTime.UtcNow, Priority = 0.5, Url = "https://www.crestcouriers.co.uk/Details?ArticleId=eighteen", Frequency = SitemapFrequency.Never });
            list.Add(new SitemapNode { LastModified = DateTime.UtcNow, Priority = 0.5, Url = "https://www.crestcouriers.co.uk/Details?ArticleId=nineteen", Frequency = SitemapFrequency.Never });
            list.Add(new SitemapNode { LastModified = DateTime.UtcNow, Priority = 0.5, Url = "https://www.crestcouriers.co.uk/Details?ArticleId=twenty", Frequency = SitemapFrequency.Never });
            list.Add(new SitemapNode { LastModified = DateTime.UtcNow, Priority = 0.5, Url = "https://www.crestcouriers.co.uk/Details?ArticleId=twentyone", Frequency = SitemapFrequency.Never });
            list.Add(new SitemapNode { LastModified = DateTime.UtcNow, Priority = 0.5, Url = "https://www.crestcouriers.co.uk/Details?ArticleId=twentytwo", Frequency = SitemapFrequency.Never });
            list.Add(new SitemapNode { LastModified = DateTime.UtcNow, Priority = 0.5, Url = "https://www.crestcouriers.co.uk/Details?ArticleId=twentythree", Frequency = SitemapFrequency.Never });
            list.Add(new SitemapNode { LastModified = DateTime.UtcNow, Priority = 0.5, Url = "https://www.crestcouriers.co.uk/Details?ArticleId=twentyfour", Frequency = SitemapFrequency.Never });
            list.Add(new SitemapNode { LastModified = DateTime.UtcNow, Priority = 0.5, Url = "https://www.crestcouriers.co.uk/Details?ArticleId=twentyfive", Frequency = SitemapFrequency.Never });
            list.Add(new SitemapNode { LastModified = DateTime.UtcNow, Priority = 0.5, Url = "https://www.crestcouriers.co.uk/Details?ArticleId=twentysix", Frequency = SitemapFrequency.Never });
            list.Add(new SitemapNode { LastModified = DateTime.UtcNow, Priority = 0.5, Url = "https://www.crestcouriers.co.uk/Details?ArticleId=twentyseven", Frequency = SitemapFrequency.Never });

            list.Add(new SitemapNode { LastModified = DateTime.UtcNow, Priority = 0.8, Url = "https://www.crestcouriers.co.uk/Type", Frequency = SitemapFrequency.Yearly });

            list.Add(new SitemapNode { LastModified = DateTime.UtcNow, Priority = 0.5, Url = "https://www.crestcouriers.co.uk/Info?id=Coventry", Frequency = SitemapFrequency.Never });
            list.Add(new SitemapNode { LastModified = DateTime.UtcNow, Priority = 0.6, Url = "https://www.crestcouriers.co.uk/Career?id=Coventry", Frequency = SitemapFrequency.Never });

            list.Add(new SitemapNode { LastModified = DateTime.UtcNow, Priority = 0.5, Url = "https://www.crestcouriers.co.uk/Info?id=Birmingham", Frequency = SitemapFrequency.Never });
            list.Add(new SitemapNode { LastModified = DateTime.UtcNow, Priority = 0.6, Url = "https://www.crestcouriers.co.uk/Career?id=Birmingham", Frequency = SitemapFrequency.Never });

            list.Add(new SitemapNode { LastModified = DateTime.UtcNow, Priority = 0.5, Url = "https://www.crestcouriers.co.uk/Info?id=Wolverhampton", Frequency = SitemapFrequency.Never });
            list.Add(new SitemapNode { LastModified = DateTime.UtcNow, Priority = 0.6, Url = "https://www.crestcouriers.co.uk/Career?id=Wolverhampton", Frequency = SitemapFrequency.Never });

            list.Add(new SitemapNode { LastModified = DateTime.UtcNow, Priority = 0.5, Url = "https://www.crestcouriers.co.uk/Info?id=Tamworth", Frequency = SitemapFrequency.Never });
            list.Add(new SitemapNode { LastModified = DateTime.UtcNow, Priority = 0.6, Url = "https://www.crestcouriers.co.uk/Career?id=Tamworth", Frequency = SitemapFrequency.Never });

            list.Add(new SitemapNode { LastModified = DateTime.UtcNow, Priority = 0.7, Url = "https://www.crestcouriers.co.uk/sitemap.xml", Frequency = SitemapFrequency.Monthly });

            new SitemapDocument().CreateSitemapXML(list, _environment.ContentRootPath);


            return View();
        }

        [Route("About")]
        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";
            return View();
        }

        [Route("Career delivery")]
        public IActionResult Career_delivery()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        [Route("Contact")]
        public IActionResult Contact()
        {

            ViewData["content"] = "No";
            ViewData["Title"] = "contact";
            return View();

        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("Contact")]
        public async Task<IActionResult> Contact(Contact Contact, EmailRequest emailRequest)
        {

            ViewData["Title"] = "contact";
            

            //Recaptcha code begins here


            var recaptcha = await _recaptcha.Validate(Request);
            if (!recaptcha.success)
            { 
                ModelState.AddModelError("Recaptcha", "There was an error validating recatpcha. Please try again!");
            }


            //Recaptcha code ends here


            //string myurl = $"{this.Request.Scheme}://{this.Request.Host}{this.Request.PathBase}";
            //Dal connection = new Dal(myurl);

            //SqlCommand cmd = new SqlCommand("sp_Crest_contact", connection.connect())
            //{
            //    CommandType = CommandType.StoredProcedure
            //};
            //cmd.Parameters.AddWithValue("@FullName", Contact.FullName);
            //cmd.Parameters.AddWithValue("@EmailAddress", Contact.EmailAddress);
            //cmd.Parameters.AddWithValue("@PhoneNumber", Contact.PhoneNumber);
            //cmd.Parameters.AddWithValue("@Subject", Contact.Subject);
            //cmd.Parameters.AddWithValue("@Message", Contact.Message);


            //cmd.ExecuteNonQuery();


            //connection.disconnect();



            //EF core code

            CrestContext context = new CrestContext();

            context.Contact.Add(Contact);

            context.SaveChanges();

            //EF core code ends




            ///////    Send Email     ///////
            MimeMessage message = new MimeMessage();

            MailboxAddress from = new MailboxAddress("Crest Couriers", "contact@crestcouriers.co.uk");
            message.From.Add(from);

            MailboxAddress to = new MailboxAddress("Crest Couriers", "contact@crestcouriers.co.uk");
            message.To.Add(to);

            message.Subject = " Contact";

            BodyBuilder bodyBuilder = new BodyBuilder();
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

            MailboxAddress from2 = new MailboxAddress("Crest Couriers", "contact@crestcouriers.co.uk");
            message2.From.Add(from2);

            MailboxAddress to2 = new MailboxAddress(Contact.FullName + " " + Contact.Subject, Contact.EmailAddress);
            message2.To.Add(to2);

            message2.Subject = "Message received";


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





            ViewData["content"] = "confirmbox";

            //return View(!ModelState.IsValid ? Contact : new Contact());
            return View();

        }

        [Route("Privacy")]
        public IActionResult Privacy()
        {
            return View();
        }

        [Route("Services")]
        public IActionResult Services()
        {

            return View();

        }

        [Route("Branches")]
        public IActionResult Branches()
        {
            return View();
        }

        public IActionResult Branchinfo()
        {
            return View();
        }

        [Route("Info")]
        public IActionResult Careerinfo(string id)
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
                    ViewData["Citymap"] = "https://www.google.com/maps/embed?pb=!1m18!1m12!1m3!1d76145.62257369689!2d-2.6435830798807842!3d53.3870880561791!2m3!1f0!2f0!3f0!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0x487b01835b28c2a7%3A0x88e8e7e8adef7e45!2sWarrington!5e0!3m2!1sen!2suk!4v1597744842846!5m2!1sen!2suk";
                    ViewData["Salary"] = "£10.00 Per Hours";
                }
                else if (id == "Wolverhampton")
                {
                    ViewData["Citymap"] = "https://www.google.com/maps/embed?pb=!1m18!1m12!1m3!1d19389.484137642463!2d-2.1508388128017075!3d52.59337880544072!2m3!1f0!2f0!3f0!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0x487080d43225d7fd%3A0x526da09547380126!2sWolverhampton%2C%20UK!5e0!3m2!1sen!2s!4v1605561217575!5m2!1sen!2s";
                    ViewData["Salary"] = "£10.00 Per Hours";
                }
                else if (id == "Tamworth")
                {
                    ViewData["Citymap"] = "https://www.google.com/maps/embed?pb=!1m18!1m12!1m3!1d77496.58899479962!2d-1.7570417482743317!3d52.62802914988089!2m3!1f0!2f0!3f0!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0x4870a8931830eb41%3A0xf7e67fb3d4c81cef!2sTamworth%2C%20UK!5e0!3m2!1sen!2s!4v1605534535724!5m2!1sen!2s";
                    ViewData["Salary"] = "£10.00 Per Hours";
                }
                else if (id == "Coventry")
                {
                    ViewData["Citymap"] = "https://www.google.com/maps/embed?pb=!1m18!1m12!1m3!1d155751.51796075056!2d-1.6550003316224775!3d52.41360877929703!2m3!1f0!2f0!3f0!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0x4870b151656e22b7%3A0x4f660f5564f0689!2sCoventry%2C%20UK!5e0!3m2!1sen!2s!4v1605534602377!5m2!1sen!2s";
                    ViewData["Salary"] = "£10.00 Per Hours";
                }
                return View();

            }
        }

        [Route("Type")]
        public IActionResult Careertype()
        {

            return View();

        }

        [HttpGet]
        [Route("Career")]
        public IActionResult Career(string id)
        {
            ViewData["message"] = "No";

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
        [Route("Career")]
        public async Task<IActionResult> Career(RegCareer career, IFormFile UploadCV , EmailRequest emailRequest, string id)
        {

            

            //Recaptcha code begins here

            
            var recaptcha = await _recaptcha.Validate(Request);
            if (!recaptcha.success)
                ModelState.AddModelError("Recaptcha", "There was an error validating recatpcha. Please try again!");


            //Recaptcha code ends here

            string myurl = $"{this.Request.Scheme}://{this.Request.Host}{this.Request.PathBase}";



            //Dal con = new Dal();

            CrestContext context = new CrestContext();
            career.UploadCV = UploadCV.FileName;
            context.RegCareer.Add(career);

            //SqlCommand cmd = new SqlCommand("sp_Crest_career", connection.connect())
            //{
            //    CommandType = CommandType.StoredProcedure
            //};
            //cmd.Parameters.AddWithValue("@FirstName", career.FirstName);
            //cmd.Parameters.AddWithValue("@LastName", career.LastName);
            //cmd.Parameters.AddWithValue("@Gender", career.Gender);
            //cmd.Parameters.AddWithValue("@Age", career.Age);
            //cmd.Parameters.AddWithValue("@Married", career.Married);
            //cmd.Parameters.AddWithValue("@HouseNumber", career.HouseNumber);
            //cmd.Parameters.AddWithValue("@RoadName", career.RoadName);
            //cmd.Parameters.AddWithValue("@City", career.City);
            //cmd.Parameters.AddWithValue("@PostCode", career.PostCode);
            //cmd.Parameters.AddWithValue("@DriverLicence", career.DriverLicence);
            //cmd.Parameters.AddWithValue("@Accident", career.Accident);
            //cmd.Parameters.AddWithValue("@DBS", career.DBS);
            //cmd.Parameters.AddWithValue("@PhoneNumber", career.PhoneNumber);
            //cmd.Parameters.AddWithValue("@Email", career.Email);
            //cmd.Parameters.AddWithValue("@UploadCV", UploadCV.FileName);

            //cmd.ExecuteNonQuery();
            //connection.disconnect();

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

            MailboxAddress from = new MailboxAddress("Crest Couriers", "careers@crestcouriers.com");
            message.From.Add(from);

            MailboxAddress to = new MailboxAddress("Crest Couriers", "careers@crestcouriers.com");
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

            MailboxAddress from2 = new MailboxAddress("Crest Couriers", "careers@crestcouriers.com");
            message2.From.Add(from2);

            MailboxAddress to2 = new MailboxAddress(career.FirstName + " " + career.LastName, career.Email);
            message2.To.Add(to2);

            message2.Subject = "Application received";


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


            ViewData["City"] = id;

            ViewData["message"] = "confirmbox";
            //return View(!ModelState.IsValid ? career : new RegCareer());
            return View();

        }

        [HttpGet]
        [Route("Blog")]
        public IActionResult Blog()
        {
            //CrestContext context = new CrestContext();
            //IEnumerable<Article> articles = context.Article.ToList();

            return View();
        }

        [HttpGet]
        [Route("Details")]
        public IActionResult Details(/*int ArticleId*/ string ArticleId)
        {

            //CrestContext context = new CrestContext();
            //var article = context.Article.Include(A => A.Comments).Include(A => A.Images).Where(B => B.ArticleId == ArticleId).SingleOrDefault();

            ViewData["ArticleId"] = ArticleId.ToString();
            return View((object)ArticleId);

        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

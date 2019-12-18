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
            ViewData["Message"] = "Your application description page.";
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            MimeMessage message = new MimeMessage();

            MailboxAddress from = new MailboxAddress("amir", "j666.amir@gmail.com");
            message.From.Add(from);

            MailboxAddress to = new MailboxAddress("mjn", "mjn220@gmail.com");
            message.To.Add(to);

            message.Subject = "Register for career";

            BodyBuilder bodyBuilder = new BodyBuilder();
            bodyBuilder.HtmlBody = "<h1>Hello World!</h1>";
            //bodyBuilder.TextBody = "Hello World!";


            message.Body = bodyBuilder.ToMessageBody();


            SmtpClient client = new SmtpClient();
            client.Connect("smtp.gmail.com", 465, true);
            client.Authenticate("j666.amir@gmail.com", "09379977212Am");


            client.Send(message);
            client.Disconnect(true);
            client.Dispose();

            return View();
        }

        public IActionResult Privacy()
        {


            return View();
        }

        public IActionResult Career()
        {

            return View();

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Career(RegCareer career, IFormFile UploadCV)
        {
            //Recaptcha code begins here
            var recaptcha = await _recaptcha.Validate(Request);
            if (!recaptcha.success)
                ModelState.AddModelError("Recaptcha", "There was an error validating recatpcha. Please try again!");
            //Recaptcha code ends here



            //connectionDB connection1 = new connectionDB();
            //SqlConnection con = new SqlConnection(connection1.connect());
            //SqlCommand cmd = new SqlCommand("sp_Crest_Add", con);
            //con.Open(); 

            Dal con = new Dal();
            SqlCommand cmd = new SqlCommand("sp_Crest_Add", con.connect());
            cmd.CommandType = CommandType.StoredProcedure;
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
            con.disconnect();
            ////    Send Email     ///////
            MimeMessage message = new MimeMessage();

            MailboxAddress from = new MailboxAddress("amir", "j666.amir@gmail.com");
            message.From.Add(from);

            MailboxAddress to = new MailboxAddress("mjn","mjn220@gmail.com");
            message.To.Add(to);

            message.Subject = "Register for career";

            BodyBuilder bodyBuilder = new BodyBuilder();
            bodyBuilder.HtmlBody = $"<h2>FirstName</h2><br/><h3>{ career.FirstName}</h3><br/>" +$"<h2>LastName</h2><br/><h3>{ career.LastName}</h3><br/>" + $"<h2>Gender</h2><br/><h3>{ career.Gender}</h3><br/>"
                + $"<h2>Age</h2><br/><h3>{ career.Age}</h3><br/>" + $"<h2>Married</h2><br/><h3>{ career.Married}</h3><br/>" + $"<h2>HouseNumber</h2><br/><h3>{ career.HouseNumber}</h3><br/>"
                + $"<h2>RoadName</h2><br/><h1>{ career.RoadName}</h1><br/>" + $"<h2>City</h2><br/><h1>{career.City}</h1><br/>" + $"<h2>PostCode</h2><br/><h3>{ career.PostCode}</h3><br/>"
                + $"<h2>DriverLicence</h2><br/><h3>{ career.DriverLicence}</h3><br/>" + $"<h2>Accident</h2><br/><h3>{ career.Accident}</h3><br/>" + $"<h3>DBS</h3><br/><h1>{ career.DBS}</h1><br/>"
                + $"<h2>PhoneNumber</h2><br/><h3>{ career.PhoneNumber}</h3><br/>" + $"<h2>Email</h2><br/><h3>{ career.Email}</h3><br/>" + $"<h3>UploadCV</h3><br/><h1>{ UploadCV.FileName}</h1><br/>";

            //bodyBuilder.TextBody = "Hello World!";


            message.Body = bodyBuilder.ToMessageBody();


            SmtpClient client = new SmtpClient();
            client.Connect("smtp.gmail.com", 465, true);
            client.Authenticate("j666.amir@gmail.com", "09379977212Am");


            client.Send(message);
            client.Disconnect(true);
            client.Dispose();
            //Response.WriteAsync("your Email  Has been send");
            //Response.Redirect(https://localhost:44325/Home/Career);
            ///////   End Send Email    //////////



            var uploadsRootFolder = Path.Combine(_environment.WebRootPath, "uploads");
            if (!Directory.Exists(uploadsRootFolder))
            {
                Directory.CreateDirectory(uploadsRootFolder);
            }


                if (UploadCV == null || UploadCV.Length == 0)
                {
                    Response.WriteAsync("Error");
                }

                var filePath = Path.Combine(uploadsRootFolder, UploadCV.FileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    await UploadCV.CopyToAsync(fileStream).ConfigureAwait(false);
                }


            return View(!ModelState.IsValid ? career : new RegCareer());




        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

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

        public IActionResult Career_delivery()
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
        public async Task<IActionResult> Career(RegCareer career, IFormFile UploadCV , EmailRequest emailRequest)
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
            bodyBuilder.HtmlBody = $"<div class='container'>" +
  $"< table class='table table-bordered'>" +
    $"<thead>" +
      $"<tr>" +
        $"<td>Firstname :</td>" +
        $"<td>{career.FirstName}</td>" +
      $"</tr>" +
    $"</thead>" +
    $"<tbody>" +
      $"<tr>" +
        $"<td>Lastname :</td>" +
        $"<td>{career.LastName}</td>" +
      $"</tr>" +
      $"<tr>" +
        $"<td>Gender :</td>" +
        $"<td>{career.Gender}</td>" +
      $"</tr>" +
      $"<tr>" +
        $"<td>Age :</td>" +
        $"<td>{career.Age}</td>" +
      $"</tr>" +
      $"<tr>" +
        $"<td>Married :</td>" +
        $"<td>{career.Married}</td>" +
      $"</tr>" +
      $"<tr>" +
        $"<td>HouseNumber :</td>" +
        $"<td>{career.HouseNumber}</td>" +
      $"</tr>" +
      $"<tr>" +
        $"<td>RoadName :</td>" +
        $"<td>{career.RoadName}</td>" +
      $"</tr>" +
      $"<tr>" +
        $"<td>City :</td>" +
        $"<td>{career.City}</td>" +
      $"</tr>" +
      $"<tr>" +
        $"<td>PostCode :</td>" +
        $"<td>{career.PostCode}</td>" +
      $"</tr>" +
      $"<tr>" +
        $"<td>DriverLicence :</td>" +
        $"<td>{career.DriverLicence}</td>" +
      $"</tr>" +
      $"<tr>" +
        $"<td>Accident :</td>" +
        $"<td>{career.Accident}</td>" +
      $"</tr>" +
      $"<tr>" +
        $"<td>DBS :</td>" +
        $"<td>{career.DBS}</td>" +
      $"</tr>" +
      $"<tr>" +
        $"<td>PhoneNumber :</td>" +
        $"<td>{career.PhoneNumber}</td>" +
      $"</tr>" +
      $"<tr>" +
        $"<td>Email :</td>" +
        $"<td>{career.Email}</td>" +
      $"</tr>" +
      $"<tr>" +
        $"<td>UploadCV :</td>" +
        $"<td>{career.UploadCV}</td>" +
      $"</tr>" +
    $"</tbody>" +
  $"</table>" +
$"</div>";

            //bodyBuilder.TextBody = "Hello World!";


            //Attachment started

            //ended


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


                 Response.Redirect("Career_delivery");

        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

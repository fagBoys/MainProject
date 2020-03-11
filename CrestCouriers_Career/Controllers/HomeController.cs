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
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Index(RegCareer career, IFormFile UploadCV, EmailRequest emailRequest)
        {



            //Recaptcha code begins here


            var recaptcha = await _recaptcha.Validate(Request);
            if (!recaptcha.success)
                ModelState.AddModelError("Recaptcha", "There was an error validating recatpcha. Please try again!");


            //Recaptcha code ends here



            //string CS = @"Server=127.0.0.1;Database=fagboys;User Id=fagboys;Password=y@SDJENjVnt;Integrated Security=False;";
            string CS = @"Data Source=DESKTOP-N7V04NE;Initial Catalog=Crest;Integrated Security=True;";
            SqlConnection con = new SqlConnection(CS);

            con.Open();


            //Dal con = new Dal();
            SqlCommand cmd = new SqlCommand("sp_Crest_Add", con);
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
            con.Close();





            ////    Send Email     ///////
            MimeMessage message = new MimeMessage();

            MailboxAddress from = new MailboxAddress("amir", "mjn220@gmail.com");
            message.From.Add(from);

            MailboxAddress to = new MailboxAddress("mjn", "j666.amir@gmail.com");
            message.To.Add(to);

            message.Subject = "Register for career";

            BodyBuilder bodyBuilder = new BodyBuilder();
            bodyBuilder.HtmlBody = "Hellooooooooo";
            
            //$"<div class='container'>" +
//  $"<table class='table table-bordered'>" +
//    $"<thead>" +
//      $"<tr>" +
//        $"<td>Firstname :</td>" +
//        $"<td>{career.FirstName}</td>" +

//      $"</tr>" +
//    $"</thead>" +
//    $"<tbody>" +
//      $"<tr>" +
//        $"<td>Lastname :</td>" +
//        $"<td>{career.LastName}</td>" +
//      $"</tr>" +
//      $"<tr>" +
//        $"<td>Gender :</td>" +
//        $"<td>{career.Gender}</td>" +
//      $"</tr>" +
//      $"<tr>" +
//        $"<td>Age :</td>" +
//        $"<td>{career.Age}</td>" +
//      $"</tr>" +
//      $"<tr>" +
//        $"<td>Married :</td>" +
//        $"<td>{career.Married}</td>" +
//      $"</tr>" +
//      $"<tr>" +
//        $"<td>HouseNumber :</td>" +
//        $"<td>{career.HouseNumber}</td>" +
//      $"</tr>" +
//      $"<tr>" +
//        $"<td>RoadName :</td>" +
//        $"<td>{career.RoadName}</td>" +
//      $"</tr>" +
//      $"<tr>" +
//        $"<td>City :</td>" +
//        $"<td>{career.City}</td>" +
//      $"</tr>" +
//      $"<tr>" +
//        $"<td>PostCode :</td>" +
//        $"<td>{career.PostCode}</td>" +
//      $"</tr>" +
//      $"<tr>" +
//        $"<td>DriverLicence :</td>" +
//        $"<td>{career.DriverLicence}</td>" +
//      $"</tr>" +
//      $"<tr>" +
//        $"<td>Accident :</td>" +
//        $"<td>{career.Accident}</td>" +
//      $"</tr>" +
//      $"<tr>" +
//        $"<td>DBS :</td>" +
//        $"<td>{career.DBS}</td>" +
//      $"</tr>" +
//      $"<tr>" +
//        $"<td>PhoneNumber :</td>" +
//        $"<td>{career.PhoneNumber}</td>" +
//      $"</tr>" +
//      $"<tr>" +
//        $"<td>Email :</td>" +
//        $"<td>{career.Email}</td>" +
//      $"</tr>" +
//      $"<tr>" +
//        $"<td>UploadCV :</td>" +
//        $"<td>Myfile</td>" +
//      $"</tr>" +
//    $"</tbody>" +
//  $"</table>" +
//$"</div>";



            //bodyBuilder.TextBody = "Hello World!";


            //Attachment started


            /////////   UploadFile start    //////////
            ///


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






            /////////   UploadFile end    //////////

            var body = new BodyBuilder();

            body.TextBody = @"HEY";

            body.Attachments.Add(@"C:\Users\mjn110\Downloads\27-Bahman.pdf");
            //using (var fs = new FileStream(filePath, FileMode.Create))
            //{
            //    await UploadCV.CopyToAsync(fs).ConfigureAwait(false);
            //    //var filebyte = fs.
            //    //string s = Convert.ToBase64String(filebyte);
            //    body.Attachments.Add(@"C:\Users\mjn110\Documents\GitHub\MainProject\CrestCouriers_Career\wwwroot\img\404.png");

            //}


            // create an image attachment for the file located at path
            //var attachment = new MimePart("image", "jpg")
            //{
            //    Content = new MimeContent(File.OpenRead(@"C:\Users\mjn110\Documents\GitHub\MainProject\CrestCouriers_Career\wwwroot\img\404.png")),
            //    ContentDisposition = new ContentDisposition(ContentDisposition.Attachment),
            //    ContentTransferEncoding = ContentEncoding.Base64,
            //    FileName = Path.GetFileName(@"C:\Users\mjn110\Documents\GitHub\MainProject\CrestCouriers_Career\wwwroot\img\404.png")
            //};


            //Attachment ended

            message.Body = body.ToMessageBody();


            SmtpClient client = new SmtpClient();
            client.Connect("smtp.gmail.com", 465, true);
            client.Authenticate("mjn220@gmail.com", "mjngoogleid220");

            client.Send(message);
            client.Disconnect(true);
            client.Dispose();

            ///////   End Send Email    //////////





            //return View(!ModelState.IsValid ? career : new RegCareer());
            return new RedirectResult("/Home/Career_delivery");
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



            //string CS = @"Server=127.0.0.1;Database=fagboys;User Id=fagboys;Password=y@SDJENjVnt;Integrated Security=False;";
            string CS = @"Data Source=DESKTOP-9V538JM;Initial Catalog=Crest;Integrated Security=True;";
            SqlConnection con = new SqlConnection(CS);

            con.Open(); 


            //Dal con = new Dal();
            SqlCommand cmd = new SqlCommand("sp_Crest_Add", con);
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
            con.Close();

            



            ////    Send Email     ///////
            MimeMessage message = new MimeMessage();

            MailboxAddress from = new MailboxAddress("amir", "mjn220@gmail.com");
            message.From.Add(from);

            MailboxAddress to = new MailboxAddress("mjn", "mjn220@gmail.com");
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
        $"<td>Myfile</td>" +
      $"</tr>" +
    $"</tbody>" +
  $"</table>" +
$"</div>";



            //bodyBuilder.TextBody = "Hello World!";



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

            var fileStream = new FileStream(filePath, FileMode.Create);
            await UploadCV.CopyToAsync(fileStream).ConfigureAwait(false);



            //Attachment started



            MemoryStream ms = new MemoryStream();
            await UploadCV.CopyToAsync(ms).ConfigureAwait(false);

            bodyBuilder.Attachments.Add(UploadCV.FileName,ms.ToArray()); //ToArray method = memorystream to byte



            //bodyBuilder.Attachments.Add(@"C:\Users\mjn110\Downloads\27-Bahman.pdf");
            //Attachment ended


            message.Body = bodyBuilder.ToMessageBody();


            SmtpClient client = new SmtpClient();
            client.Connect("smtp.gmail.com",465,true);
            client.Authenticate("mjn220@gmail.com", "mjngoogleid220");


            client.Send(message);
            client.Disconnect(true);
            client.Dispose();
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

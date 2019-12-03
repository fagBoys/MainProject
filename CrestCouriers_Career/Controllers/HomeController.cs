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

namespace CrestCouriers_Career.Controllers
{
    public class HomeController : Controller
    {

        private IHostingEnvironment _environment;
        public HomeController(IHostingEnvironment environment)
        {
            _environment = environment;
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
            

            return View();




        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

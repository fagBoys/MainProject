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
    public class AdminController : Controller
    {
        private IHostingEnvironment _environment;

        private IRecaptchaService _recaptcha;
        public AdminController(IHostingEnvironment environment, IRecaptchaService recaptcha)
        {
            _environment = environment;

            _recaptcha = recaptcha;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IEnumerable<Order> OrderList(DataTable datatable)
        {

            foreach(DataRow item in datatable.Rows)
            {

                yield return new Order
                {
                    Orderid = System.Convert.ToInt32(item["Orderid"].ToString()),
                    OrderDate = item["OrderDate"].ToString(),
                    Origin = item["Origin"].ToString(),
                    Destination = item["Destination"].ToString(),
                    ReceiveDate = item["ReceiveDate"].ToString(),
                    DeliveryDate = item["DeliveryDate"].ToString(),
                    CarType = item["CarType"].ToString(),
                    UserId = item["UserId"].ToString(),
                    Price = item["Price"].ToString(),
                    State = item["State"].ToString(),
                };

            }
        }

        public IActionResult Dashboard()
        {
            if (HttpContext.Session.GetString("AdminSession") == null)
            {
                return new RedirectResult("/Admin/AdminLogin");
            }
            {
                ViewData["Username"] = HttpContext.Session.GetString("AdminSession");
            }
            string myurl = $"{this.Request.Scheme}://{this.Request.Host}{this.Request.PathBase}";
            Dal connection = new Dal(myurl);
            SqlDataAdapter da = new SqlDataAdapter();
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand("sp_Crest_OrderList", connection.connect());
            cmd.CommandType = CommandType.StoredProcedure;
            da.SelectCommand = cmd;
            da.Fill(dt);
            return View(OrderList(dt));
        }

        public ActionResult Delete(int id)
        {
            string myurl = $"{this.Request.Scheme}://{this.Request.Host}{this.Request.PathBase}";
            Dal connection = new Dal(myurl);
            SqlCommand cmd = new SqlCommand("sp_Crest_DeleteOrder", connection.connect())
            {
                CommandType = CommandType.StoredProcedure
            };
            SqlParameter parametrid = new SqlParameter();
            parametrid.ParameterName = "@Orderid";
            parametrid.Value = id;
            cmd.Parameters.Add(parametrid);
            cmd.ExecuteNonQuery();


            return RedirectToAction("dashboard");
        }

        public IActionResult Edit(int id)
        {
            if (HttpContext.Session.GetString("AdminSession") == null)
            {
                return new RedirectResult("/Admin/AdminLogin");
            }
            {
                ViewData["Username"] = HttpContext.Session.GetString("AdminSession");
            }

            string myurl = $"{this.Request.Scheme}://{this.Request.Host}{this.Request.PathBase}";
            Dal connection = new Dal(myurl);
            SqlDataAdapter da = new SqlDataAdapter();
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand("sp_Crest_MyOrder", connection.connect());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Orderid", id);
            da.SelectCommand = cmd;
            da.Fill(dt);

            ViewData["Orderid"] = dt.Rows[0][0];
            ViewData["Origin"] = dt.Rows[0][2];
            ViewData["Destination"] = dt.Rows[0][3];
            ViewData["ReceiveDate"] = dt.Rows[0][4];
            ViewData["DeliveryDate"] = dt.Rows[0][5];
            ViewData["CarType"] = dt.Rows[0][6];


            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult EditOrder(Order order)
        {
            if (HttpContext.Session.GetString("AdminSession") == null)
            {
                return new RedirectResult("/Admin/AdminLogin");
            }
            {
                ViewData["Username"] = HttpContext.Session.GetString("AdminSession");
            }
            string myurl = $"{this.Request.Scheme}://{this.Request.Host}{this.Request.PathBase}";
            Dal connection = new Dal(myurl);
            SqlDataAdapter da = new SqlDataAdapter();
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand("sp_Crest_UpdateOrder", connection.connect());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Orderid", order.Orderid);
            cmd.Parameters.AddWithValue("@Origin", order.Origin);
            cmd.Parameters.AddWithValue("@Destination", order.Destination);
            cmd.Parameters.AddWithValue("@ReceiveDate", order.ReceiveDate);
            cmd.Parameters.AddWithValue("@DeliveryDate", order.DeliveryDate);
            cmd.Parameters.AddWithValue("@CarType", order.CarType);

            cmd.ExecuteNonQuery();
            return new RedirectResult("/Admin/dashboard");
        }



        public IActionResult Order()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Order(Order order)
        {
            ViewData["Title"] = "Order";
            if (HttpContext.Session.GetString("AdminSession") == null)
            {
                return new RedirectResult("/Admin/AdminLogin");
            }
            {
                ViewData["Username"] = HttpContext.Session.GetString("AdminSession");
            }
            //Recaptcha code begins here


            //var recaptcha = await _recaptcha.Validate(Request);
            //if (!recaptcha.success)
            //    ModelState.AddModelError("Recaptcha", "There was an error validating recatpcha. Please try again!");


            //Recaptcha code ends here


            string myurl = $"{this.Request.Scheme}://{this.Request.Host}{this.Request.PathBase}";
            Dal connection = new Dal(myurl);

            SqlCommand cmd = new SqlCommand("sp_Crest_NewOrder", connection.connect())
            {
                CommandType = CommandType.StoredProcedure
            };
            cmd.Parameters.AddWithValue("@OrderDate", DateTime.Now);
            cmd.Parameters.AddWithValue("@Origin", order.Origin);
            cmd.Parameters.AddWithValue("@Destination", order.Destination);
            cmd.Parameters.AddWithValue("@ReceiveDate", order.ReceiveDate);
            cmd.Parameters.AddWithValue("@DeliveryDate", order.DeliveryDate);
            cmd.Parameters.AddWithValue("@CarType", order.CarType);
            cmd.Parameters.AddWithValue("@Userid", 1);
            cmd.Parameters.AddWithValue("@Price", "1");
            cmd.Parameters.AddWithValue("@State", "1");



            cmd.ExecuteNonQuery();

            connection.disconnect();

            
            return View(!ModelState.IsValid ? order : new Order());
            
        }

        public IActionResult AdminSetting()
        {
            if (HttpContext.Session.GetString("AdminSession") == null)
            {
                return new RedirectResult("/Admin/AdminLogin");
            }
            else
            {
                ViewData["Username"] = HttpContext.Session.GetString("AdminSession");
            }

            string myurl = $"{this.Request.Scheme}://{this.Request.Host}{this.Request.PathBase}";
            Dal connection = new Dal(myurl);
            SqlDataAdapter da = new SqlDataAdapter();
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand("sp_Crest_MyAdmin", connection.connect());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@UserName", ViewData["Username"]);
            da.SelectCommand = cmd;
            da.Fill(dt);

            ViewData["myAdmin-UserName"] = dt.Rows[0][1];
            ViewData["myAdmin-Password"] = dt.Rows[0][2];
            ViewData["myAdmin-FirstName"] = dt.Rows[0][3];
            ViewData["myAdmin-Lastname"] = dt.Rows[0][4];
            ViewData["myAdmin-PhoneNumber"] = dt.Rows[0][5];
            ViewData["myAdmin-EmailAddress"] = dt.Rows[0][6];

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AdminSetting(Admin admin)
        {
            if (HttpContext.Session.GetString("AdminSession") == null)
            {
                return new RedirectResult("/Admin/AdminLogin");
            }
            {
                ViewData["Username"] = HttpContext.Session.GetString("AdminSession");
            }
            string myurl = $"{this.Request.Scheme}://{this.Request.Host}{this.Request.PathBase}";
            Dal connection = new Dal(myurl);
            SqlDataAdapter da = new SqlDataAdapter();
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand("sp_Crest_UpdateAdmin", connection.connect());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@UserName", admin.UserName);
            cmd.Parameters.AddWithValue("@Password", admin.Password);
            cmd.Parameters.AddWithValue("@FirstName", admin.FirstName);
            cmd.Parameters.AddWithValue("@LastName", admin.Lastname);
            cmd.Parameters.AddWithValue("@PhoneNumber", admin.PhoneNumber);
            cmd.Parameters.AddWithValue("@Email", admin.EmailAddress);
 
            

            cmd.ExecuteNonQuery();
            return View();
        }

        public IEnumerable<Admin> MyAdmin(DataTable dataTable)
        {

            foreach (DataRow item in dataTable.Rows)
            {
                yield return new Admin
                {
                    Adminid = Convert.ToInt32(item["Adminid"].ToString()),
                    UserName = item["UserName"].ToString(),
                    FirstName = item["FirstName"].ToString(),
                    Lastname = item["Lastname"].ToString(),
                    Level = item["Level"].ToString(),
                };

            }
        }

        public IActionResult AdminAccounts(DataTable dataTable)
        {
            if (HttpContext.Session.GetString("AdminSession") == null)
            {
                return new RedirectResult("/Admin/AdminLogin");
            }
            {
                ViewData["Username"] = HttpContext.Session.GetString("AdminSession");
            }
            string myurl = $"{this.Request.Scheme}://{this.Request.Host}{this.Request.PathBase}";
            Dal connection = new Dal(myurl);
            SqlDataAdapter da = new SqlDataAdapter();
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand("sp_Crest_AdminList", connection.connect());
            cmd.CommandType = CommandType.StoredProcedure;
            da.SelectCommand = cmd;
            da.Fill(dt);

            return View(MyAdmin(dt));
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AdminAccounts(Admin register, EmailRequest emailRequest)
        {

            ViewData["Title"] = "AdminAccounts";
            if (HttpContext.Session.GetString("AdminSession") == null)
            {
                return new RedirectResult("/Admin/AdminLogin");
            }
            {
                ViewData["Username"] = HttpContext.Session.GetString("AdminSession");
            }
            //Recaptcha code begins here


            var recaptcha = await _recaptcha.Validate(Request);
            if (!recaptcha.success)
                ModelState.AddModelError("Recaptcha", "There was an error validating recatpcha. Please try again!");


            //Recaptcha code ends here


            string myurl = $"{this.Request.Scheme}://{this.Request.Host}{this.Request.PathBase}";
            Dal connection = new Dal(myurl);

            SqlCommand cmd = new SqlCommand("sp_Crest_RegisterAdmin", connection.connect())
            {
                CommandType = CommandType.StoredProcedure
            };
            cmd.Parameters.AddWithValue("@UserName", register.UserName);
            cmd.Parameters.AddWithValue("@Password", register.Password);
            cmd.Parameters.AddWithValue("@FirstName", register.FirstName);
            cmd.Parameters.AddWithValue("@Lastname", register.Lastname);
            cmd.Parameters.AddWithValue("@Level", 0);
            cmd.Parameters.AddWithValue("@PhoneNumber", 0);
            cmd.Parameters.AddWithValue("@EmailAddress", 0);



            cmd.ExecuteNonQuery();

            connection.disconnect();


            /////////    Send Email     ///////
            //MimeMessage message = new MimeMessage();

            //MailboxAddress from = new MailboxAddress("CrestCouriers", "test@crestcouriers.com");
            //message.From.Add(from);

            //MailboxAddress to = new MailboxAddress("CrestCouriers", "test@crestcouriers.com");
            //message.To.Add(to);

            //message.Subject = " Adminregister";

            //BodyBuilder bodyBuilder = new BodyBuilder();
            //var usericfile = System.IO.File.OpenRead(_environment.WebRootPath + @"\Email\newuser.png");
            //MemoryStream newms = new MemoryStream();
            //await usericfile.CopyToAsync(newms);


            //var mybody = @System.IO.File.ReadAllText(_environment.WebRootPath + @"\Email\emailbody-contact.html");

            //mybody = mybody.Replace("Value00", register.UserName);
            //mybody = mybody.Replace("Value01", register.Password);
            //mybody = mybody.Replace("Value02", register.FirstName);
            //mybody = mybody.Replace("Value03", register.Lastname);
            //mybody = mybody.Replace("Value04", register.PhoneNumber);
            //mybody = mybody.Replace("Value05", register.EmailAddress);


            //bodyBuilder.HtmlBody = mybody;

            //var usericon = bodyBuilder.LinkedResources.Add(_environment.WebRootPath + @"/Email/newuser.png");
            //usericon.ContentId = MimeUtils.GenerateMessageId();

            //bodyBuilder.HtmlBody = bodyBuilder.HtmlBody.Replace("{", "{{");
            //bodyBuilder.HtmlBody = bodyBuilder.HtmlBody.Replace("}", "}}");
            //bodyBuilder.HtmlBody = bodyBuilder.HtmlBody.Replace("{{0}}", "{0}");

            //bodyBuilder.HtmlBody = string.Format(bodyBuilder.HtmlBody, usericon.ContentId);

            //message.Body = bodyBuilder.ToMessageBody();


            //SmtpClient client = new SmtpClient();
            //client.Connect("smtp.gmail.com", 465, true);
            //client.Authenticate("crestcouriers@gmail.com", "CRESTcouriers123");


            //client.Send(message);
            ////First email


            //MimeMessage message2 = new MimeMessage();

            //MailboxAddress from2 = new MailboxAddress("CrestCouriers", "test@crestcouriers.com");
            //message2.From.Add(from2);

            //MailboxAddress to2 = new MailboxAddress(register.FirstName + " " + register.Lastname, register.EmailAddress);
            //message2.To.Add(to2);

            //message2.Subject = "Adminregister";


            //BodyBuilder bobu = new BodyBuilder
            //{
            //    HtmlBody = @System.IO.File.ReadAllText(_environment.WebRootPath + @"\Email\emailreply-contact.html")
            //};




            //// var logo = System.IO.File.OpenRead(_environment.WebRootPath + @"/img/logo.png");
            //MemoryStream myms = new MemoryStream();
            //await usericfile.CopyToAsync(myms);

            //var embedlogo = bobu.LinkedResources.Add(_environment.WebRootPath + @"/img/logo.png");
            //embedlogo.ContentId = MimeUtils.GenerateMessageId();

            //bobu.HtmlBody = bobu.HtmlBody.Replace("{", "{{");
            //bobu.HtmlBody = bobu.HtmlBody.Replace("}", "}}");
            //bobu.HtmlBody = bobu.HtmlBody.Replace("{{0}}", "{0}");

            //bobu.HtmlBody = string.Format(bobu.HtmlBody, embedlogo.ContentId);


            //message2.Body = bobu.ToMessageBody();

            //SmtpClient client2 = new SmtpClient();
            //client2.Connect("smtp.gmail.com", 465, true);
            //client2.Authenticate("crestcouriers@gmail.com", "CRESTcouriers123");


            //client2.Send(message2);
            //client2.Disconnect(true);
            //client2.Dispose();
            /////////   End Send Email    //////////






            return View(!ModelState.IsValid ? register : new Admin());
            return new RedirectResult("/Home/Career_delivery");

        }

        public IActionResult UserAccounts()
        {
            return View();
        }
        public IActionResult AdminLogin()
        {

            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AdminLogin(Admin admin)
        {
            string myurl = $"{this.Request.Scheme}://{this.Request.Host}{this.Request.PathBase}";
            Dal connection = new Dal(myurl);
            SqlDataAdapter da = new SqlDataAdapter();
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand("sp_Crest_AdminLogin", connection.connect());
            cmd.Parameters.AddWithValue("@UserName", admin.UserName);
            cmd.CommandType = CommandType.StoredProcedure;
            da.SelectCommand = cmd;
            da.Fill(dt);
            if (dt.Rows[0][0].ToString() == admin.UserName && dt.Rows[0][1].ToString() == admin.Password && System.Convert.ToInt32(dt.Rows[0][2].ToString()) != 0)
            {
                HttpContext.Session.SetString("AdminSession", admin.UserName);
                return new RedirectResult("/Admin/dashboard");

            }
            else
            {
                return View();
            }

        }

    }
}
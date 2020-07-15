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
            return new RedirectResult("/Admin/AdminSetting");
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


        public IActionResult AdminAccounts()
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
        public async Task<IActionResult> AdminAccounts(string UserName, string Password, string Firstname, string Lastname, string PhoneNumber, string EmailAddress)
        {

            ViewData["Title"] = "AdminAccounts";
            if (HttpContext.Session.GetString("AdminSession") == null)
            {
                return new RedirectResult("/Admin/AdminLogin");
            }
            {
                ViewData["Username"] = HttpContext.Session.GetString("AdminSession");
            }


            string myurl = $"{this.Request.Scheme}://{this.Request.Host}{this.Request.PathBase}";
            Dal connection = new Dal(myurl);

            SqlCommand cmd = new SqlCommand("sp_Crest_InsertAdmin", connection.connect())
            {
                CommandType = CommandType.StoredProcedure
            };
            cmd.Parameters.AddWithValue("@UserName", UserName);
            cmd.Parameters.AddWithValue("@Password", Password);
            cmd.Parameters.AddWithValue("@FirstName", Firstname);
            cmd.Parameters.AddWithValue("@Lastname", Lastname);
            cmd.Parameters.AddWithValue("@Level", "0");
            cmd.Parameters.AddWithValue("@PhoneNumber", PhoneNumber);
            cmd.Parameters.AddWithValue("@Email", EmailAddress);



            cmd.ExecuteNonQuery();

            connection.disconnect();


            return new RedirectResult("/Admin/AdminAccounts");


        }

        public ActionResult AdminDelete(int id)
        {
            string myurl = $"{this.Request.Scheme}://{this.Request.Host}{this.Request.PathBase}";
            Dal connection = new Dal(myurl);
            SqlCommand cmd = new SqlCommand("sp_crest_DeleteAdmin", connection.connect())
            {
                CommandType = CommandType.StoredProcedure
            };
            SqlParameter parametrid = new SqlParameter();
            parametrid.ParameterName = "@Adminid";
            parametrid.Value = id;
            cmd.Parameters.Add(parametrid);
            cmd.ExecuteNonQuery();


            return RedirectToAction("AdminAccounts");
        }


        public IActionResult AdminAccountEdit( string UserName)
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
            SqlCommand cmd = new SqlCommand("sp_Crest_MyAdmin", connection.connect());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@UserName", UserName);
            da.SelectCommand = cmd;
            da.Fill(dt);

            ViewData["Adminid"] = dt.Rows[0][0];
            ViewData["UserName"] = dt.Rows[0][1];
            ViewData["Password"] = dt.Rows[0][2];
            ViewData["FirstName"] = dt.Rows[0][3];
            ViewData["Lastname"] = dt.Rows[0][4];
            ViewData["PhoneNumber"] = dt.Rows[0][5];
            ViewData["Email"] = dt.Rows[0][6];



            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AdminEdit(Admin admin)
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
            return new RedirectResult("/Admin/AdminAccounts");
        }

        public IActionResult AdminAccountActive(string Level, int Adminid)
        {
            string myurl = $"{this.Request.Scheme}://{this.Request.Host}{this.Request.PathBase}";
            Dal connection = new Dal(myurl);
            SqlDataAdapter da = new SqlDataAdapter();
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand("sp_Crest_AdminActive", connection.connect());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Adminid", Adminid);
            if (Level == "0")
            {
                cmd.Parameters.AddWithValue("@Level", "2");
            }
            else if (Level == "2")
            {
                cmd.Parameters.AddWithValue("@Level", "0");
            }

            cmd.ExecuteNonQuery();
            return new RedirectResult("/Admin/AdminAccounts");
        }

        public IEnumerable<User> MySystemUser(DataTable dataTable)
        {

            foreach (DataRow item in dataTable.Rows)
            {
                yield return new User
                {
                    Userid = Convert.ToInt32(item["Userid"].ToString()),
                    UserName = item["UserName"].ToString(),
                    Password = item["Password"].ToString(),
                    FirstName = item["FirstName"].ToString(),
                    LastName = item["LastName"].ToString(),
                    PhoneNumber = item["PhoneNumber"].ToString(),
                    EmailAddress = item["EmailAddress"].ToString(),
                    Active = item["Active"].ToString(),

                };

            }
        }
        public IActionResult UserAccounts()
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
            SqlCommand cmd = new SqlCommand("sp_Crest_SystemUserList", connection.connect());
            cmd.CommandType = CommandType.StoredProcedure;
            da.SelectCommand = cmd;
            da.Fill(dt);
            return View(MySystemUser(dt));
        }

        public ActionResult SystemUserDelete(int id)
        {
            string myurl = $"{this.Request.Scheme}://{this.Request.Host}{this.Request.PathBase}";
            Dal connection = new Dal(myurl);
            SqlCommand cmd = new SqlCommand("sp_Crest_DeleteUser", connection.connect())
            {
                CommandType = CommandType.StoredProcedure
            };
            cmd.Parameters.AddWithValue("@Userid",id);

            cmd.ExecuteNonQuery();


            return RedirectToAction("UserAccounts");
        }

        public IActionResult SystemUserEdit(string Username)
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
            SqlCommand cmd = new SqlCommand("sp_Crest_MyUser", connection.connect());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@UserName", Username);
            da.SelectCommand = cmd;
            da.Fill(dt);

            
            ViewData["UserName"] = dt.Rows[0][1];
            ViewData["Password"] = dt.Rows[0][2];
            ViewData["FirstName"] = dt.Rows[0][3];
            ViewData["LastName"] = dt.Rows[0][4];
            ViewData["PhoneNumber"] = dt.Rows[0][5];
            ViewData["EmailAddress"] = dt.Rows[0][6];



            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult SystemUserEdite(User user)
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
            SqlCommand cmd = new SqlCommand("sp_Crest_UpdateUser", connection.connect());
            cmd.CommandType = CommandType.StoredProcedure;

            //cmd.Parameters.AddWithValue("@UserName", "mjn110");
            //cmd.Parameters.AddWithValue("@Password", "mjn110");
            //cmd.Parameters.AddWithValue("@FirstName", "mohammad");
            //cmd.Parameters.AddWithValue("@LastName", "najafi");
            //cmd.Parameters.AddWithValue("@PhoneNumber", "09386955901");
            //cmd.Parameters.AddWithValue("@EmailAddress", "mjn220@gmail.com");

            cmd.Parameters.AddWithValue("@UserName", user.UserName);
            cmd.Parameters.AddWithValue("@Password", user.Password);
            cmd.Parameters.AddWithValue("@FirstName", user.FirstName);
            cmd.Parameters.AddWithValue("@LastName", user.LastName);
            cmd.Parameters.AddWithValue("@PhoneNumber", user.PhoneNumber);
            cmd.Parameters.AddWithValue("@EmailAddress", user.EmailAddress);


            cmd.ExecuteNonQuery();
            return new RedirectResult("/Admin/UserAccounts");
        }

        public IActionResult UserAccountActive(string Active, int Userid)
        {
            string myurl = $"{this.Request.Scheme}://{this.Request.Host}{this.Request.PathBase}";
            Dal connection = new Dal(myurl);
            SqlDataAdapter da = new SqlDataAdapter();
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand("sp_Crest_UserActive", connection.connect());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Userid", Userid);
            if (Active == "0")
            {
                cmd.Parameters.AddWithValue("@Active", "1");
            }
            else if (Active == "1")
            {
                cmd.Parameters.AddWithValue("@Active", "0");
            }

            cmd.ExecuteNonQuery();
            return new RedirectResult("/Admin/UserAccounts");
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
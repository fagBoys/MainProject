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
using Microsoft.AspNetCore.Authorization;
using CrestCouriers_Career.ViewModels;
using CrestCouriers_Career.Data;
using Microsoft.EntityFrameworkCore;

namespace CrestCouriers_Career.Controllers
{
    public class UserController : Controller
    {

        private IHostingEnvironment _environment;

        private IRecaptchaService _recaptcha;
        public UserController(IHostingEnvironment environment, IRecaptchaService recaptcha)
        {
            _environment = environment;

            _recaptcha = recaptcha;
        }


        public IActionResult Index()
        {
            return View();
        }
        
        public IActionResult Register()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(User register, EmailRequest emailRequest)
        {

            ViewData["RepeatedUser"] = "no";
            if (ModelState.IsValid)
            {
                ViewData["Title"] = "register";

                //Recaptcha code begins here


                //var recaptcha = await _recaptcha.Validate(Request);
                //if (!recaptcha.success)
                //    ModelState.AddModelError("Recaptcha", "There was an error validating recatpcha. Please try again!");


                //Recaptcha code ends here

                string myurl = $"{this.Request.Scheme}://{this.Request.Host}{this.Request.PathBase}";
                Dal connection1 = new Dal(myurl);
                SqlCommand getUser = new SqlCommand("sp_Crest_MyUser", connection1.connect());
                SqlDataAdapter userda = new SqlDataAdapter();
                DataTable userdt = new DataTable();
                getUser.CommandType = CommandType.StoredProcedure;
                getUser.Parameters.AddWithValue("UserName", register.UserName);
                userda.SelectCommand = getUser;
                userda.Fill(userdt);
                if (userdt.Rows.Count > 0)
                {
                    ViewData["RepeatedUser"] = "yes";
                    return View();
                }
                else
                {
                    myurl = $"{this.Request.Scheme}://{this.Request.Host}{this.Request.PathBase}";
                    Dal connection2 = new Dal(myurl);

                    SqlCommand cmd = new SqlCommand("sp_Crest_Register", connection2.connect())
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    cmd.Parameters.AddWithValue("@FirstName", register.FirstName);
                    cmd.Parameters.AddWithValue("@LastName", register.LastName);
                    cmd.Parameters.AddWithValue("@UserName", register.UserName);
                    cmd.Parameters.AddWithValue("@Password", register.Password);
                    cmd.Parameters.AddWithValue("@PhoneNumber", register.PhoneNumber);
                    cmd.Parameters.AddWithValue("@EmailAddress", register.EmailAddress);
                    cmd.Parameters.AddWithValue("@Active", "1");


                    cmd.ExecuteNonQuery();

                    connection2.disconnect();


                    ///////    Send Email     ///////
                    MimeMessage message = new MimeMessage();

                    MailboxAddress from = new MailboxAddress("CrestCouriers", "test@crestcouriers.com");
                    message.From.Add(from);

                    MailboxAddress to = new MailboxAddress("CrestCouriers", "test@crestcouriers.com");
                    message.To.Add(to);

                    message.Subject = " register";

                    BodyBuilder bodyBuilder = new BodyBuilder();
                    var usericfile = System.IO.File.OpenRead(_environment.WebRootPath + @"\Email\newuser.png");
                    MemoryStream newms = new MemoryStream();
                    await usericfile.CopyToAsync(newms);


                    var mybody = @System.IO.File.ReadAllText(_environment.WebRootPath + @"\Email\emailbody-contact.html");

                    mybody = mybody.Replace("Value00", register.FirstName);
                    mybody = mybody.Replace("Value01", register.LastName);
                    mybody = mybody.Replace("Value02", register.UserName);
                    mybody = mybody.Replace("Value03", register.Password);
                    mybody = mybody.Replace("Value04", register.PhoneNumber);
                    mybody = mybody.Replace("Value05", register.EmailAddress);




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

                    MailboxAddress to2 = new MailboxAddress(register.FirstName + " " + register.LastName, register.EmailAddress);
                    message2.To.Add(to2);

                    message2.Subject = "register";


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






                    return View(!ModelState.IsValid ? register : new User());
                }
            }
            else
            {
                return View();
            }

        }


        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(User userlogin)
        {
            //if(!ModelState.IsValid)
            //{
            //    return View();
            //}
            //else
            //{ 
                string myurl = $"{this.Request.Scheme}://{this.Request.Host}{this.Request.PathBase}";
                Dal connection = new Dal(myurl);
                SqlDataAdapter da = new SqlDataAdapter();
                DataTable dt = new DataTable();
                SqlCommand cmd = new SqlCommand("sp_Crest_Login", connection.connect());
                cmd.Parameters.AddWithValue("@UserName", userlogin.UserName);
                cmd.CommandType = CommandType.StoredProcedure;
                da.SelectCommand = cmd;
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    if (dt.Rows[0][0].ToString() != userlogin.UserName && dt.Rows[0][1].ToString() != userlogin.Password && System.Convert.ToInt32(dt.Rows[0][2].ToString()) == 0)
                    {
                        return View();
                    }
                    else if (dt.Rows[0][0].ToString() == userlogin.UserName && dt.Rows[0][1].ToString() == userlogin.Password && System.Convert.ToInt32(dt.Rows[0][2].ToString()) != 0)
                    {
                        HttpContext.Session.SetString("UserSession", userlogin.UserName);
                        return new RedirectResult("/user/dashboard");
                    }
                }
                else
                {
                    return View();
                }

                return View();
            //}

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
            if(!ModelState.IsValid)
            {

                string myurl = $"{this.Request.Scheme}://{this.Request.Host}{this.Request.PathBase}";
                Dal connection = new Dal(myurl);
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = connection.connect();
                cmd.CommandText = "SELECT * From SystemUser WHERE EmailAddress='"+ model.Email +"'";
                SqlDataAdapter da = new SqlDataAdapter();
                DataTable dt = new DataTable();
                da.SelectCommand = cmd;
                da.Fill(dt);

                if (dt.Rows.Count > 0)
                {
                    
                }
                return View();
            }
            else
            {
                return View(model);
            }
        }

        public IEnumerable<Order> MyOrders(DataTable dataTable)
        {


            foreach (DataRow item in dataTable.Rows)
            {
                yield return new Order
                {
                    OrderId = System.Convert.ToInt32(item["Orderid"].ToString()),
                    OrderDate = Convert.ToDateTime(item["OrderDate"]),
                    Origin = item["Origin"].ToString(),
                    Destination = item["Destination"].ToString(),
                    CollectionDate = Convert.ToDateTime(item["CollectionDate"]),
                    DeliveryDate = Convert.ToDateTime(item["DeliveryDate"]),
                    CarType = item["CarType"].ToString(),
                    UserId = System.Convert.ToInt32(item["UserId"].ToString()),
                    Price = item["Price"].ToString(),
                    State = item["State"].ToString(),
                };
            }


        }
        public IActionResult Dashboard()
        {
            if (HttpContext.Session.GetString("UserSession") == null)
            {
                return new RedirectResult("/User/Login");
            }
            else
            {
                ViewData["Username"] = HttpContext.Session.GetString("UserSession");
            }

            //string myurl = $"{this.Request.Scheme}://{this.Request.Host}{this.Request.PathBase}";
            //Dal connection = new Dal(myurl);
            //SqlDataAdapter da = new SqlDataAdapter();
            //DataTable dt = new DataTable();
            //SqlCommand cmd = new SqlCommand("sp_Crest_UserOrderList", connection.connect());
            //cmd.CommandType = CommandType.StoredProcedure;
            //cmd.Parameters.AddWithValue("UserName", ViewData["Username"]);
            //da.SelectCommand = cmd;
            //da.Fill(dt);

            //EF core start

            CrestContext context = new CrestContext();
            IEnumerable<Order> orders = context.Order.ToList();

            //EF core end

            return View(orders);


        }

        public ActionResult Delete(int id)
        {
            //string myurl = $"{this.Request.Scheme}://{this.Request.Host}{this.Request.PathBase}";
            //Dal connection = new Dal(myurl);
            //SqlCommand cmd = new SqlCommand("sp_Crest_DeleteOrder", connection.connect())
            //{
            //    CommandType = CommandType.StoredProcedure
            //};
            //SqlParameter parametrid = new SqlParameter();
            //parametrid.ParameterName = "@Orderid";
            //parametrid.Value = id;
            //cmd.Parameters.Add(parametrid);
            //cmd.ExecuteNonQuery();

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
            if (HttpContext.Session.GetString("UserSession") == null)
            {
                return new RedirectResult("/User/Login");
            }
            else
            {
                ViewData["Username"] = HttpContext.Session.GetString("UserSession");
            }

            ViewData["Orderid"] = HttpContext.Session.GetString("OrderIDSession");

            //string myurl = $"{this.Request.Scheme}://{this.Request.Host}{this.Request.PathBase}";
            //Dal connection = new Dal(myurl);
            //SqlDataAdapter da = new SqlDataAdapter();
            //DataTable dt = new DataTable();
            //SqlCommand cmd = new SqlCommand("sp_Crest_MyOrder", connection.connect());
            //cmd.CommandType = CommandType.StoredProcedure;
            //cmd.Parameters.AddWithValue("@Orderid", id);
            //da.SelectCommand = cmd;
            //da.Fill(dt);

            //ViewData["Orderid"] = dt.Rows[0][0];
            //ViewData["Origin"] = dt.Rows[0][2];
            //ViewData["Destination"] = dt.Rows[0][3];
            //ViewData["ReceiveDate"] = dt.Rows[0][4];
            //ViewData["DeliveryDate"] = dt.Rows[0][5];
            //ViewData["CarType"] = dt.Rows[0][6];

            //EF core start
            CrestContext context = new CrestContext();
            Order order = context.Order.FirstOrDefault(o => o.OrderId == id);

            ViewData["Orderid"] = order.OrderId;
            ViewData["Origin"] = order.Origin;
            ViewData["Destination"] = order.Destination;
            ViewData["CollectionDate"] = order.CollectionDate;
            ViewData["DeliveryDate"] = order.DeliveryDate;
            ViewData["CarType"] = order.CarType;
            //EF core end


            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult EditOrder(Order editedorder)
        {
            if (HttpContext.Session.GetString("UserSession") == null)
            {
                return new RedirectResult("/User/Login");
            }
            {
                ViewData["Username"] = HttpContext.Session.GetString("UserSession");
            }

            //string myurl = $"{this.Request.Scheme}://{this.Request.Host}{this.Request.PathBase}";
            //Dal connection = new Dal(myurl);
            //SqlDataAdapter da = new SqlDataAdapter();
            //DataTable dt = new DataTable();
            //SqlCommand cmd = new SqlCommand("sp_Crest_UpdateOrder", connection.connect())
            //{
            //    CommandType = CommandType.StoredProcedure
            //};
            //cmd.Parameters.AddWithValue("@Orderid", order.OrderId);
            //cmd.Parameters.AddWithValue("@Origin", order.Origin);
            //cmd.Parameters.AddWithValue("@Destination", order.Destination);
            //cmd.Parameters.AddWithValue("@ReceiveDate", order.CollectionDate);
            //cmd.Parameters.AddWithValue("@DeliveryDate", order.DeliveryDate);
            //cmd.Parameters.AddWithValue("@CarType", order.CarType);


            //cmd.ExecuteNonQuery();

            //EF core start
            CrestContext context = new CrestContext();
            Order order = new Order();
            order = context.Order.FirstOrDefault(O => O.OrderId == editedorder.OrderId);
            editedorder.OrderDate = order.OrderDate;
            editedorder.Price = order.Price;
            editedorder.State = order.State;
            editedorder.UserId = order.UserId;
            CrestContext editcontext = new CrestContext();
            editcontext.Attach(editedorder).State = EntityState.Modified;
            editcontext.SaveChangesAsync();
            //EF core end

            return new RedirectResult("/User/dashboard");
        }


        public IActionResult Order()
        {
            if (HttpContext.Session.GetString("UserSession") == null)
            {
                return new RedirectResult("/User/Login");
            }
            {
                ViewData["Username"] = HttpContext.Session.GetString("UserSession");
            }

            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Order(Order order)
        {
            if (HttpContext.Session.GetString("UserSession") == null)
            {
                return new RedirectResult("/User/Login");
            }
            {
                ViewData["Username"] = HttpContext.Session.GetString("UserSession");
            }

            ViewData["Title"] = "Order";

            //Recaptcha code begins here


            //var recaptcha = await _recaptcha.Validate(Request);
            //if (!recaptcha.success)
            //    ModelState.AddModelError("Recaptcha", "There was an error validating recatpcha. Please try again!");


            //Recaptcha code ends here




            ///////////////////////////////////////////////

            //string myurl = $"{this.Request.Scheme}://{this.Request.Host}{this.Request.PathBase}";
            //Dal connection = new Dal(myurl);

            //SqlCommand cmd = new SqlCommand("sp_Crest_NewOrder", connection.connect())
            //{
            //    CommandType = CommandType.StoredProcedure
            //};
            //cmd.Parameters.AddWithValue("@OrderDate", DateTime.Now);
            //cmd.Parameters.AddWithValue("@Origin", order.Origin);
            //cmd.Parameters.AddWithValue("@Destination", order.Destination);
            //cmd.Parameters.AddWithValue("@ReceiveDate", order.CollectionDate);
            //cmd.Parameters.AddWithValue("@DeliveryDate", order.DeliveryDate);
            //cmd.Parameters.AddWithValue("@CarType", order.CarType);
            //cmd.Parameters.AddWithValue("@Userid", "1");
            //cmd.Parameters.AddWithValue("@Price", "0");
            //cmd.Parameters.AddWithValue("@State", "1");
            //cmd.ExecuteNonQuery();
            //connection.disconnect();



            //EF CORE START

            CrestContext context = new CrestContext();

            context.Order.Add(order);
            order.Price = "0";
            order.UserId = 1;
            order.State = "1";
            context.SaveChanges();

            //EF CORE END

            return View(!ModelState.IsValid ? order : new Order());

        }

        public IActionResult orderlist()
        {
            return View();
        }

        public IActionResult User()
        {
            if (HttpContext.Session.GetString("UserSession") == null)
            {
                return new RedirectResult("/User/Login");
            }
            {
                ViewData["Username"] = HttpContext.Session.GetString("UserSession");
            }

            //string myurl = $"{this.Request.Scheme}://{this.Request.Host}{this.Request.PathBase}";
            //Dal connection = new Dal(myurl);
            //SqlDataAdapter da = new SqlDataAdapter();
            //DataTable dt = new DataTable();
            //SqlCommand cmd = new SqlCommand("sp_Crest_MyUser", connection.connect());
            //cmd.CommandType = CommandType.StoredProcedure;
            //cmd.Parameters.AddWithValue("@Username", HttpContext.Session.GetString("UserSession"));
            //da.SelectCommand = cmd;
            //da.Fill(dt);

            //EF
            CrestContext context = new CrestContext();
            User users = context.User.FirstOrDefault(U => U.UserName == ViewData["Username"].ToString());
            //EF

            ViewData["myuser-Username"] = users.UserName;
            ViewData["myuser-Password"] = users.Password;
            ViewData["myuser-FirstName"] = users.FirstName;
            ViewData["myuser-LastName"] = users.LastName;
            ViewData["myuser-PhoneNumber"] = users.PhoneNumber;
            ViewData["myuser-EmailAddress"] = users.EmailAddress;

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult User(User user)
        {
            if (HttpContext.Session.GetString("UserSession") == null)
            {
                return new RedirectResult("/User/Login");
            }
            {
                ViewData["Username"] = HttpContext.Session.GetString("UserSession");
            }

            //string myurl = $"{this.Request.Scheme}://{this.Request.Host}{this.Request.PathBase}";
            //Dal connection = new Dal(myurl);
            //SqlCommand cmd = new SqlCommand("sp_Crest_UpdateUser", connection.connect());
            //cmd.CommandType = CommandType.StoredProcedure;
            //cmd.Parameters.AddWithValue("@UserName", user.UserName);
            //cmd.Parameters.AddWithValue("@Password", user.Password);
            //cmd.Parameters.AddWithValue("@FirstName", user.FirstName);
            //cmd.Parameters.AddWithValue("@LastName", user.LastName);
            //cmd.Parameters.AddWithValue("@PhoneNumber", user.PhoneNumber);
            //cmd.Parameters.AddWithValue("@EmailAddress", user.EmailAddress);

            //cmd.ExecuteNonQuery();



            ////EF core start
            CrestContext context = new CrestContext();

            User user1 = new User();
            user1 = context.User.FirstOrDefault(O => O.UserName == user.UserName);

            user.Active = user1.Active;
            user.UserId = user1.UserId;

            CrestContext editcontext = new CrestContext();
            editcontext.Attach(user).State = EntityState.Modified;
            editcontext.SaveChangesAsync();
            ////EF core end













            return new RedirectResult("/User/User");
        }

    }
}
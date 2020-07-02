using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CrestCouriers_Career.Models;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;
using System.Data;


namespace CrestCouriers_Career.Controllers
{
    public class AdminController : Controller
    {
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

        public IActionResult Order()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Order(Order order)
        {
            ViewData["Title"] = "Order";

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
            cmd.Parameters.AddWithValue("@Userid", "1");
            cmd.Parameters.AddWithValue("@Price", "0");
            cmd.Parameters.AddWithValue("@State", "1");



            cmd.ExecuteNonQuery();

            connection.disconnect();

            
            return View(!ModelState.IsValid ? order : new Order());
            
        }


        public IActionResult AdminSetting()
        {
            return View();
        }
        public IActionResult AdminAccounts()
        {
            return View();
        }
        public IActionResult UserAccounts()
        {
            return View();
        }
    }
}
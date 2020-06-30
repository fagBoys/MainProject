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
            SqlCommand cmd = new SqlCommand("sp_Crest__OrderList", connection.connect());
            cmd.CommandType = CommandType.StoredProcedure;
            da.SelectCommand = cmd;
            da.Fill(dt);
            return View(OrderList(dt));
        }

        public IActionResult Order()
        {
            return View();
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
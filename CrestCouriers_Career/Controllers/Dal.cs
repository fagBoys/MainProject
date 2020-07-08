using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using Microsoft.AspNetCore.Http;

namespace CrestCouriers_Career.Controllers
{
    
    public class Dal
    {
        private readonly string myurl;
        public Dal(string url)
        {
            myurl = url;
        }

        SqlConnection con = new SqlConnection();
        public SqlConnection connect()
        {
            //string myHostUrl = $"{_httpContextAccessor.HttpContext.Request.Scheme}://{_httpContextAccessor.HttpContext.Request.Host}";

            string fagboysdb = @"Server=127.0.0.1;Database=fagboys;User Id=fagboys;Password=FAGpass123;Integrated Security=False;";
            string crestdb = @"Server=sql11.hostinguk.net;Database=crestcou_database;User Id=crestdbuser;Password=CRESTcouriers.db;Integrated Security=False;";
            string localdb = @"Data Source=DESKTOP-N7V04NE;Initial Catalog=Crest;Integrated Security=True;";

            if(myurl == "https://localhost:44325")
            { 
                con.ConnectionString = localdb;
            }
            else if(myurl == "http://fagboys.ir")
            {
                con.ConnectionString = fagboysdb;
            }
            else if (myurl == "http://www.crestcouriers.com")
            {
                con.ConnectionString = crestdb;
            }
            else
            {
                con.ConnectionString = crestdb;
            }
            con.Open();

            return con;
        }



        public void disconnect() 
        {

            con.Close();
        
        
        }




    }
}

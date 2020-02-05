using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;

namespace CrestCouriers_Career.Controllers
{
    public class Dal
    {
        SqlConnection con = new SqlConnection();
        public SqlConnection connect()
        {
            //string con = @"Data Source=DESKTOP-N7V04NE;Initial Catalog=Crest;Integrated Security=True;";
            con.ConnectionString= @"Data Source=127.0.0.1;Initial Catalog=fagboys;userid=fagboys;password=y@SDJENjVnt;Integrated Security=True;";
            con.Open();

            return con;
        }



        public void disconnect() 
        {

            con.Close();
        
        
        }




    }
}

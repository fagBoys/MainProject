using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrestCouriers_Career.Controllers
{
    public class connectionDB
    {

        public string conn()
        {
            string con = @"Data Source=DESKTOP-N7V04NE;Initial Catalog=Crest;Integrated Security=True;";

            return con;
        }


    }
}

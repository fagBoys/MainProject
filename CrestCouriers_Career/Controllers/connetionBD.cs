using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace CrestCouriers_Career.Controllers
{
    public class connetionBD
    {
        SqlConnection connectionDB = new SqlConnection(@"Data Source=DESKTOP-N7V04NE;Initial Catalog=Crest;Integrated Security=True;");

    }
}

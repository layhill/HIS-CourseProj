using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace HISCourseProj
{
    class DBConn
    {
        private static string connString = "Data Source=HillPC;Initial Catalog=HISCourseProj;Persist Security Info=True;User ID=sa;Password=root";
        public static SqlConnection conn = new SqlConnection(connString);
    }
}

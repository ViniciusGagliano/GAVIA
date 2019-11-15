using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBConnectionControl
{
    public class Connection
    {
        protected SqlConnection con;
        protected SqlCommand cmd;
        protected SqlDataReader dr;

        protected void OpenConnection()
        {
            string server = "localhost";
            string db = "develop";
            string connectionString = $"Server=${server}; Database=${db}; Integrated Security=True";

            this.con = new SqlConnection(connectionString);
            this.cmd = new SqlCommand("", this.con);
            this.con.Open();
        }

        protected void CloseConnection() => this.con.Close();
    }
}

using DBConnectionControl;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class ImportacaoRepository : Connection
    {
        public void Insert()
        {
            try
            {
                OpenConnection();
                using (var cmd = new SqlCommand("", con))
                {

                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally { CloseConnection(); }
        }
    }
}

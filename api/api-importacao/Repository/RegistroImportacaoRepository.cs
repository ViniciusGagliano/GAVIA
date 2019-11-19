using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DBConnectionControl;

namespace Repository
{
    public class RegistroImportacaoRepository : Connection
    {
        public void Insert()
        {
            try
            {
                OpenConnection();
                using (var cmd = new SqlCommand("", con))
                {
                    cmd.CommandText = "UP_REGISTRO_IMPORTACAO";
                    cmd.CommandType = CommandType.Text;
                    dr = cmd.ExecuteReader();
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {

                        }
                    }
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

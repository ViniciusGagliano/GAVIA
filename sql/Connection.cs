using DLLCriptografia;
using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace controle_conexao_databases
{
    public class Connection
    {
        private SqlConnection conTutu;
        private SqlCommand cmdTutu;
        private SqlDataReader drTutu;

        protected SqlConnection con;
        protected SqlCommand cmd;
        protected SqlDataReader dr;
        protected SqlTransaction transaction;

        private void OpenConnectionTutu()
        {
            Criptografia cript = new Criptografia();

            string ip = cript.Descriptografar(ConfigurationManager.AppSettings.Get("IP"));
            string database = cript.Descriptografar(ConfigurationManager.AppSettings.Get("Database"));
            string user = cript.Descriptografar(ConfigurationManager.AppSettings.Get("User"));
            string password = cript.Descriptografar(ConfigurationManager.AppSettings.Get("Password"));

            string connectionString = $"Server={ip};Database={database};User ID={user};Password={password};Trusted_Connection=False;";

            conTutu = new SqlConnection(connectionString);
            cmdTutu = new SqlCommand("", conTutu);
            cmdTutu.CommandTimeout = Convert.ToInt32(ConfigurationManager.AppSettings.Get("timeOutConnection"));
            conTutu.Open();
        }

        private void CloseConnectionTutu()
        {
            conTutu.Close();
        }


        protected void OpenConnectionCliente(int codigoClienteSuporte)
        {
            OpenConnectionTutu();

            using (cmdTutu)
            {
                cmdTutu.CommandText = "SELECT ipDatabase, [Database], [User], [Password] FROM ViewGetDadosCliente WHERE CodigoClienteSuporte = @CODIGO_CLIENTE_SUPORTE";
                cmdTutu.CommandType = CommandType.Text;

                cmdTutu.Parameters.Add(new SqlParameter("@CODIGO_CLIENTE_SUPORTE", SqlDbType.Int)).Value = codigoClienteSuporte;

                drTutu = cmdTutu.ExecuteReader();

                if (drTutu.HasRows)
                {
                    string IpCliente = string.Empty;
                    string Database = string.Empty;
                    string User = string.Empty;
                    string Password = string.Empty;

                    while (drTutu.Read())
                    {
                        IpCliente = Convert.ToString(drTutu["ipDatabase"]);
                        Database = Convert.ToString(drTutu["Database"]);
                        User = Convert.ToString(drTutu["User"]);
                        Password = Convert.ToString(drTutu["Password"]);
                    }

                    CloseConnectionTutu();

                    string connectionStringCliente = $"Server={IpCliente};Database={Database};User ID={User};Password={Password};Trusted_Connection=False;";

                    con = new SqlConnection(connectionStringCliente);
                    cmd = new SqlCommand("", con);
                    cmd.CommandTimeout = Convert.ToInt32(ConfigurationManager.AppSettings.Get("timeOutConnection"));
                    con.Open();
                }
                else
                {
                    throw new Exception("Erro ao tentar conexão com a base do cliente");
                }
            }
        }

        protected void CloseConnectionCliente()
        {
            con.Close();
        }
    }
}

using DBConnectionControl;
using Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class ImportacaoRepository : Connection
    {
        public void Insert(Importacao importacao)
        {
            try
            {
                OpenConnection();
                using (var cmd = new SqlCommand("", con))
                {
                    cmd.CommandText = "UP_IMPORTACAO_INSERT";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@NOME_ARQUIVO", SqlDbType.VarChar)).Value = Convert.ToString(importacao.NomeArquivo);
                    cmd.Parameters.Add(new SqlParameter("@CAMINHO_ARQUIVO", SqlDbType.VarChar)).Value = Convert.ToString(importacao.CaminhoArquivo);
                    cmd.Parameters.Add(new SqlParameter("@SEGURADORA_ID", SqlDbType.Int)).Value = Convert.ToInt32(importacao.SeguradoraId);
                    cmd.Parameters.Add(new SqlParameter("@ANTECIPACAO", SqlDbType.Bit)).Value = Convert.ToInt32(importacao.Antecipacao);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally { CloseConnection(); }
        }
        public void GetAll()
        {
            try
            {
                OpenConnection();
                using (var cmd = new SqlCommand("", con))
                {
                    cmd.CommandText = "";
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
        public void GetById(int id)
        {
            try
            {
                OpenConnection();
                using (var cmd = new SqlCommand("", con))
                {
                    cmd.CommandText = "";
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

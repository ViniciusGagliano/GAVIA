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
    public class SeguradoraRepository : Connection
    {
        public void Insert(SeguradoraEntity seguradora)
        {
            try
            {
                OpenConnection();
                using (var cmd = new SqlCommand("", con))
                {
                    cmd.CommandText = "UP_SEGURADORA_CADASTRAR";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@NOME", SqlDbType.VarChar)).Value = Convert.ToString(seguradora.Nome).Trim();
                    cmd.Parameters.Add(new SqlParameter("@CNPJ", SqlDbType.VarChar)).Value = Convert.ToString(seguradora.CNPJ).Trim();
                    cmd.Parameters.Add(new SqlParameter("@ANTECIPACAO", SqlDbType.Bit)).Value = Convert.ToBoolean(seguradora.Antecipacao);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
            finally
            {
                CloseConnection();
            }
        }

        public List<SeguradoraEntity> GetAll()
        {
            try
            {
                OpenConnection();
                using (var cmd = new SqlCommand("", con))
                {
                    cmd.CommandText = "UP_SEGURADORA_BUSCAR";
                    cmd.CommandType = CommandType.StoredProcedure;
                    dr = cmd.ExecuteReader();
                    List<SeguradoraEntity> seguradoras = new List<SeguradoraEntity>();
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            seguradoras.Add(new SeguradoraEntity()
                            {
                                Id = Convert.ToInt32(dr["ID"]),
                                Nome = Convert.ToString(dr["NOME"]),
                                CNPJ = Convert.ToString(dr["CNPJ"]),
                                Ativo = Convert.ToBoolean(dr["ATIVO"]),
                                Antecipacao = Convert.ToBoolean(dr["CONTROLA_ANTECIPACAO"]),
                                DataCriacao = Convert.ToDateTime(dr["DATA_CRIACAO"]),
                            });
                        }
                    }
                    return seguradoras;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
            finally
            {
                CloseConnection();
            }
        }

        public SeguradoraEntity GetById(int id)
        {
            try
            {
                cmd.CommandText = "UP_SEGURADORA_BUSCAR";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@ID", SqlDbType.Bit)).Value = Convert.ToInt32(id);
                dr = cmd.ExecuteReader();
                SeguradoraEntity seguradora = null;
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        seguradora = new SeguradoraEntity()
                        {
                            Id = Convert.ToInt32(dr["ID"]),
                            Nome = Convert.ToString(dr["NOME"]),
                            CNPJ = Convert.ToString(dr["CNPJ"]),
                            Ativo = Convert.ToBoolean(dr["Ativo"]),
                            Antecipacao = Convert.ToBoolean(dr["CONTROLA_ANTECIPACAO"]),
                            DataCriacao = Convert.ToDateTime(dr["DATA_CRIACAO"])
                        };
                    }
                }
                return seguradora;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
            finally
            {
                CloseConnection();
            }
        }

        public void Update (SeguradoraEntity seguradora)
        {
            try
            {
                OpenConnection();
                using (var cmd = new SqlCommand("", con))
                {
                    cmd.CommandText = "UP_SEGURADORA_ATUALIZAR";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@ID", SqlDbType.Int)).Value = Convert.ToInt32(seguradora.Id);
                    cmd.Parameters.Add(new SqlParameter("@NOME", SqlDbType.VarChar)).Value = (string.IsNullOrEmpty(seguradora.Nome)) ? Convert.DBNull : Convert.ToString(seguradora.Nome).Trim();
                    cmd.Parameters.Add(new SqlParameter("@CNPJ", SqlDbType.VarChar)).Value = (string.IsNullOrEmpty(seguradora.CNPJ)) ? Convert.DBNull : Convert.ToString(seguradora.CNPJ).Trim();
                    cmd.Parameters.Add(new SqlParameter("@ANTECIPACAO", SqlDbType.Bit)).Value = Convert.ToBoolean(seguradora.Antecipacao);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
            finally
            {
                CloseConnection();
            }
        }

        public void Delete(int id)
        {
            try
            {
                OpenConnection();
                using (var cmd = new SqlCommand("", con))
                {
                    cmd.CommandText = "UP_SEGURADORA_DELETAR";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@ID", SqlDbType.Int)).Value = Convert.ToInt32(id);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
            finally
            {
                CloseConnection();
            }
        }
    }
}

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
        public int Insert(SeguradoraEntity seguradora)
        {
            try
            {
                OpenConnection();
                using (var cmd = new SqlCommand("", con))
                {
                    cmd.CommandText = "UP_SEGURADORA_CADASTRAR";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@NOME", SqlDbType.VarChar)).Value = Convert.ToString(seguradora.Nome).Trim();
                    cmd.Parameters.Add(new SqlParameter("@CNPJ", SqlDbType.VarChar)).Value = Convert.ToString(seguradora.CNPJ);
                    dr = cmd.ExecuteReader();
                    int id = 0;
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            id = Convert.ToInt32(dr["ID"]);
                        }
                    }
                    return id;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
            finally { CloseConnection(); }
        }

        public List<SeguradoraEntity> GetAll(int statusAtivacao)
        {
            try
            {
                OpenConnection();
                using (var cmd = new SqlCommand("", con))
                {
                    cmd.CommandText = "UP_SEGURADORA_BUSCAR";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@APENAS_ATIVO", SqlDbType.Bit)).Value = (statusAtivacao > 1) ? Convert.DBNull : Convert.ToBoolean(statusAtivacao);
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
                                DataCriacao = Convert.ToDateTime(dr["DATA_CRIACAO"]),
                                Ativo = Convert.ToBoolean(dr["ATIVO"])
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
            finally { CloseConnection(); }
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
                            DataCriacao = Convert.ToDateTime(dr["DATA_CRIACAO"]),
                            Ativo = Convert.ToBoolean(dr["Ativo"])
                        };
                    }
                }
                return seguradora;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
            finally { CloseConnection(); }
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
                    cmd.Parameters.Add(new SqlParameter("@NOME", SqlDbType.Int)).Value = Convert.ToString(seguradora.Nome).Trim();
                    cmd.Parameters.Add(new SqlParameter("@CNPJ", SqlDbType.Int)).Value = Convert.ToString(seguradora.CNPJ);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
            finally { CloseConnection(); }
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
            finally { CloseConnection(); }
        }
    }
}

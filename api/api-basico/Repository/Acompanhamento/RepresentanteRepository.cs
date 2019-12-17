using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DBConnectionControl;
using System.Data.SqlClient;
using System.Data;

namespace Repository
{
    public class RepresentanteRepository : Connection
    {
        public void Insert(RepresentanteEntity representante)
        {
            try
            {
                OpenConnection();
                using (var cmd = new SqlCommand("", con))
                {
                    cmd.CommandText = "UP_REPRESENTANTE_CADASTRAR";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@NOME", SqlDbType.VarChar)).Value = Convert.ToString(representante.Nome).Trim();
                    cmd.Parameters.Add(new SqlParameter("@CNPJ", SqlDbType.VarChar)).Value = Convert.ToString(representante.CNPJ).Trim();
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

        public List<RepresentanteEntity> GetAll()
        {
            try
            {
                OpenConnection();
                using (var cmd = new SqlCommand("", con))
                {
                    cmd.CommandText = "UP_REPRESENTANTE_BUSCAR";
                    cmd.CommandType = CommandType.StoredProcedure;
                    dr = cmd.ExecuteReader();
                    List<RepresentanteEntity> representantes = new List<RepresentanteEntity>();
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            representantes.Add(new RepresentanteEntity()
                            {
                                Id = Convert.ToInt32(dr["ID"]),
                                Nome = Convert.ToString(dr["NOME"]),
                                CNPJ = Convert.ToString(dr["CNPJ"]),
                                Ativo = Convert.ToBoolean(dr["ATIVO"]),
                                DataCriacao = Convert.ToDateTime(dr["DATA_CRIACAO"])
                            });
                        }
                    }
                    return representantes;
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

        public RepresentanteEntity GetById(int id)
        {
            try
            {
                OpenConnection();
                using (var cmd = new SqlCommand("", con))
                {
                    cmd.CommandText = "UP_REPRESENTANTE_BUSCAR";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@ID", SqlDbType.Int)).Value = Convert.ToInt32(id);
                    dr = cmd.ExecuteReader();
                    RepresentanteEntity representante = null;
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            representante = new RepresentanteEntity()
                            {
                                Id = Convert.ToInt32(dr["ID"]),
                                Nome = Convert.ToString(dr["NOME"]),
                                CNPJ = Convert.ToString(dr["CNPJ"]),
                                Ativo = Convert.ToBoolean(dr["BIT_ATIVO"]),
                                DataCriacao = Convert.ToDateTime(dr["DATA_CRIACAO"])
                            };
                        }
                    }
                    return representante;
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

        public void Update(RepresentanteEntity representante)
        {
            try
            {
                OpenConnection();
                using (var cmd = new SqlCommand("", con))
                {
                    cmd.CommandText = "UP_REPRESENTANTE_ATUALIZAR";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@ID", SqlDbType.Int)).Value = Convert.ToInt32(representante.Id);
                    cmd.Parameters.Add(new SqlParameter("@NOME", SqlDbType.VarChar)).Value = Convert.ToString(representante.Nome);
                    cmd.Parameters.Add(new SqlParameter("@CNPJ", SqlDbType.VarChar)).Value = Convert.ToString(representante.CNPJ);
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
                    cmd.CommandText = "UP_REPRESENTANTE_DELETAR";
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

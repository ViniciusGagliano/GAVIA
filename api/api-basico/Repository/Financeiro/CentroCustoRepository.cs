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
    public class CentroCustoRepository : Connection
    {
        public void Insert(CentroCustoEntity centroCusto)
        {
            try
            {
                OpenConnection();
                using (cmd = new SqlCommand("", con))
                {
                    cmd.CommandText = "cap.UP_CENTRO_CUSTO_CADASTRAR";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@NOME", SqlDbType.VarChar, 100)).Value = centroCusto.Nome;
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                CloseConnection();
            }
        }

        public List<CentroCustoEntity> GetAll()
        {
            try
            {
                OpenConnection();
                using (cmd = new SqlCommand("", con))
                {
                    cmd.CommandText = "cap.UP_CENTRO_CUSTO_BUSCAR";
                    cmd.CommandType = CommandType.StoredProcedure;
                    dr = cmd.ExecuteReader();
                    List<CentroCustoEntity> centroCustos = new List<CentroCustoEntity>();
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            centroCustos.Add(new CentroCustoEntity()
                            {
                                Id = Convert.ToInt32(dr["ID"]),
                                Nome = Convert.ToString(dr["NOME"]),
                                Ativo = Convert.ToBoolean(dr["ATIVO"])
                            });
                        }
                    }
                    return centroCustos;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                CloseConnection();
            }
        }

        public CentroCustoEntity GetById(int id)
        {
            try
            {
                OpenConnection();
                using (cmd = new SqlCommand("", con))
                {
                    cmd.CommandText = "cap.UP_CENTRO_CUSTO_BUSCAR";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@ID", SqlDbType.Int)).Value = id;
                    dr = cmd.ExecuteReader();
                    CentroCustoEntity centroCusto = null;
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            centroCusto = new CentroCustoEntity()
                            {
                                Id = Convert.ToInt32(dr["ID"]),
                                Nome = Convert.ToString(dr["NOME"]),
                                Ativo = Convert.ToBoolean(dr["ATIVO"])
                            };
                        }
                    }
                    return centroCusto;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                CloseConnection();
            }
        }

        public void Update(CentroCustoEntity centroCusto)
        {
            try
            {
                OpenConnection();
                using (cmd = new SqlCommand("", con))
                {
                    cmd.CommandText = "cap.UP_CENTRO_CUSTO_ATUALIZAR";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@ID", SqlDbType.Int)).Value = centroCusto.Id;
                    cmd.Parameters.Add(new SqlParameter("@NOME", SqlDbType.VarChar, 100)).Value = centroCusto.Nome;
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
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
                using (cmd = new SqlCommand("", con))
                {
                    cmd.CommandText = "cap.UP_CENTRO_CUSTO_DELETAR";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@ID", SqlDbType.Int)).Value = id;
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                CloseConnection();
            }
        }
    }
}

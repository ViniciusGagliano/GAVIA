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
    public class FornecedorRepository : Connection
    {
        public void Insert(FornecedorEntity fornecedor)
        {
            try
            {
                OpenConnection();
                using (cmd = new SqlCommand("", con))
                {
                    cmd.CommandText = "cap.UP_FORNECEDOR_CADASTRAR";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@NOME", SqlDbType.VarChar, 100)).Value = fornecedor.Nome;
                    cmd.Parameters.Add(new SqlParameter("@CNPJ", SqlDbType.VarChar, 14)).Value = fornecedor.CNPJ;
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

        public List<FornecedorEntity> GetAll()
        {
            try
            {
                OpenConnection();
                using (cmd = new SqlCommand("", con))
                {
                    cmd.CommandText = "cap.UP_FORNECEDOR_BUSCAR";
                    cmd.CommandType = CommandType.StoredProcedure;
                    dr = cmd.ExecuteReader();
                    List<FornecedorEntity> fornecedors = new List<FornecedorEntity>();
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            fornecedors.Add(new FornecedorEntity()
                            {
                                Id = Convert.ToInt32(dr["ID"]),
                                Nome = Convert.ToString(dr["NOME"]),
                                CNPJ = Convert.ToString(dr["CNPJ"]),
                                Ativo = Convert.ToBoolean(dr["ATIVO"])
                            });
                        }
                    }
                    return fornecedors;
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

        public FornecedorEntity GetById(int id)
        {
            try
            {
                OpenConnection();
                using (cmd = new SqlCommand("", con))
                {
                    cmd.CommandText = "cap.UP_FORNECEDOR_BUSCAR";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@ID", SqlDbType.Int)).Value = id;
                    dr = cmd.ExecuteReader();
                    FornecedorEntity fornecedor = null;
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            fornecedor = new FornecedorEntity()
                            {
                                Id = Convert.ToInt32(dr["ID"]),
                                Nome = Convert.ToString(dr["NOME"]),
                                CNPJ = Convert.ToString(dr["CNPJ"]),
                                Ativo = Convert.ToBoolean(dr["ATIVO"])
                            };
                        }
                    }
                    return fornecedor;
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

        public void Update(FornecedorEntity fornecedor)
        {
            try
            {
                OpenConnection();
                using (cmd = new SqlCommand("", con))
                {
                    cmd.CommandText = "cap.UP_FORNECEDOR_ATUALIZAR";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@ID", SqlDbType.Int)).Value = fornecedor.Id;
                    cmd.Parameters.Add(new SqlParameter("@NOME", SqlDbType.VarChar, 100)).Value = fornecedor.Nome;
                    cmd.Parameters.Add(new SqlParameter("@CNPJ", SqlDbType.VarChar, 14)).Value = fornecedor.CNPJ;
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
                    cmd.CommandText = "cap.UP_FORNECEDOR_DELETAR";
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

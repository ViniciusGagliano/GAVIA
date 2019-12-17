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
    public class ClienteRepository : Connection
    {
        public void Insert(ClienteEntity cliente)
        {
            try
            {
                OpenConnection();
                using (var cmd = new SqlCommand("", con))
                {
                    cmd.CommandText = "fin.UP_CLIENTE_CADASTRAR";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@NOME", SqlDbType.VarChar)).Value = cliente.Nome;
                    cmd.Parameters.Add(new SqlParameter("@SEGURADORA_ID", SqlDbType.Int)).Value = (cliente.Seguradora != null) ? cliente.Seguradora.Id : Convert.DBNull;
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

        public List<ClienteEntity> GetAll()
        {
            try
            {
                OpenConnection();
                using (cmd = new SqlCommand("", con))
                {
                    cmd.CommandText = "fin.UP_CLIENTE_BUSCAR";
                    cmd.CommandType = CommandType.StoredProcedure;
                    dr = cmd.ExecuteReader();
                    List<ClienteEntity> clientes = new List<ClienteEntity>();
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            clientes.Add(new ClienteEntity()
                            {
                                Id = Convert.ToInt32(dr["ID"]),
                                Nome = Convert.ToString(dr["NOME"]),
                                Ativo = Convert.ToBoolean(dr["ATIVO"]),
                                Seguradora = (Convert.IsDBNull(dr["SEGURADORA_ID"])) ? null : new SeguradoraEntity()
                                {
                                    Id = Convert.ToInt32(dr["SEGURADORA_ID"]),
                                    Nome = Convert.ToString(dr["SEGURADORA_NOME"]),
                                    CNPJ = Convert.ToString(dr["SEGURADORA_CNPJ"])
                                }
                            });
                        }
                    }
                    return clientes;
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

        public ClienteEntity GetById(int id)
        {
            try
            {
                OpenConnection();
                using (cmd = new SqlCommand("", con))
                {
                    cmd.CommandText = "fin.UP_CLIENTE_BUSCAR";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@ID", SqlDbType.Int)).Value = id;
                    dr = cmd.ExecuteReader();
                    ClienteEntity cliente = null;
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            cliente = new ClienteEntity()
                            {
                                Id = Convert.ToInt32(dr["ID"]),
                                Nome = Convert.ToString(dr["NOME"]),
                                Ativo = Convert.ToBoolean(dr["ATIVO"]),
                                Seguradora = (Convert.IsDBNull(dr["SEGURADORA_ID"])) ? null : new SeguradoraEntity()
                                {
                                    Id = Convert.ToInt32(dr["SEGURADORA_ID"]),
                                    Nome = Convert.ToString(dr["SEGURADORA_NOME"]),
                                    CNPJ = Convert.ToString(dr["SEGURADORA_CNPJ"])
                                }
                            };
                        }
                    }
                    return cliente;
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

        public void Update(ClienteEntity cliente)
        {
            try
            {
                OpenConnection();
                using (cmd = new SqlCommand("", con))
                {
                    cmd.CommandText = "fin.UP_CLIENTE_ATUALIZAR";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@ID", SqlDbType.Int)).Value = cliente.Id;
                    cmd.Parameters.Add(new SqlParameter("@NOME", SqlDbType.VarChar, 100)).Value = cliente.Nome;
                    cmd.Parameters.Add(new SqlParameter("@SEGURADORA_ID", SqlDbType.Int)).Value = cliente.Seguradora.Id;
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
                    cmd.CommandText = "fin.UP_CLIENTE_DELETAR";
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

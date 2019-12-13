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
    public class CategoriaRepository : Connection
    {
        public void Insert(CategoriaEntity categoria)
        {
            try
            {
                OpenConnection();
                using (cmd = new SqlCommand("", con))
                {
                    cmd.CommandText = "cap.UP_CATEGORIA_CADASTRAR";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@NOME", SqlDbType.VarChar, 100)).Value = categoria.Nome;
                    cmd.Parameters.Add(new SqlParameter("@TIPO_LANCAMENTO_ID", SqlDbType.Int)).Value = categoria.TipoLancamento.Id;
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

        public List<CategoriaEntity> GetAll()
        {
            try
            {
                OpenConnection();
                using (cmd = new SqlCommand("", con))
                {
                    cmd.CommandText = "cap.UP_CATEGORIA_BUSCAR";
                    cmd.CommandType = CommandType.StoredProcedure;
                    dr = cmd.ExecuteReader();
                    List<CategoriaEntity> categorias = new List<CategoriaEntity>();
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            categorias.Add(new CategoriaEntity()
                            {
                                Id = Convert.ToInt32(dr["ID"]),
                                Nome = Convert.ToString(dr["NOME"]),
                                Ativo = Convert.ToBoolean(dr["ATIVO"]),
                                TipoLancamento = new TipoLancamento()
                                {
                                    Id = Convert.ToInt32(dr["TIPO_LANCAMENTO_ID"]),
                                    Nome = Convert.ToString(dr["TIPO_LANCAMENTO_NOME"]),
                                    Multiplicador = Convert.ToInt32(dr["TIPO_LANCAMENTO_MULTIPLICADOR"])
                                }
                            });
                        }
                    }
                    return categorias;
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

        public CategoriaEntity GetById(int id)
        {
            try
            {
                OpenConnection();
                using (cmd = new SqlCommand("", con))
                {
                    cmd.CommandText = "cap.UP_CATEGORIA_BUSCAR";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@ID", SqlDbType.Int)).Value = id;
                    dr = cmd.ExecuteReader();
                    CategoriaEntity categoria = null;
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            categoria = new CategoriaEntity()
                            {
                                Id = Convert.ToInt32(dr["ID"]),
                                Nome = Convert.ToString(dr["NOME"]),
                                Ativo = Convert.ToBoolean(dr["ATIVO"]),
                                TipoLancamento = new TipoLancamento()
                                {
                                    Id = Convert.ToInt32(dr["TIPO_LANCAMENTO_ID"]),
                                    Nome = Convert.ToString(dr["TIPO_LANCAMENTO_NOME"]),
                                    Multiplicador = Convert.ToInt32(dr["TIPO_LANCAMENTO_MULTIPLICADOR"])
                                }
                            };
                        }
                    }
                    return categoria;
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

        public void Update(CategoriaEntity categoria)
        {
            try
            {
                OpenConnection();
                using (cmd = new SqlCommand("", con))
                {
                    cmd.CommandText = "cap.UP_CATEGORIA_ATUALIZAR";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@ID", SqlDbType.Int)).Value = categoria.Id;
                    cmd.Parameters.Add(new SqlParameter("@NOME", SqlDbType.VarChar, 100)).Value = categoria.Nome;
                    cmd.Parameters.Add(new SqlParameter("@TIPO_LANCAMENTO_ID", SqlDbType.Int)).Value = categoria.TipoLancamento.Id;
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
                    cmd.CommandText = "cap.UP_CATEGORIA_DELETE";
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

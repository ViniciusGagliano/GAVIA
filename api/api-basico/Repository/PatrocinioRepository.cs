using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DBConnectionControl;
using Entity;

namespace Repository
{
    public class PatrocinioRepository : Connection
    {
        public void Insert(PatrocinioEntity patrocinio)
        {
            try
            {
                OpenConnection();
                using (var cmd = new SqlCommand("", con))
                {
                    cmd.CommandText = "UP_PATROCINIO_CADASTRAR";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@SEGURADORA_ID", SqlDbType.Int)).Value = Convert.ToInt32(patrocinio.Seguradora.Id);
                    cmd.Parameters.Add(new SqlParameter("@REPRESENTANTE_ID", SqlDbType.Int)).Value = Convert.ToInt32(patrocinio.Representante.Id);
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

        public List<PatrocinioEntity> GetAll()
        {
            try
            {
                OpenConnection();
                using (var cmd = new SqlCommand("", con))
                {
                    cmd.CommandText = "UP_PATROCINIO_BUSCAR";
                    cmd.CommandType = CommandType.StoredProcedure;
                    dr = cmd.ExecuteReader();
                    List<PatrocinioEntity> patrocinios = new List<PatrocinioEntity>();
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            patrocinios.Add(new PatrocinioEntity()
                            {
                                Id = Convert.ToInt32(dr["PATROCINIO_ID"]),
                                Seguradora = new SeguradoraEntity()
                                {
                                    Id = Convert.ToInt32(dr["SEGURADORA_ID"]),
                                    Nome = Convert.ToString(dr["SEGURADORA_NOME"]),
                                    CNPJ = Convert.ToString(dr["SEGURADORA_CNPJ"])
                                },
                                Representante = new RepresentanteEntity()
                                {
                                    Id = Convert.ToInt32(dr["REPRESENTANTE_ID"]),
                                    Nome = Convert.ToString(dr["REPRESENTANTE_NOME"]),
                                    CNPJ = Convert.ToString(dr["REPRESENTANTE_CNPJ"])
                                }
                            });
                        }
                    }
                    return patrocinios;
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

        public PatrocinioEntity GetById(int id)
        {
            try
            {
                OpenConnection();
                using (var cmd = new SqlCommand("", con))
                {
                    cmd.CommandText = "UP_PATROCINIO_BUSCAR";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@ID", SqlDbType.Int)).Value = Convert.ToInt32(id);
                    dr = cmd.ExecuteReader();
                    PatrocinioEntity patrocinio = null;
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            patrocinio = new PatrocinioEntity()
                            {
                                Id = Convert.ToInt32(dr["PATROCINIO_ID"]),
                                Seguradora = new SeguradoraEntity()
                                {
                                    Id = Convert.ToInt32(dr["SEGURADORA_ID"]),
                                    Nome = Convert.ToString(dr["SEGURADORA_NOME"]),
                                    CNPJ = Convert.ToString(dr["SEGURADORA_CNPJ"])
                                },
                                Representante = new RepresentanteEntity()
                                {
                                    Id = Convert.ToInt32(dr["REPRESENTANTE_ID"]),
                                    Nome = Convert.ToString(dr["REPRESENTANTE_NOME"]),
                                    CNPJ = Convert.ToString(dr["REPRESENTANTE_CNPJ"])
                                }
                            };
                        }
                    }
                    return patrocinio;
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

        public void Update(PatrocinioEntity patrocinio)
        {
            try
            {
                OpenConnection();
                using (var cmd = new SqlCommand("", con))
                {
                    cmd.CommandText = "UP_PATROCINIO_ATUALIZAR";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@ID", SqlDbType.Int)).Value = Convert.ToInt32(patrocinio.Id);
                    cmd.Parameters.Add(new SqlParameter("@SEGURADORA_ID", SqlDbType.Int)).Value = Convert.ToInt32(patrocinio.Seguradora.Id);
                    cmd.Parameters.Add(new SqlParameter("@REPRESENTANTE_ID", SqlDbType.Int)).Value = Convert.ToInt32(patrocinio.Representante.Id);
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
                    cmd.CommandText = "UP_PATROCINIO_DELETAR";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@ID", SqlDbType.Int)).Value = Convert.ToInt32(id);
                    cmd.BeginExecuteNonQuery();
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

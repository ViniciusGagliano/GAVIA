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
    public class TipoSinistroRepository : Connection
    {
        public void Insert(TipoSinistroEntity tipoSinistro)
        {
			try
			{
				OpenConnection();
				using (cmd = new SqlCommand("", con))
				{
					cmd.CommandText = "UP_TIPO_SINISTRO_CADASTRAR";
					cmd.CommandType = CommandType.StoredProcedure;
					cmd.Parameters.Add(new SqlParameter("@NOME", SqlDbType.VarChar, 100)).Value = tipoSinistro.Nome;
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

		public List<TipoSinistroEntity> GetAll()
		{
			try
			{
				OpenConnection();
				using (cmd = new SqlCommand("", con))
				{
					cmd.CommandText = "UP_TIPO_SINISTRO_BUSCAR";
					cmd.CommandType = CommandType.StoredProcedure;
					dr = cmd.ExecuteReader();
					List<TipoSinistroEntity> tiposSinistros = new List<TipoSinistroEntity>();
					if (dr.HasRows)
					{
						while (dr.Read())
						{
							tiposSinistros.Add(new TipoSinistroEntity()
							{
								Id = Convert.ToInt32(dr["ID"]),
								Nome = dr["NOME"].ToString(),
								Ativo = Convert.ToBoolean(dr["ATIVO"])
							});
						}
					}
					return tiposSinistros;
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

		public TipoSinistroEntity GetById(int id)
		{
			try
			{
				OpenConnection();
				using (cmd = new SqlCommand("", con))
				{
					cmd.CommandText = "UP_TIPO_SINISTRO_BUSCAR";
					cmd.CommandType = CommandType.StoredProcedure;
					cmd.Parameters.Add(new SqlParameter("@ID", SqlDbType.Int)).Value = id;
					dr = cmd.ExecuteReader();
					TipoSinistroEntity tipoSinistro = null;
					if (dr.HasRows)
					{
						while (dr.Read())
						{
							tipoSinistro = new TipoSinistroEntity()
							{
								Id = Convert.ToInt32(dr["ID"]),
								Nome = dr["NOME"].ToString(),
								Ativo = Convert.ToBoolean(dr["ATIVO"])
							};
						}
					}
					return tipoSinistro;
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

		public void Update(TipoSinistroEntity tipoSinistro)
		{
			try
			{
				OpenConnection();
				using (cmd = new SqlCommand("", con))
				{
					cmd.CommandText = "UP_TIPO_SINISTRO_ATUALIZAR";
					cmd.CommandType = CommandType.StoredProcedure;
					cmd.Parameters.Add(new SqlParameter("@ID", SqlDbType.Int)).Value = tipoSinistro.Id;
					cmd.Parameters.Add(new SqlParameter("@NOME", SqlDbType.VarChar, 100)).Value = tipoSinistro.Nome;
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
					cmd.CommandText = "UP_TIPO_SINISTRO_DELETAR";
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

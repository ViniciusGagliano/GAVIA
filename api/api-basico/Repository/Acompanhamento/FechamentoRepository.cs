using DBConnectionControl;
using Entity.Acompanhamento;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Acompanhamento
{
    public class FechamentoRepository : Connection
    {
        public void Insert(FechamentoEntity fechamento)
        {
			try
			{
				OpenConnection();
				using (cmd = new SqlCommand("", con))
				{
					cmd.CommandText = "UP_FECHAMENTO_CADASTRAR";
					cmd.CommandType = CommandType.StoredProcedure;
					cmd.Parameters.Add(new SqlParameter("@DATA_FECHAMENTO", SqlDbType.Int)).Value = fechamento.DataFechamento;
					cmd.Parameters.Add(new SqlParameter("@REMESSA", SqlDbType.Int)).Value = fechamento.Remessa;
					cmd.Parameters.Add(new SqlParameter("@DOLAR_REMESSA", SqlDbType.Int)).Value = fechamento.DolarRemessa;
					cmd.Parameters.Add(new SqlParameter("@EMISSOR_ID", SqlDbType.Int)).Value = fechamento.Emissor.Id;
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

		public List<FechamentoEntity> GetAll()
		{
			try
			{
				OpenConnection();
				using (cmd = new SqlCommand("", con))
				{
					cmd.CommandText = "UP_FECHAMENTO_BUSCAR";
					cmd.CommandType = CommandType.StoredProcedure;
					dr = cmd.ExecuteReader();
					List<FechamentoEntity> fechamentos = new List<FechamentoEntity>();
					if (dr.HasRows)
					{
						while (dr.Read())
						{
							fechamentos.Add(new FechamentoEntity()
							{
								Id = Convert.ToInt32(dr["ID"]),
								DataFechamento = Convert.ToDateTime(dr["DATA_FECHAMENTO"]),
								Remessa = Convert.ToBoolean(dr["REMESSA"]),
								DolarRemessa = Convert.ToDecimal(dr["DOLAR_REMESSA"]),
								Emissor = new Entity.EmissorEntity() { Id = Convert.ToInt32(dr["ID"]) }
							});
						}
					}
					return fechamentos;
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

		public FechamentoEntity GetById(int id)
		{
			try
			{
				OpenConnection();
				using (cmd = new SqlCommand("", con))
				{
					cmd.CommandText = "UP_FECHAMENTO_BUSCAR";
					cmd.CommandType = CommandType.StoredProcedure;
					cmd.Parameters.Add(new SqlParameter("@ID", SqlDbType.Int)).Value = id;
					dr = cmd.ExecuteReader();
					FechamentoEntity fechamento = null;
					if (dr.HasRows)
					{
						while (dr.Read())
						{
							fechamento = new FechamentoEntity()
							{
								Id = Convert.ToInt32(dr["ID"]),
								DataFechamento = Convert.ToDateTime(dr["DATA_FECHAMENTO"]),
								Remessa = Convert.ToBoolean(dr["REMESSA"]),
								DolarRemessa = Convert.ToDecimal(dr["DOLAR_REMESSA"]),
								Emissor = new Entity.EmissorEntity() { Id = Convert.ToInt32(dr["ID"]) }
							};
						}
					}
					return fechamento;
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

		public void Update(FechamentoEntity fechamento)
		{
			try
			{
				OpenConnection();
				using (cmd = new SqlCommand("", con))
				{
					cmd.CommandText = "UP_FECHAMENTO_ATUALIZAR";
					cmd.CommandType = CommandType.StoredProcedure;
					cmd.Parameters.Add(new SqlParameter("@ID", SqlDbType.Int)).Value = fechamento.Id;
					cmd.Parameters.Add(new SqlParameter("@DATA_FECHAMENTO", SqlDbType.Int)).Value = fechamento.DataFechamento;
					cmd.Parameters.Add(new SqlParameter("@REMESSA", SqlDbType.Int)).Value = fechamento.Remessa;
					cmd.Parameters.Add(new SqlParameter("@DOLAR_REMESSA", SqlDbType.Int)).Value = fechamento.DolarRemessa;
					cmd.Parameters.Add(new SqlParameter("@EMISSOR_ID", SqlDbType.Int)).Value = fechamento.Emissor.Id;
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
					cmd.CommandText = "UP_FECHAMENTO_DELETAR";
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

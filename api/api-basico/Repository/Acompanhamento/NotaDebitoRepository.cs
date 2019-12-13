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
    public class NotaDebitoRepository : Connection
    {
        public void Insert(NotaDebitoEntity notaDebito)
        {
			try
			{
				OpenConnection();
				using (cmd = new SqlCommand("", con))
				{
					cmd.CommandText = "UP_NOTA_DEBITO_CADASTRAR";
					cmd.CommandType = CommandType.StoredProcedure;
					cmd.Parameters.Add(new SqlParameter("@NOME", SqlDbType.VarChar, 20)).Value = notaDebito.Nome;
					cmd.Parameters.Add(new SqlParameter("@DATA_EMISSAO", SqlDbType.SmallDateTime)).Value = notaDebito.DataEmissao;
					cmd.Parameters.Add(new SqlParameter("@DATA_ENVIO", SqlDbType.SmallDateTime)).Value = notaDebito.DataEnvio;
					cmd.Parameters.Add(new SqlParameter("@PREVISAO_PAGAMENTO", SqlDbType.SmallDateTime)).Value = notaDebito.PrevisaoPagamento;
					cmd.Parameters.Add(new SqlParameter("@DATA_PAGAMENTO", SqlDbType.SmallDateTime)).Value = notaDebito.DataPagamento;
					cmd.Parameters.Add(new SqlParameter("@DATA_EMAIL", SqlDbType.SmallDateTime)).Value = notaDebito.DataEmail;
					cmd.Parameters.Add(new SqlParameter("@DATA_REPASSE_REMESSA", SqlDbType.SmallDateTime)).Value = notaDebito.DataRepasseRemessa;
					cmd.Parameters.Add(new SqlParameter("@DOLAR_BANCO_CENTRAL", SqlDbType.Money)).Value = notaDebito.DolarBancoCentral;
					cmd.Parameters.Add(new SqlParameter("@OBSERVACAO", SqlDbType.VarChar)).Value = notaDebito.Observacao;
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

		public List<NotaDebitoEntity> GetAll()
		{
			try
			{
				OpenConnection();
				using (cmd = new SqlCommand("", con))
				{
					cmd.CommandText = "UP_NOTA_DEBITO_BUSCAR";
					cmd.CommandType = CommandType.StoredProcedure;
					dr = cmd.ExecuteReader();
					List<NotaDebitoEntity> notasDebitos = new List<NotaDebitoEntity>();
					if (dr.HasRows)
					{
						while (dr.Read())
						{
							notasDebitos.Add(new NotaDebitoEntity()
							{
								Id = Convert.ToInt32(dr["ID"]),
								Nome = dr["NOME"].ToString(),
								Ativo = Convert.ToBoolean(dr["ATIVO"]),
								DataEmissao = Convert.ToDateTime(dr["DATA_EMISSAO"]),
								DataEnvio = Convert.ToDateTime(dr["DATA_ENVIO"]),
								PrevisaoPagamento = Convert.ToDateTime(dr["PREVISAO_PAGAMENTO"]),
								DataPagamento = Convert.ToDateTime(dr["DATA_PAGAMENTO"]),
								DataRepasseRemessa = Convert.ToDateTime(dr["DATA_REPASSE_REMESSA"]),
								DataEmail = Convert.ToDateTime(dr["DATA_EMAIL"]),
								DolarBancoCentral = Convert.ToDecimal(dr["DOLAR_BANCO_CENTRAL"]),
								Observacao = dr["OBSERVACAO"].ToString()
							});
						}
					}
					return notasDebitos;
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

		public NotaDebitoEntity GetById(int id)
		{
			try
			{
				OpenConnection();
				using (cmd = new SqlCommand("", con))
				{
					cmd.CommandText = "UP_NOTA_DEBITO_BUSCAR";
					cmd.CommandType = CommandType.StoredProcedure;
					cmd.Parameters.Add(new SqlParameter("@ID", SqlDbType.Int)).Value = id;
					dr = cmd.ExecuteReader();
					NotaDebitoEntity notaDebito = null;
					if (dr.HasRows)
					{
						while (dr.Read())
						{
							notaDebito = new NotaDebitoEntity()
							{
								Id = Convert.ToInt32(dr["ID"]),
								Nome = dr["NOME"].ToString(),
								Ativo = Convert.ToBoolean(dr["ATIVO"]),
								DataEmissao = Convert.ToDateTime(dr["DATA_EMISSAO"]),
								DataEnvio = Convert.ToDateTime(dr["DATA_ENVIO"]),
								PrevisaoPagamento = Convert.ToDateTime(dr["PREVISAO_PAGAMENTO"]),
								DataPagamento = Convert.ToDateTime(dr["DATA_PAGAMENTO"]),
								DataRepasseRemessa = Convert.ToDateTime(dr["DATA_REPASSE_REMESSA"]),
								DataEmail = Convert.ToDateTime(dr["DATA_EMAIL"]),
								DolarBancoCentral = Convert.ToDecimal(dr["DOLAR_BANCO_CENTRAL"]),
								Observacao = dr["OBSERVACAO"].ToString()
							};
						}
					}
					return notaDebito;
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

		public void Update(NotaDebitoEntity notaDebito)
		{
			try
			{
				OpenConnection();
				using (cmd = new SqlCommand("", con))
				{
					cmd.CommandText = "UP_NOTA_DEBITO_ATUALIZAR";
					cmd.CommandType = CommandType.StoredProcedure;
					cmd.Parameters.Add(new SqlParameter("@ID", SqlDbType.Int)).Value = notaDebito.Id;
					cmd.Parameters.Add(new SqlParameter("@NOME", SqlDbType.VarChar, 20)).Value = notaDebito.Nome;
					cmd.Parameters.Add(new SqlParameter("@DATA_EMISSAO", SqlDbType.SmallDateTime)).Value = notaDebito.DataEmissao;
					cmd.Parameters.Add(new SqlParameter("@DATA_ENVIO", SqlDbType.SmallDateTime)).Value = notaDebito.DataEnvio;
					cmd.Parameters.Add(new SqlParameter("@PREVISAO_PAGAMENTO", SqlDbType.SmallDateTime)).Value = notaDebito.PrevisaoPagamento;
					cmd.Parameters.Add(new SqlParameter("@DATA_PAGAMENTO", SqlDbType.SmallDateTime)).Value = notaDebito.DataPagamento;
					cmd.Parameters.Add(new SqlParameter("@DATA_EMAIL", SqlDbType.SmallDateTime)).Value = notaDebito.DataEmail;
					cmd.Parameters.Add(new SqlParameter("@DATA_REPASSE_REMESSA", SqlDbType.SmallDateTime)).Value = notaDebito.DataRepasseRemessa;
					cmd.Parameters.Add(new SqlParameter("@DOLAR_BANCO_CENTRAL", SqlDbType.Money)).Value = notaDebito.DolarBancoCentral;
					cmd.Parameters.Add(new SqlParameter("@OBSERVACAO", SqlDbType.VarChar)).Value = notaDebito.Observacao;
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
					cmd.CommandText = "UP_NOTA_DEBITO_DELETE";
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

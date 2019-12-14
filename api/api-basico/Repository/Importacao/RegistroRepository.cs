using DBConnectionControl;
using Entity.Importacao;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace Repository.Importacao
{
    public class RegistroRepository : Connection
    {
        public void Insert(RegistroEntity registro)
        {
			try
			{
				OpenConnection();
				using (cmd = new SqlCommand("", con))
				{
					cmd.CommandText = "imp.UP_REGISTRO_CADASTRAR";
					cmd.CommandType = CommandType.StoredProcedure;
					cmd.Parameters.Add(new SqlParameter("@IMPORTACAO_ID", SqlDbType.Int)).Value = registro.Importacao.Id;
					cmd.Parameters.Add(new SqlParameter("@NUMERO_SINISTRO", SqlDbType.VarChar)).Value = registro.NumeroSinistro;
					cmd.Parameters.Add(new SqlParameter("@COMPANHIA", SqlDbType.VarChar)).Value = registro.Companhia;
					cmd.Parameters.Add(new SqlParameter("@PROCESSO", SqlDbType.VarChar)).Value = registro.Processo;
					cmd.Parameters.Add(new SqlParameter("@BILHETE", SqlDbType.VarChar)).Value = registro.Bilhete;
					cmd.Parameters.Add(new SqlParameter("@DATA_EMISSAO_VOUCHER", SqlDbType.SmallDateTime)).Value = registro.DataEmissaoVoucher;
					cmd.Parameters.Add(new SqlParameter("@REFERENCIA", SqlDbType.VarChar)).Value = registro.Referencia;
					cmd.Parameters.Add(new SqlParameter("@DATA_ATENDIMENTO", SqlDbType.SmallDateTime)).Value = registro.DataAtendimento;
					cmd.Parameters.Add(new SqlParameter("@DATA_OCORRENCIA", SqlDbType.SmallDateTime)).Value = registro.DataOcorrencia;
					cmd.Parameters.Add(new SqlParameter("@NOME", SqlDbType.VarChar)).Value = registro.Nome;
					cmd.Parameters.Add(new SqlParameter("@NUMERO_DOCUMENTO", SqlDbType.VarChar)).Value = registro.NumeroDocumento;
					cmd.Parameters.Add(new SqlParameter("@VOUCHER", SqlDbType.VarChar)).Value = registro.Voucher;
					cmd.Parameters.Add(new SqlParameter("@COBERTURA", SqlDbType.VarChar)).Value = registro.Cobertura;
					cmd.Parameters.Add(new SqlParameter("@CUSTO_ORIGINAL", SqlDbType.Money)).Value = registro.CustoOriginal;
					cmd.Parameters.Add(new SqlParameter("@TIPO_MOEDA", SqlDbType.VarChar)).Value = registro.TipoMoeda;
					cmd.Parameters.Add(new SqlParameter("@VALOR_FINAL", SqlDbType.Money)).Value = registro.ValorFinal;
					cmd.Parameters.Add(new SqlParameter("@FEE", SqlDbType.Money)).Value = registro.Fee;
					cmd.Parameters.Add(new SqlParameter("@TIPO_MOEDA_FEE", SqlDbType.VarChar)).Value = registro.TipoMoedaFee;
					cmd.Parameters.Add(new SqlParameter("@VALOR_DOLAR", SqlDbType.Money)).Value = registro.ValorDolar;
					cmd.Parameters.Add(new SqlParameter("@VALOR_REAL", SqlDbType.Money)).Value = registro.ValorReal;
					cmd.Parameters.Add(new SqlParameter("@DOLAR", SqlDbType.Float)).Value = registro.Dolar;
					cmd.Parameters.Add(new SqlParameter("@SINISTRO_ID", SqlDbType.Int)).Value = registro.SinistroId;
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

		public List<RegistroEntity> GetAll()
		{
			try
			{
				OpenConnection();
				using (cmd = new SqlCommand("", con))
				{
					cmd.CommandText = "imp.UP_REGISTRO_BUSCAR";
					cmd.CommandType = CommandType.StoredProcedure;
					dr = cmd.ExecuteReader();
					List<RegistroEntity> registros = new List<RegistroEntity>();
					if (dr.HasRows)
					{
						while (dr.Read())
						{
							registros.Add(new RegistroEntity()
							{
								Id = Convert.ToInt32(dr["ID"]),
								Bilhete = dr["BILHETE"].ToString(),
								Cobertura = dr["COBERTURA"].ToString(),
								Companhia = dr[""].ToString(),
								CustoOriginal = Convert.ToDecimal(dr["CUSTO_ORIGINAL"]),
								DataAtendimento = Convert.ToDateTime(dr["DATA_ATENDIMENTO"]),
								DataEmissaoVoucher = Convert.ToDateTime(dr["DATA_EMISSAO_VOUCHER"]),
								DataOcorrencia = Convert.ToDateTime(dr["DATA_OCORRENCIA"]),
								Dolar = Convert.ToDouble(dr["DOLAR"]),
								Fee = Convert.ToDecimal(dr["FEE"]),
								ValorReal = Convert.ToDecimal(dr["VALOR_REAL"]),
								ValorDolar = Convert.ToDecimal(dr["VALOR_DOLAR"]),
								ValorFinal = Convert.ToDecimal(dr["VALOR_FINAL"]),
								Nome = dr["NOME"].ToString(),
								NumeroDocumento = dr["NUMERO_DOCUMENTO"].ToString(),
								NumeroSinistro = dr["NUMERO_SINISTRO"].ToString(),
								Processo = dr["PROCESSO"].ToString(),
								Referencia = dr["REFERENCIA"].ToString(),
								TipoMoeda = dr["TIPO_MOEDA"].ToString(),
								TipoMoedaFee = dr["TIPO_MOEDA_FEE"].ToString(),
								Voucher = dr["VOUCHER"].ToString(),
								SinistroId = Convert.ToInt32(dr["SINISTRO_ID"]),
								Importacao = new ImportacaoEntity() { Id = Convert.ToInt32(dr["IMPORTACAO_ID"]) }
							});
						}
					}
					return registros;
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

		public RegistroEntity GetById(int id)
		{
			try
			{
				OpenConnection();
				using (cmd = new SqlCommand("", con))
				{
					cmd.CommandText = "imp.UP_REGISTRO_BUSCAR";
					cmd.CommandType = CommandType.StoredProcedure;
					cmd.Parameters.Add(new SqlParameter("@ID", SqlDbType.Int)).Value = id;
					dr = cmd.ExecuteReader();
					RegistroEntity registro = null;
					if (dr.HasRows)
					{
						while (dr.Read())
						{
							registro = new RegistroEntity()
							{
								Id = Convert.ToInt32(dr["ID"]),
								Bilhete = dr["BILHETE"].ToString(),
								Cobertura = dr["COBERTURA"].ToString(),
								Companhia = dr[""].ToString(),
								CustoOriginal = Convert.ToDecimal(dr["CUSTO_ORIGINAL"]),
								DataAtendimento = Convert.ToDateTime(dr["DATA_ATENDIMENTO"]),
								DataEmissaoVoucher = Convert.ToDateTime(dr["DATA_EMISSAO_VOUCHER"]),
								DataOcorrencia = Convert.ToDateTime(dr["DATA_OCORRENCIA"]),
								Dolar = Convert.ToDouble(dr["DOLAR"]),
								Fee = Convert.ToDecimal(dr["FEE"]),
								ValorReal = Convert.ToDecimal(dr["VALOR_REAL"]),
								ValorDolar = Convert.ToDecimal(dr["VALOR_DOLAR"]),
								ValorFinal = Convert.ToDecimal(dr["VALOR_FINAL"]),
								Nome = dr["NOME"].ToString(),
								NumeroDocumento = dr["NUMERO_DOCUMENTO"].ToString(),
								NumeroSinistro = dr["NUMERO_SINISTRO"].ToString(),
								Processo = dr["PROCESSO"].ToString(),
								Referencia = dr["REFERENCIA"].ToString(),
								TipoMoeda = dr["TIPO_MOEDA"].ToString(),
								TipoMoedaFee = dr["TIPO_MOEDA_FEE"].ToString(),
								Voucher = dr["VOUCHER"].ToString(),
								SinistroId = Convert.ToInt32(dr["SINISTRO_ID"]),
								Importacao = new ImportacaoEntity() { Id = Convert.ToInt32(dr["IMPORTACAO_ID"]) }
							};
						}
					}
					return registro;
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

		public void Update(RegistroEntity registro)
		{
			try
			{
				OpenConnection();
				using (cmd = new SqlCommand("", con))
				{
					cmd.CommandText = "imp.UP_REGISTRO_ATUALIZAR";
					cmd.CommandType = CommandType.StoredProcedure;
					cmd.Parameters.Add(new SqlParameter("@ID", SqlDbType.Int)).Value = registro.Id;
					cmd.Parameters.Add(new SqlParameter("@IMPORTACAO_ID", SqlDbType.Int)).Value = registro.Importacao.Id;
					cmd.Parameters.Add(new SqlParameter("@NUMERO_SINISTRO", SqlDbType.VarChar)).Value = registro.NumeroSinistro;
					cmd.Parameters.Add(new SqlParameter("@COMPANHIA", SqlDbType.VarChar)).Value = registro.Companhia;
					cmd.Parameters.Add(new SqlParameter("@PROCESSO", SqlDbType.VarChar)).Value = registro.Processo;
					cmd.Parameters.Add(new SqlParameter("@BILHETE", SqlDbType.VarChar)).Value = registro.Bilhete;
					cmd.Parameters.Add(new SqlParameter("@DATA_EMISSAO_VOUCHER", SqlDbType.SmallDateTime)).Value = registro.DataEmissaoVoucher;
					cmd.Parameters.Add(new SqlParameter("@REFERENCIA", SqlDbType.VarChar)).Value = registro.Referencia;
					cmd.Parameters.Add(new SqlParameter("@DATA_ATENDIMENTO", SqlDbType.SmallDateTime)).Value = registro.DataAtendimento;
					cmd.Parameters.Add(new SqlParameter("@DATA_OCORRENCIA", SqlDbType.SmallDateTime)).Value = registro.DataOcorrencia;
					cmd.Parameters.Add(new SqlParameter("@NOME", SqlDbType.VarChar)).Value = registro.Nome;
					cmd.Parameters.Add(new SqlParameter("@NUMERO_DOCUMENTO", SqlDbType.VarChar)).Value = registro.NumeroDocumento;
					cmd.Parameters.Add(new SqlParameter("@VOUCHER", SqlDbType.VarChar)).Value = registro.Voucher;
					cmd.Parameters.Add(new SqlParameter("@COBERTURA", SqlDbType.VarChar)).Value = registro.Cobertura;
					cmd.Parameters.Add(new SqlParameter("@CUSTO_ORIGINAL", SqlDbType.Money)).Value = registro.CustoOriginal;
					cmd.Parameters.Add(new SqlParameter("@TIPO_MOEDA", SqlDbType.VarChar)).Value = registro.TipoMoeda;
					cmd.Parameters.Add(new SqlParameter("@VALOR_FINAL", SqlDbType.Money)).Value = registro.ValorFinal;
					cmd.Parameters.Add(new SqlParameter("@FEE", SqlDbType.Money)).Value = registro.Fee;
					cmd.Parameters.Add(new SqlParameter("@TIPO_MOEDA_FEE", SqlDbType.VarChar)).Value = registro.TipoMoedaFee;
					cmd.Parameters.Add(new SqlParameter("@VALOR_DOLAR", SqlDbType.Money)).Value = registro.ValorDolar;
					cmd.Parameters.Add(new SqlParameter("@VALOR_REAL", SqlDbType.Money)).Value = registro.ValorReal;
					cmd.Parameters.Add(new SqlParameter("@DOLAR", SqlDbType.Float)).Value = registro.Dolar;
					cmd.Parameters.Add(new SqlParameter("@SINISTRO_ID", SqlDbType.Int)).Value = registro.SinistroId;
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
					cmd.CommandText = "imp.UP_REGISTRO_DELETE";
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

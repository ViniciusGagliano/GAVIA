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
    public class SinistroRepository : Connection
    {
        public void Insert(SinistroEntity sinistro)
        {
			try
			{
				OpenConnection();
				using (cmd = new SqlCommand("", con))
				{
					cmd.CommandText = "UP_SINISTRO_CADASTRAR";
					cmd.CommandType = CommandType.StoredProcedure;
					cmd.Parameters.Add(new SqlParameter("@NUMERO_SINISTRO", SqlDbType.VarChar)).Value = sinistro.NumeroSinistro;
					cmd.Parameters.Add(new SqlParameter("@PROCESSO", SqlDbType.VarChar)).Value = sinistro.Processo;
					cmd.Parameters.Add(new SqlParameter("@BILHETE", SqlDbType.VarChar)).Value = sinistro.Bilhete;
					cmd.Parameters.Add(new SqlParameter("@DATA_ATENDIMENTO", SqlDbType.SmallDateTime)).Value = sinistro.DataAtendimento;
					cmd.Parameters.Add(new SqlParameter("@DATA_OCORRENCIA", SqlDbType.SmallDateTime)).Value = sinistro.DataOcorrencia;
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

		public List<SinistroEntity> GetAllImportacao(int id)
		{
			try
			{
				OpenConnection();
				using (cmd = new SqlCommand("", con))
				{
					cmd.CommandText = "UP_SINISTRO_BUSCAR";
					cmd.CommandType = CommandType.StoredProcedure;
					cmd.Parameters.Add(new SqlParameter("@IMPORTACAO_ID", SqlDbType.Int)).Value = id;
					dr = cmd.ExecuteReader();
					List<SinistroEntity> sinistros = new List<SinistroEntity>();
					if (dr.HasRows)
					{
						while (dr.Read())
						{
							sinistros.Add(new SinistroEntity()
							{
								Id = Convert.ToInt32(dr["ID"]),
								NumeroSinistro = dr["NUMERO_SINISTRO"].ToString(),
								Referencia = dr["REFERENCIA"].ToString(),
								NotaDebito = new Entity.NotaDebitoEntity() { Nome = dr["ND"].ToString() },
								Segurado = new Entity.SeguradoEntity() { Nome = dr["SEGURADO"].ToString() },
								Seguradora = dr["SEGURADORA"].ToString(),
								Representante = dr["REPRESENTANTE"].ToString(),
								ValorReal = Convert.ToDecimal(dr["VALOR_REAL"])
							});
						}
					}
					return sinistros;
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

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
    public class ImportacaoRepository : Connection
    {
        public void Insert(ImportacaoEntity importacao)
        {
			try
			{
				OpenConnection();
				using (cmd = new SqlCommand("", con))
				{
					cmd.CommandText = "imp.UP_IMPORTACAO_CADASTRAR";
					cmd.CommandType = CommandType.StoredProcedure;
					cmd.Parameters.Add(new SqlParameter("@NOME_ARQUIVO", SqlDbType.VarChar, 300)).Value = importacao.NomeArquivo;
					cmd.Parameters.Add(new SqlParameter("@CAMINHO_ARQUIVO", SqlDbType.VarChar)).Value = importacao.CaminhoArquivo;
					cmd.Parameters.Add(new SqlParameter("@ANTECIPACAO", SqlDbType.Bit)).Value = importacao.Antecipacao;
					cmd.Parameters.Add(new SqlParameter("@SEGURADORA_ID", SqlDbType.Int)).Value = importacao.Seguradora.Id;
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

		public List<ImportacaoEntity> GetAll()
		{
			try
			{
				OpenConnection();
				using (cmd = new SqlCommand("", con))
				{
					cmd.CommandText = "imp.UP_IMPORTACAO_BUSCAR";
					cmd.CommandType = CommandType.StoredProcedure;
					dr = cmd.ExecuteReader();
					List<ImportacaoEntity> importacaos = new List<ImportacaoEntity>();
					if (dr.HasRows)
					{
						while (dr.Read())
						{
							importacaos.Add(new ImportacaoEntity()
							{
								Id = Convert.ToInt32(dr["ID"]),
								NomeArquivo = dr["NOME_ARQUIVO"].ToString(),
								CaminhoArquivo = dr["CAMINHO_ARQUIVO"].ToString(),
								Antecipacao = Convert.ToBoolean(dr["ANTECIPACAO"]),
								Ativo = Convert.ToBoolean(dr["ATIVO"]),
								Seguradora = new SeguradoraEntity()
								{
									Id = Convert.ToInt32(dr["SEGURADORA_ID"]),
									Nome = dr["SEGURADORA_NOME"].ToString(),
									CNPJ = dr["SEGURADORA_CNPJ"].ToString()
								},
								DataImportacaoFormatada = dr["DATA_IMPORTACAO_FORMATADA"].ToString(),
								Processada = Convert.ToBoolean(dr["BIT_PROCESSADA"])
							});
						}
					}
					return importacaos;
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

		public ImportacaoEntity GetById(int id)
		{
			try
			{
				OpenConnection();
				using (cmd = new SqlCommand("", con))
				{
					cmd.CommandText = "imp.UP_IMPORTACAO_BUSCAR";
					cmd.CommandType = CommandType.StoredProcedure;
					cmd.Parameters.Add(new SqlParameter("@ID", SqlDbType.Int)).Value = id;
					dr = cmd.ExecuteReader();
					ImportacaoEntity importacao = null;
					if (dr.HasRows)
					{
						while (dr.Read())
						{
							importacao = new ImportacaoEntity()
							{
								Id = Convert.ToInt32(dr["ID"]),
								NomeArquivo = dr["NOME_ARQUIVO"].ToString(),
								CaminhoArquivo = dr["CAMINHO_ARQUIVO"].ToString(),
								Antecipacao = Convert.ToBoolean(dr["ANTECIPACAO"]),
								Ativo = Convert.ToBoolean(dr["ATIVO"]),
								Seguradora = new SeguradoraEntity()
								{
									Id = Convert.ToInt32(dr["SEGURADORA_ID"]),
									Nome = dr["SEGURADORA_NOME"].ToString(),
									CNPJ = dr["SEGURADORA_CNPJ"].ToString()
								},
								DataImportacaoFormatada = dr["DATA_IMPORTACAO_FORMATADA"].ToString(),
								Processada = Convert.ToBoolean(dr["BIT_PROCESSADA"])
							};
						}
					}
					return importacao;
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

		public void Update(ImportacaoEntity importacao)
		{
			try
			{
				OpenConnection();
				using (cmd = new SqlCommand("", con))
				{
					cmd.CommandText = "imp.UP_IMPORTACAO_ATUALIZAR";
					cmd.CommandType = CommandType.StoredProcedure;
					cmd.Parameters.Add(new SqlParameter("@ID", SqlDbType.Int)).Value = importacao.Id;
					cmd.Parameters.Add(new SqlParameter("@NOME_ARQUIVO", SqlDbType.VarChar, 300)).Value = importacao.NomeArquivo;
					cmd.Parameters.Add(new SqlParameter("@CAMINHO_ARQUIVO", SqlDbType.VarChar)).Value = importacao.CaminhoArquivo;
					cmd.Parameters.Add(new SqlParameter("@ANTECIPACAO", SqlDbType.Bit)).Value = importacao.Antecipacao;
					cmd.Parameters.Add(new SqlParameter("@PROCESSAR", SqlDbType.Bit)).Value = importacao.Processada;
					cmd.Parameters.Add(new SqlParameter("@SEGURADORA_ID", SqlDbType.Int)).Value = importacao.Seguradora.Id;
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
					cmd.CommandText = "imp.UP_IMPORTACAO_DELETAR";
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

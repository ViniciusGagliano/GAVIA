using DBConnectionControl;
using Entity;
using Entity.Financeiro;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Financeiro
{
    public class LancamentoRepository : Connection
    {
        public void Insert(LancamentoEntity lancamento)
        {
			try
			{
				OpenConnection();
				using (cmd = new SqlCommand("", con))
				{
					cmd.CommandText = "fin.UP_LANCAMENTO_CADASTRAR";
					cmd.CommandType = CommandType.StoredProcedure;
					cmd.Parameters.Add(new SqlParameter("@DESCRICAO", SqlDbType.VarChar)).Value = lancamento.Descricao;
					cmd.Parameters.Add(new SqlParameter("@CUSTO_FIXO", SqlDbType.Bit)).Value = lancamento.CustoFixo;
					cmd.Parameters.Add(new SqlParameter("@VALOR", SqlDbType.Money)).Value = lancamento.Valor;
					cmd.Parameters.Add(new SqlParameter("@DATA_LANCAMENTO", SqlDbType.SmallDateTime)).Value = lancamento.DataLancamento;
					cmd.Parameters.Add(new SqlParameter("@FECHAMENTO_ID", SqlDbType.Int)).Value = lancamento.Fechamento.Id;
					cmd.Parameters.Add(new SqlParameter("@CLIENTE_ID", SqlDbType.Int)).Value = lancamento.Cliente.Id;
					cmd.Parameters.Add(new SqlParameter("@CONTA_BANCARIA_ID", SqlDbType.Int)).Value = lancamento.ContaBancaria.Id;
					cmd.Parameters.Add(new SqlParameter("@CENTRO_CUSTO_ID", SqlDbType.Int)).Value = lancamento.CentroCusto.Id;
					cmd.Parameters.Add(new SqlParameter("@CATEGORIA_ID", SqlDbType.Int)).Value = lancamento.Categoria.Id;
					cmd.Parameters.Add(new SqlParameter("@FORNECEDOR_ID", SqlDbType.Int)).Value = lancamento.Fornecedor.Id;
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

		public List<LancamentoEntity> GetAll()
		{
			try
			{
				OpenConnection();
				using (cmd = new SqlCommand("", con))
				{
					cmd.CommandText = "fin.UP_LANCAMENTO_BUSCAR";
					cmd.CommandType = CommandType.StoredProcedure;
					dr = cmd.ExecuteReader();
					List<LancamentoEntity> lancamentos = new List<LancamentoEntity>();
					if (dr.HasRows)
					{
						while (dr.Read())
						{
							lancamentos.Add(new LancamentoEntity()
							{
								Id = Convert.ToInt32(dr["ID"]),
								Ativo = Convert.ToBoolean(dr["ATIVO"]),
								Descricao = dr["DESCRICAO"].ToString(),
								DataLancamento = Convert.ToDateTime(dr["DATA_LANCAMENTO"]),
								Valor = Convert.ToDecimal(dr["VALOR"]),
								CustoFixo = Convert.ToBoolean(dr["CUSTO_FIXO"]),
								Categoria = new CategoriaEntity() { Id = Convert.ToInt32(dr["CATEGORIA_ID"]) },
								CentroCusto = new CentroCustoEntity() { Id = Convert.ToInt32(dr["CENTRO_CUSTO_ID"]) },
								Cliente = new ClienteEntity() { Id = Convert.ToInt32(dr["CLIENTE_ID"]) },
								ContaBancaria = new ContaBancariaEntity() { Id = Convert.ToInt32(dr["CONTA_BANCARIA_ID"]) },
								Fechamento = new Entity.Acompanhamento.FechamentoEntity() { Id = Convert.ToInt32(dr["FECHAMENTO_ID"]) },
								Fornecedor = new FornecedorEntity() { Id = Convert.ToInt32(dr["FORNECEDOR_ID"]) }
							});
						}
					}
					return lancamentos;
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

		public LancamentoEntity GetById(int id)
		{
			try
			{
				OpenConnection();
				using (cmd = new SqlCommand("", con))
				{
					cmd.CommandText = "fin.UP_LANCAMENTO_BUSCAR";
					cmd.CommandType = CommandType.StoredProcedure;
					cmd.Parameters.Add(new SqlParameter("@ID", SqlDbType.Int)).Value = id;
					dr = cmd.ExecuteReader();
					LancamentoEntity lancamento = null;
					if (dr.HasRows)
					{
						while (dr.Read())
						{
							lancamento = new LancamentoEntity()
							{
								Id = Convert.ToInt32(dr["ID"]),
								Ativo = Convert.ToBoolean(dr["ATIVO"]),
								Descricao = dr["DESCRICAO"].ToString(),
								DataLancamento = Convert.ToDateTime(dr["DATA_LANCAMENTO"]),
								Valor = Convert.ToDecimal(dr["VALOR"]),
								CustoFixo = Convert.ToBoolean(dr["CUSTO_FIXO"]),
								Categoria = new CategoriaEntity() { Id = Convert.ToInt32(dr["CATEGORIA_ID"]) },
								CentroCusto = new CentroCustoEntity() { Id = Convert.ToInt32(dr["CENTRO_CUSTO_ID"]) },
								Cliente = new ClienteEntity() { Id = Convert.ToInt32(dr["CLIENTE_ID"]) },
								ContaBancaria = new ContaBancariaEntity() { Id = Convert.ToInt32(dr["CONTA_BANCARIA_ID"]) },
								Fechamento = new Entity.Acompanhamento.FechamentoEntity() { Id = Convert.ToInt32(dr["FECHAMENTO_ID"]) },
								Fornecedor = new FornecedorEntity() { Id = Convert.ToInt32(dr["FORNECEDOR_ID"]) }
							};
						}
					}
					return lancamento;
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

		public void Update(LancamentoEntity lancamento)
		{
			try
			{
				OpenConnection();
				using (cmd = new SqlCommand("", con))
				{
					cmd.CommandText = "fin.UP_LANCAMENTO_ATUALIZAR";
					cmd.CommandType = CommandType.StoredProcedure;
					cmd.Parameters.Add(new SqlParameter("@ID", SqlDbType.Int)).Value = lancamento.Id;
					cmd.Parameters.Add(new SqlParameter("@DESCRICAO", SqlDbType.VarChar)).Value = lancamento.Descricao;
					cmd.Parameters.Add(new SqlParameter("@CUSTO_FIXO", SqlDbType.Bit)).Value = lancamento.CustoFixo;
					cmd.Parameters.Add(new SqlParameter("@VALOR", SqlDbType.Money)).Value = lancamento.Valor;
					cmd.Parameters.Add(new SqlParameter("@DATA_LANCAMENTO", SqlDbType.SmallDateTime)).Value = lancamento.DataLancamento;
					cmd.Parameters.Add(new SqlParameter("@FECHAMENTO_ID", SqlDbType.Int)).Value = lancamento.Fechamento.Id;
					cmd.Parameters.Add(new SqlParameter("@CLIENTE_ID", SqlDbType.Int)).Value = lancamento.Cliente.Id;
					cmd.Parameters.Add(new SqlParameter("@CONTA_BANCARIA_ID", SqlDbType.Int)).Value = lancamento.ContaBancaria.Id;
					cmd.Parameters.Add(new SqlParameter("@CENTRO_CUSTO_ID", SqlDbType.Int)).Value = lancamento.CentroCusto.Id;
					cmd.Parameters.Add(new SqlParameter("@CATEGORIA_ID", SqlDbType.Int)).Value = lancamento.Categoria.Id;
					cmd.Parameters.Add(new SqlParameter("@FORNECEDOR_ID", SqlDbType.Int)).Value = lancamento.Fornecedor.Id;
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
					cmd.CommandText = "fin.UP_LANCAMENTO_DELETAR";
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

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
    public class SeguradoRepository : Connection
    {
        public void Insert(SeguradoEntity segurado)
        {
			try
			{
				OpenConnection();
				using (cmd = new SqlCommand("", con))
				{
					cmd.CommandText = "UP_SEGURADO_CADASTRAR";
					cmd.CommandType = CommandType.StoredProcedure;
					cmd.Parameters.Add(new SqlParameter("@NOME", SqlDbType.VarChar, 100)).Value = segurado.Nome;
					cmd.Parameters.Add(new SqlParameter("@CPF", SqlDbType.VarChar, 14)).Value = segurado.CPF;
					cmd.Parameters.Add(new SqlParameter("@BANCO", SqlDbType.VarChar, 100)).Value = segurado.Banco;
					cmd.Parameters.Add(new SqlParameter("@AGENCIA", SqlDbType.VarChar, 4)).Value = segurado.Agencia;
					cmd.Parameters.Add(new SqlParameter("@DIGITO_AGENCIA", SqlDbType.Char, 1)).Value = segurado.DigitoAgencia;
					cmd.Parameters.Add(new SqlParameter("@CONTA", SqlDbType.VarChar, 10)).Value = segurado.Conta;
					cmd.Parameters.Add(new SqlParameter("@DIGITO_CONTA", SqlDbType.Char, 1)).Value = segurado.DigitoConta;
					cmd.Parameters.Add(new SqlParameter("@BENEFICIARIO", SqlDbType.VarChar, 100)).Value = segurado.Beneficiario;
					cmd.Parameters.Add(new SqlParameter("@CPF_BENEFICIARIO", SqlDbType.VarChar, 14)).Value = segurado.CpfBeneficiario;
					cmd.Parameters.Add(new SqlParameter("@EMAIL", SqlDbType.VarChar, 100)).Value = segurado.Email;
					cmd.Parameters.Add(new SqlParameter("@CONTA_CADASTRADA", SqlDbType.Bit)).Value = segurado.ContaCadastrada;
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

		public List<SeguradoEntity> GetAll()
		{
			try
			{
				OpenConnection();
				using (cmd = new SqlCommand("", con))
				{
					cmd.CommandText = "UP_SEGURADO_BUSCAR";
					cmd.CommandType = CommandType.StoredProcedure;
					dr = cmd.ExecuteReader();
					List<SeguradoEntity> segurados = new List<SeguradoEntity>();
					if (dr.HasRows)
					{
						while (dr.Read())
						{
							segurados.Add(new SeguradoEntity()
							{
								Id = Convert.ToInt32(dr["ID"]),
								Nome = dr["NOME"].ToString(),
								CPF = dr["CPF"].ToString(),
								Banco = dr["BANCO"].ToString(),
								Agencia = dr["AGENCIA"].ToString(),
								DigitoAgencia = Convert.ToChar(dr["DIGITO_AGENCIA"]),
								Conta = dr["CONTA"].ToString(),
								DigitoConta = Convert.ToChar(dr["DIGITO_CONTA"]),
								Beneficiario = dr["BENEFICIARIO"].ToString(),
								CpfBeneficiario = dr["CPF_BENEFICIARIO"].ToString(),
								Email = dr["EMAIL"].ToString(),
								ContaCadastrada = Convert.ToBoolean(dr["CONTA_CADASTRADA"]),
								Ativo = Convert.ToBoolean(dr["ATIVO"])
							});
						}
					}
					return segurados;
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

		public SeguradoEntity GetById(int id)
		{
			try
			{
				OpenConnection();
				using (cmd = new SqlCommand("", con))
				{
					cmd.CommandText = "UP_SEGURADO_BUSCAR";
					cmd.CommandType = CommandType.StoredProcedure;
					cmd.Parameters.Add(new SqlParameter("@ID", SqlDbType.Int)).Value = id;
					dr = cmd.ExecuteReader();
					SeguradoEntity segurado = null;
					if (dr.HasRows)
					{
						while (dr.Read())
						{
							segurado = new SeguradoEntity()
							{
								Id = Convert.ToInt32(dr["ID"]),
								Nome = dr["NOME"].ToString(),
								CPF = dr["CPF"].ToString(),
								Banco = dr["BANCO"].ToString(),
								Agencia = dr["AGENCIA"].ToString(),
								DigitoAgencia = Convert.ToChar(dr["DIGITO_AGENCIA"]),
								Conta = dr["CONTA"].ToString(),
								DigitoConta = Convert.ToChar(dr["DIGITO_CONTA"]),
								Beneficiario = dr["BENEFICIARIO"].ToString(),
								CpfBeneficiario = dr["CPF_BENEFICIARIO"].ToString(),
								Email = dr["EMAIL"].ToString(),
								ContaCadastrada = Convert.ToBoolean(dr["CONTA_CADASTRADA"]),
								Ativo = Convert.ToBoolean(dr["ATIVO"])
							};
						}
					}
					return segurado;
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

		public void Update(SeguradoEntity segurado)
		{
			try
			{
				OpenConnection();
				using (cmd = new SqlCommand("", con))
				{
					cmd.CommandText = "UP_SEGURADO_ATUALIZAR";
					cmd.CommandType = CommandType.StoredProcedure;
					cmd.Parameters.Add(new SqlParameter("@ID", SqlDbType.Int)).Value = segurado.Id;
					cmd.Parameters.Add(new SqlParameter("@NOME", SqlDbType.VarChar, 100)).Value = segurado.Nome;
					cmd.Parameters.Add(new SqlParameter("@CPF", SqlDbType.VarChar, 14)).Value = segurado.CPF;
					cmd.Parameters.Add(new SqlParameter("@BANCO", SqlDbType.VarChar, 100)).Value = segurado.Banco;
					cmd.Parameters.Add(new SqlParameter("@AGENCIA", SqlDbType.VarChar, 4)).Value = segurado.Agencia;
					cmd.Parameters.Add(new SqlParameter("@DIGITO_AGENCIA", SqlDbType.Char, 1)).Value = segurado.DigitoAgencia;
					cmd.Parameters.Add(new SqlParameter("@CONTA", SqlDbType.VarChar, 10)).Value = segurado.Conta;
					cmd.Parameters.Add(new SqlParameter("@DIGITO_CONTA", SqlDbType.Char, 1)).Value = segurado.DigitoConta;
					cmd.Parameters.Add(new SqlParameter("@BENEFICIARIO", SqlDbType.VarChar, 100)).Value = segurado.Beneficiario;
					cmd.Parameters.Add(new SqlParameter("@CPF_BENEFICIARIO", SqlDbType.VarChar, 14)).Value = segurado.CpfBeneficiario;
					cmd.Parameters.Add(new SqlParameter("@EMAIL", SqlDbType.VarChar, 100)).Value = segurado.Email;
					cmd.Parameters.Add(new SqlParameter("@CONTA_CADASTRADA", SqlDbType.Bit)).Value = segurado.ContaCadastrada;
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
					cmd.CommandText = "UP_SEGURADO_DELETE";
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

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
    public class ContaBancariaRepository : Connection
    {
        public void Insert(ContaBancariaEntity contaBancaria)
        {
            try
            {
                OpenConnection();
                using (cmd = new SqlCommand("", con))
                {
                    cmd.CommandText = "cap.UP_CONTA_BANCARIA_CADASTRAR";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@NOME", SqlDbType.VarChar, 100)).Value = contaBancaria.Nome;
                    cmd.Parameters.Add(new SqlParameter("@BANCO", SqlDbType.VarChar, 100)).Value = contaBancaria.Banco;
                    cmd.Parameters.Add(new SqlParameter("@AGENCIA", SqlDbType.VarChar, 4)).Value = contaBancaria.Agencia;
                    cmd.Parameters.Add(new SqlParameter("@DIGITO_AGENCIA", SqlDbType.VarChar, 1)).Value = contaBancaria.DigitoAgencia;
                    cmd.Parameters.Add(new SqlParameter("@CONTA", SqlDbType.VarChar, 10)).Value = contaBancaria.Conta;
                    cmd.Parameters.Add(new SqlParameter("@DIGITO_CONTA", SqlDbType.VarChar, 1)).Value = contaBancaria.DigitoConta;
                    cmd.Parameters.Add(new SqlParameter("@SALDO", SqlDbType.Money)).Value = contaBancaria.Saldo;
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

        public List<ContaBancariaEntity> GetAll()
        {
            try
            {
                OpenConnection();
                using (cmd = new SqlCommand("", con))
                {
                    cmd.CommandText = "cap.UP_CONTA_BANCARIA_BUSCAR";
                    cmd.CommandType = CommandType.StoredProcedure;
                    dr = cmd.ExecuteReader();
                    List<ContaBancariaEntity> contasBancarias = new List<ContaBancariaEntity>();
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            contasBancarias.Add(new ContaBancariaEntity()
                            {
                                Id = Convert.ToInt32(dr["ID"]),
                                Nome = Convert.ToString(dr["NOME"]),
                                Ativo = Convert.ToBoolean(dr["ATIVO"]),
                                Banco = Convert.ToString(dr["BANCO"]),
                                Agencia = Convert.ToString(dr["AGENCIA"]),
                                DigitoAgencia = Convert.ToString(dr["DIGITO_AGENCIA"]),
                                Conta = Convert.ToString(dr["CONTA"]),
                                DigitoConta = Convert.ToString(dr["DIGITO_CONTA"]),
                                Saldo = Convert.ToDecimal(dr["SALDO"])
                            });
                        }
                    }
                    return contasBancarias;
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

        public ContaBancariaEntity GetById(int id)
        {
            try
            {
                OpenConnection();
                using (cmd = new SqlCommand("", con))
                {
                    cmd.CommandText = "cap.UP_CONTA_BANCARIA_BUSCAR";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@ID", SqlDbType.Int)).Value = id;
                    dr = cmd.ExecuteReader();
                    ContaBancariaEntity contaBancaria = null;
                    if (dr.Read())
                    {
                        contaBancaria = new ContaBancariaEntity()
                        {
                            Id = Convert.ToInt32(dr["ID"]),
                            Nome = Convert.ToString(dr["NOME"]),
                            Ativo = Convert.ToBoolean(dr["ATIVO"]),
                            Banco = Convert.ToString(dr["BANCO"]),
                            Agencia = Convert.ToString(dr["AGENCIA"]),
                            DigitoAgencia = Convert.ToString(dr["DIGITO_AGENCIA"]),
                            Conta = Convert.ToString(dr["CONTA"]),
                            DigitoConta = Convert.ToString(dr["DIGITO_CONTA"]),
                            Saldo = Convert.ToDecimal(dr["SALDO"])
                        };
                    }
                    return contaBancaria;
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

        public void Update(ContaBancariaEntity contaBancaria)
        {
            try
            {
                OpenConnection();
                using (cmd = new SqlCommand("", con))
                {
                    cmd.CommandText = "cap.UP_CONTA_BANCARIA_ATUALIZAR";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@ID", SqlDbType.Int)).Value = contaBancaria.Id;
                    cmd.Parameters.Add(new SqlParameter("@NOME", SqlDbType.VarChar, 100)).Value = contaBancaria.Nome;
                    cmd.Parameters.Add(new SqlParameter("@BANCO", SqlDbType.VarChar, 100)).Value = contaBancaria.Banco;
                    cmd.Parameters.Add(new SqlParameter("@AGENCIA", SqlDbType.VarChar, 4)).Value = contaBancaria.Agencia;
                    cmd.Parameters.Add(new SqlParameter("@DIGITO_AGENCIA", SqlDbType.VarChar, 1)).Value = contaBancaria.DigitoAgencia;
                    cmd.Parameters.Add(new SqlParameter("@CONTA", SqlDbType.VarChar, 10)).Value = contaBancaria.Conta;
                    cmd.Parameters.Add(new SqlParameter("@DIGITO_CONTA", SqlDbType.VarChar, 1)).Value = contaBancaria.DigitoConta;
                    cmd.Parameters.Add(new SqlParameter("@SALDO", SqlDbType.Money)).Value = contaBancaria.Saldo;
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
                    cmd.CommandText = "cap.UP_CONTA_BANCARIA_DELETAR";
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

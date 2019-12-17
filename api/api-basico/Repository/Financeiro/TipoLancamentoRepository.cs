using DBConnectionControl;
using Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Financeiro
{
    public class TipoLancamentoRepository : Connection
    {
        public List<TipoLancamento> GetAll()
        {
			try
			{
				OpenConnection();
				using (cmd = new SqlCommand("", con))
				{
					cmd.CommandText = "fin.UP_TIPO_LANCAMENTO_BUSCAR";
					cmd.CommandType = CommandType.StoredProcedure;
					dr = cmd.ExecuteReader();
					List<TipoLancamento> tipoLancamentos = new List<TipoLancamento>();
					if (dr.HasRows)
					{
						while (dr.Read())
						{
							tipoLancamentos.Add(new TipoLancamento()
							{
								Id = Convert.ToInt32(dr["ID"]),
								Nome = dr["NOME"].ToString(),
								Multiplicador = Convert.ToInt16(dr["MULTIPLICADOR"])
							});
						}
					}
					return tipoLancamentos;
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

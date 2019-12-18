using Repository;
using Entity;
using Business.Importacao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IronXL;
using System.Data;
using Entity.Importacao;

namespace Business
{
    public class ImportacaoBusiness
    {
        public void Insert(ImportacaoEntity importacao) => new ImportacaoRepository().Insert(importacao);

        public Dictionary<string, List<ImportacaoEntity>> GetAll()
        {
            try
            {
                List<ImportacaoEntity> importacaos = new ImportacaoRepository().GetAll();
                return new Dictionary<string, List<ImportacaoEntity>>()
                {
                    {"ativos", importacaos.Where(i => i.Ativo == true).ToList() },
                    {"inativos", importacaos.Where(i => i.Ativo == false).ToList() }
                };
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public ImportacaoEntity GetById(int id) => new ImportacaoRepository().GetById(id);

        public void Update(ImportacaoEntity importacao) => new ImportacaoRepository().Update(importacao);

        public void Delete(int id) => new ImportacaoRepository().Delete(id);

        public void Processar(int id)
        {
            try
            {
                ImportacaoEntity importacao = new ImportacaoBusiness().GetById(id);
                LerExcel(importacao);
                importacao.Processada = true;
                new ImportacaoBusiness().Update(importacao);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private void LerExcel(ImportacaoEntity importacao)
        {
            try
            {
                WorkBook wb = WorkBook.Load(importacao.CaminhoArquivo);
                WorkSheet ws = wb.WorkSheets.First();
                var table = ws.ToDataTable(true);
                DataRow[] rows = table.Select();
                IEnumerable<DataRow> ts = from processo in table.AsEnumerable() select processo;

                foreach (DataRow row in table.Rows)
                {
                    new RegistroBusiness().Insert(new RegistroEntity
                    {
                        Importacao = importacao,
                        NumeroSinistro = row["Número Sinistro Zurich"].ToString(),
                        Companhia = row["CIAS"].ToString(),
                        Processo = row["Processo"].ToString(),
                        Bilhete = row["Bilhete"].ToString(),
                        DataEmissaoVoucher = Convert.ToDateTime(row["Data de Emissão do Voucher"]),
                        Referencia = row["Referência"].ToString(),
                        DataAtendimento = Convert.ToDateTime(row["Data de Atendimento"]),
                        DataOcorrencia = Convert.ToDateTime(row["Data de Ocorrência"]),
                        Nome = row["Nome"].ToString(),
                        NumeroDocumento = row["Número do DOC"].ToString(),
                        Voucher = row["VOUCHER "].ToString(),
                        Cobertura = row["Cobertura Reclamada"].ToString(),
                        CustoOriginal = Convert.ToDecimal(row["Custo na Moeda Original"]),
                        TipoMoeda = row["Tipo de Moeda"].ToString(),
                        ValorFinal = Convert.ToDecimal(row["Valor Final (US$)"]),
                        Fee = Convert.ToDecimal(row["Fee"]),
                        TipoMoedaFee = row["Tipo de Moeda Fee"].ToString(),
                        ValorDolar = Convert.ToDecimal(row["Valor USD"]),
                        ValorReal = Convert.ToDecimal(row["Valor ND R$"]),
                        Dolar = Convert.ToDouble(row["Dólar"]),
                        NotaDebito = row["ND/NC"].ToString(),
                        DataEmissaoND = Convert.ToDateTime(row["Data de Emissão ND"]),
                        DataEnvio = Convert.ToDateTime(row["Data de envio"]),
                        StatusPagamento = row["Status de Pgto PARCIAL/TOTAL"].ToString()
                    });
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Service.Models.Financeiro
{
    public class LancamentoModel
    {
        public string Descricao { get; set; }
        public bool CustoFixo { get; set; }
        public decimal Valor { get; set; }
        public DateTime DataLancamento { get; set; }
        public int FechamentoId { get; set; }
        public int ClienteId { get; set; }
        public int ContaBancariaId { get; set; }
        public int CategoriaId { get; set; }
        public int FornecedorId { get; set; }
        public int CentroCustoId { get; set; }
    }
}
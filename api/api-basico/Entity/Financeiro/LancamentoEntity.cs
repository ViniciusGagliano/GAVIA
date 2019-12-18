using Entity.Acompanhamento;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Financeiro
{
    public class LancamentoEntity
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
        public bool Ativo { get; set; }
        public bool CustoFixo { get; set; }
        public decimal Valor { get; set; }
        public DateTime DataLancamento { get; set; }
        public string DataLancamentoFormatada { get; set; }
        public FechamentoEntity Fechamento { get; set; }
        public ClienteEntity Cliente { get; set; }
        public ContaBancariaEntity ContaBancaria { get; set; }
        public CentroCustoEntity CentroCusto { get; set; }
        public CategoriaEntity Categoria { get; set; }
        public FornecedorEntity Fornecedor { get; set; }
    }
}

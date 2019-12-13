using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Service.Models
{
    public class NotaDebitoModel
    {
        public string Nome { get; set; }
        public DateTime DataEmissao { get; set; }
        public DateTime DataEnvio { get; set; }
        public DateTime PrevisaoPagamento { get; set; }
        public DateTime DataPagamento { get; set; }
        public DateTime DataRepasseRemessa { get; set; }
        public DateTime DataEmail { get; set; }
        public decimal DolarBancoCentral { get; set; }
        public string Observacao { get; set; }
    }
}
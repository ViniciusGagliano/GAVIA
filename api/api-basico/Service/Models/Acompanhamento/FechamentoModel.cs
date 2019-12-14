using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Service.Models.Acompanhamento
{
    public class FechamentoModel
    {
        public DateTime DataFechamento { get; set; }
        public bool Remessa { get; set; }
        public decimal DolarRemessa { get; set; }
        public int EmissorId { get; set; }
    }
}
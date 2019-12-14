using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Acompanhamento
{
    public class FechamentoEntity
    {
        public int Id { get; set; }
        public DateTime DataFechamento { get; set; }
        public bool Remessa { get; set; }
        public decimal DolarRemessa { get; set; }
        public EmissorEntity Emissor { get; set; }
    }
}

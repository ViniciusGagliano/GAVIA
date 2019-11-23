using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class RepresentanteEntity
    {
        public int? Id { get; set; }
        public string Nome { get; set; }
        public string CNPJ { get; set; }
        public bool Ativo { get; set; }
        public DateTime DataCriacao { get; set; }
    }
}

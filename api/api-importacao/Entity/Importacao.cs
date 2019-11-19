using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class Importacao
    {
        public int SeguradoraId { get; set; }
        public bool Antecipacao { get; set; }
        public string CaminhoArquivo { get; set; }
        public string NomeArquivo { get; set; }
    }
}

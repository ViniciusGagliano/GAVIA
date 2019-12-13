using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class ImportacaoEntity
    {
        public int Id { get; set; }
        public string NomeArquivo { get; set; }
        public string CaminhoArquivo { get; set; }
        public bool Antecipacao { get; set; }
        public bool Ativo { get; set; }
        public SeguradoraEntity Seguradora { get; set; }
    }
}

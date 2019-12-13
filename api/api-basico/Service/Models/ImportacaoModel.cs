using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Service.Models
{
    public class ImportacaoModel
    {
        public string NomeArquivo { get; set; }
        public string CaminhoArquivo { get; set; }
        public bool Antecipacao { get; set; }
        public int SeguradoraId { get; set; }
    }
}
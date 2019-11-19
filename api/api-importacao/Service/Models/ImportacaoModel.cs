using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Service.Models
{
    public class ImportacaoModel
    {
        public int SeguradoraId { get; set; }
        public int Antecipacao { get; set; }
        public Dictionary<string, object> Arquivo { get; set; }
    }
}
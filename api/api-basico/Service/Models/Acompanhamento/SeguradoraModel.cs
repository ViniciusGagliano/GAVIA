using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Service.Models
{
    public class SeguradoraModel
    {
        [Required]
        public string Nome { get; set; }
        [Required]
        public string CNPJ { get; set; }
        [Required]
        public bool Antecipacao { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Service.Models
{
    public class ContaBancariaModel
    {
        public string Nome { get; set; }
        public bool Ativo { get; set; }
        public string Banco { get; set; }
        public string Agencia { get; set; }
        public string DigitoAgencia { get; set; }
        public string Conta { get; set; }
        public string DigitoConta { get; set; }
        public decimal Saldo { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Service.Models
{
    public class SeguradoModel
    {
        public string Nome { get; set; }
        public string CPF { get; set; }
        public string Banco { get; set; }
        public string Agencia { get; set; }
        public char DigitoAgencia { get; set; }
        public string Conta { get; set; }
        public char DigitoConta { get; set; }
        public string Beneficiario { get; set; }
        public string CpfBeneficiario { get; set; }
        public string Email { get; set; }
        public bool ContaCadastrada { get; set; }
    }
}
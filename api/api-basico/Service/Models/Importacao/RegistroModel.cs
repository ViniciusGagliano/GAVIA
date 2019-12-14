using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Service.Models.Importacao
{
    public class RegistroModel
    {
        public int ImportacaoId { get; set; }
        public string NumeroSinistro { get; set; }
        public string Companhia { get; set; }
        public string Processo { get; set; }
        public string Bilhete { get; set; }
        public DateTime DataEmissaoVoucher { get; set; }
        public string Referencia { get; set; }
        public DateTime DataAtendimento { get; set; }
        public DateTime DataOcorrencia { get; set; }
        public string Nome { get; set; }
        public string NumeroDocumento { get; set; }
        public string Voucher { get; set; }
        public string Cobertura { get; set; }
        public decimal CustoOriginal { get; set; }
        public string TipoMoeda { get; set; }
        public decimal ValorFinal { get; set; }
        public decimal Fee { get; set; }
        public string TipoMoedaFee { get; set; }
        public decimal ValorDolar { get; set; }
        public decimal ValorReal { get; set; }
        public double Dolar { get; set; }
        public int SinistroId { get; set; }
    }
}
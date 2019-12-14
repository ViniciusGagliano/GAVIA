using Service.Models.Importacao;
using Entity.Importacao;
using Business.Importacao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Service.Controllers.Importacao
{
    [RoutePrefix("basico")]
    public class RegistroController : ApiController
    {
        [HttpPost]
        [Route("registros")]
        public HttpResponseMessage Insert(RegistroModel model)
        {
            try
            {
                new RegistroBusiness().Insert(new RegistroEntity()
                {
                    Bilhete = model.Bilhete,
                    Cobertura = model.Cobertura,
                    Companhia = model.Companhia,
                    CustoOriginal = model.CustoOriginal,
                    DataAtendimento = model.DataAtendimento,
                    DataEmissaoVoucher = model.DataEmissaoVoucher,
                    DataOcorrencia = model.DataOcorrencia,
                    Dolar = model.Dolar,
                    Fee = model.Fee,
                    Nome = model.Nome,
                    NumeroDocumento = model.NumeroDocumento,
                    NumeroSinistro = model.NumeroSinistro,
                    Processo = model.Processo,
                    Referencia = model.Referencia,
                    SinistroId = model.SinistroId,
                    TipoMoeda = model.TipoMoeda,
                    TipoMoedaFee = model.TipoMoedaFee,
                    ValorDolar = model.ValorDolar,
                    ValorFinal = model.ValorFinal,
                    ValorReal = model.ValorReal,
                    Voucher = model.Voucher,
                    Importacao = new Entity.ImportacaoEntity() { Id = model.ImportacaoId }
                });
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpGet]
        [Route("registros")]
        public HttpResponseMessage GetAll()
        {
            try
            {
                return Request.CreateResponse(HttpStatusCode.OK, new RegistroBusiness().GetAll());
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpGet]
        [Route("registros/{id}")]
        public HttpResponseMessage GetById(int id)
        {
            try
            {
                return Request.CreateResponse(HttpStatusCode.OK, new RegistroBusiness().GetById(id));
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpPut]
        [Route("registros/{id}")]
        public HttpResponseMessage Update(int id, RegistroModel model)
        {
            try
            {
                new RegistroBusiness().Update(new RegistroEntity()
                {
                    Id = id,
                    Bilhete = model.Bilhete,
                    Cobertura = model.Cobertura,
                    Companhia = model.Companhia,
                    CustoOriginal = model.CustoOriginal,
                    DataAtendimento = model.DataAtendimento,
                    DataEmissaoVoucher = model.DataEmissaoVoucher,
                    DataOcorrencia = model.DataOcorrencia,
                    Dolar = model.Dolar,
                    Fee = model.Fee,
                    Nome = model.Nome,
                    NumeroDocumento = model.NumeroDocumento,
                    NumeroSinistro = model.NumeroSinistro,
                    Processo = model.Processo,
                    Referencia = model.Referencia,
                    SinistroId = model.SinistroId,
                    TipoMoeda = model.TipoMoeda,
                    TipoMoedaFee = model.TipoMoedaFee,
                    ValorDolar = model.ValorDolar,
                    ValorFinal = model.ValorFinal,
                    ValorReal = model.ValorReal,
                    Voucher = model.Voucher,
                    Importacao = new Entity.ImportacaoEntity() { Id = model.ImportacaoId }
                });
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpDelete]
        [Route("registros/{id}")]
        public HttpResponseMessage Delete(int id)
        {
            try
            {
                new RegistroBusiness().Delete(id);
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }
    }
}

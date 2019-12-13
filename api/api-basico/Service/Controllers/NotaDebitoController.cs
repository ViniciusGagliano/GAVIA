using Service.Models;
using Entity;
using Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Service.Controllers
{
    [RoutePrefix("basico")]
    public class NotaDebitoController : ApiController
    {
        [HttpPost]
        [Route("notasdebitos")]
        public HttpResponseMessage Insert(NotaDebitoModel model)
        {
            try
            {
                new NotaDebitoBusiness().Insert(new NotaDebitoEntity()
                {
                    Nome = model.Nome,
                    DataEmail = model.DataEmail,
                    DataEmissao = model.DataEmissao,
                    DataEnvio = model.DataEnvio,
                    DataPagamento = model.DataPagamento,
                    DataRepasseRemessa = model.DataRepasseRemessa,
                    PrevisaoPagamento = model.PrevisaoPagamento,
                    DolarBancoCentral = model.DolarBancoCentral,
                    Observacao = model.Observacao
                });
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpGet]
        [Route("notasdebitos")]
        public HttpResponseMessage GetAll()
        {
            try
            {
                return Request.CreateResponse(HttpStatusCode.OK, new NotaDebitoBusiness().GetAll());
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpGet]
        [Route("notasdebitos/{id}")]
        public HttpResponseMessage GetById(int id)
        {
            try
            {
                return Request.CreateResponse(HttpStatusCode.OK, new NotaDebitoBusiness().GetById(id));
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpPut]
        [Route("notasdebitos/{id}")]
        public HttpResponseMessage Update(int id, NotaDebitoModel model)
        {
            try
            {
                new NotaDebitoBusiness().Update(new NotaDebitoEntity()
                {
                    Id = id,
                    Nome = model.Nome,
                    DataEmail = model.DataEmail,
                    DataEmissao = model.DataEmissao,
                    DataEnvio = model.DataEnvio,
                    DataPagamento = model.DataPagamento,
                    DataRepasseRemessa = model.DataRepasseRemessa,
                    PrevisaoPagamento = model.PrevisaoPagamento,
                    DolarBancoCentral = model.DolarBancoCentral,
                    Observacao = model.Observacao
                });
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpDelete]
        [Route("notasdebitos/{id}")]
        public HttpResponseMessage Delete(int id)
        {
            try
            {
                new NotaDebitoBusiness().Delete(id);
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }
    }
}

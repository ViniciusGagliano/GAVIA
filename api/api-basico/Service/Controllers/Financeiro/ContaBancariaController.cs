using Business;
using Entity;
using Service.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Service.Controllers
{
    [RoutePrefix("basico")]
    public class ContaBancariaController : ApiController
    {
        [HttpPost]
        [Route("contasbancarias")]
        public HttpResponseMessage Insert(ContaBancariaModel model)
        {
            try
            {
                new ContaBancariaBusiness().Insert(new ContaBancariaEntity()
                {
                    Nome = model.Nome,
                    Banco = model.Banco,
                    Agencia = model.Agencia,
                    DigitoAgencia = model.DigitoAgencia,
                    Conta = model.Conta,
                    DigitoConta = model.DigitoConta,
                    Saldo = model.Saldo
                });
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpGet]
        [Route("contasbancarias")]
        public HttpResponseMessage GetAll()
        {
            try
            {
                return Request.CreateResponse(HttpStatusCode.OK, new ContaBancariaBusiness().GetAll());
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpGet]
        [Route("contasbancarias/{id}")]
        public HttpResponseMessage GetById(int id)
        {
            try
            {
                return Request.CreateResponse(HttpStatusCode.OK, new ContaBancariaBusiness().GetById(id));
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpPut]
        [Route("contasbancarias/{id}")]
        public HttpResponseMessage Update(int id, ContaBancariaModel model)
        {
            try
            {
                new ContaBancariaBusiness().Update(new ContaBancariaEntity()
                {
                    Id = id,
                    Nome = model.Nome,
                    Banco = model.Banco,
                    Agencia = model.Agencia,
                    DigitoAgencia = model.DigitoAgencia,
                    Conta = model.Conta,
                    DigitoConta = model.DigitoConta,
                    Saldo = model.Saldo
                });
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpDelete]
        [Route("contasbancarias/{id}")]
        public HttpResponseMessage Delete(int id)
        {
            try
            {
                new ContaBancariaBusiness().Delete(id);
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }
    }
}

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
    public class SeguradoController : ApiController
    {
        [HttpPost]
        [Route("segurados")]
        public HttpResponseMessage Insert(SeguradoModel model)
        {
            try
            {
                new SeguradoBusiness().Insert(new SeguradoEntity()
                {
                    Nome = model.Nome,
                    CPF = model.CPF,
                    Banco = model.Banco,
                    Agencia = model.Agencia,
                    DigitoAgencia = model.DigitoAgencia,
                    Conta = model.Conta,
                    DigitoConta = model.DigitoConta,
                    Beneficiario = model.Beneficiario,
                    CpfBeneficiario = model.CpfBeneficiario,
                    Email = model.Email,
                    ContaCadastrada = model.ContaCadastrada
                });
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpGet]
        [Route("segurados")]
        public HttpResponseMessage GetAll()
        {
            try
            {
                return Request.CreateResponse(HttpStatusCode.OK, new SeguradoBusiness().GetAll());
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpGet]
        [Route("segurados/{id}")]
        public HttpResponseMessage GetById(int id)
        {
            try
            {
                return Request.CreateResponse(HttpStatusCode.OK, new SeguradoBusiness().GetById(id));
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpPut]
        [Route("segurados/{id}")]
        public HttpResponseMessage Update(int id, SeguradoModel model)
        {
            try
            {
                new SeguradoBusiness().Update(new SeguradoEntity()
                {
                    Id = id,
                    Nome = model.Nome,
                    CPF = model.CPF,
                    Banco = model.Banco,
                    Agencia = model.Agencia,
                    DigitoAgencia = model.DigitoAgencia,
                    Conta = model.Conta,
                    DigitoConta = model.DigitoConta,
                    Beneficiario = model.Beneficiario,
                    CpfBeneficiario = model.CpfBeneficiario,
                    Email = model.Email,
                    ContaCadastrada = model.ContaCadastrada
                });
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpDelete]
        [Route("segurados/{id}")]
        public HttpResponseMessage Delete(int id)
        {
            try
            {
                new SeguradoBusiness().Delete(id);
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }
    }
}

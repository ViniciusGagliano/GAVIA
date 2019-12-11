using Service.Models;
using Business;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Service.Controllers
{
    [RoutePrefix("basico")]
    public class FornecedorController : ApiController
    {
        [HttpPost]
        [Route("forncedores")]
        public HttpResponseMessage Insert(FornecedorModel model)
        {
            try
            {
                new FornecedorBusiness().Insert(new FornecedorEntity()
                {
                    Nome = model.Nome,
                    CNPJ = model.CNPJ
                });
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpGet]
        [Route("forncedores")]
        public HttpResponseMessage GetAll()
        {
            try
            {
                return Request.CreateResponse(HttpStatusCode.OK, new FornecedorBusiness().GetAll());
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpGet]
        [Route("forncedores/{id}")]
        public HttpResponseMessage GetById(int id)
        {
            try
            {
                return Request.CreateResponse(HttpStatusCode.OK, new FornecedorBusiness().GetById(id));
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpPut]
        [Route("forncedores/{id}")]
        public HttpResponseMessage Update(int id, FornecedorModel model)
        {
            try
            {
                new FornecedorBusiness().Update(new FornecedorEntity()
                {
                    Id = id,
                    Nome = model.Nome,
                    CNPJ = model.CNPJ
                });
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpDelete]
        [Route("forncedores/{id}")]
        public HttpResponseMessage Delete(int id)
        {
            try
            {
                new FornecedorBusiness().Delete(id);
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }
    }
}

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
    public class ClienteController : ApiController
    {
        [HttpPost]
        [Route("clientes")]
        public HttpResponseMessage Insert(ClienteModel model)
        {
            try
            {
                new ClienteBusiness().Insert(new ClienteEntity()
                {
                    Nome = model.Nome,
                    Seguradora = (model.SeguradoraId == 0) ? null : new SeguradoraEntity() { Id = model.SeguradoraId }
                });

                return Request.CreateResponse(HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpGet]
        [Route("clientes")]
        public HttpResponseMessage GetAll()
        {
            try
            {
                return Request.CreateResponse(HttpStatusCode.OK, new ClienteBusiness().GetAll());
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpGet]
        [Route("clientes/{id}")]
        public HttpResponseMessage GetById(int id)
        {
            try
            {
                return Request.CreateResponse(HttpStatusCode.OK, new ClienteBusiness().GetById(id));
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpPut]
        [Route("clientes/{id}")]
        public HttpResponseMessage Update(int id, ClienteModel model)
        {
            try
            {
                new ClienteBusiness().Update(new ClienteEntity()
                {
                    Id = id,
                    Nome = model.Nome,
                    Seguradora = new SeguradoraEntity() { Id = model.SeguradoraId }
                });

                return Request.CreateResponse(HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpDelete]
        [Route("clientes/{id}")]
        public HttpResponseMessage Delete(int id)
        {
            try
            {
                new ClienteBusiness().Delete(id);
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }
    }
}
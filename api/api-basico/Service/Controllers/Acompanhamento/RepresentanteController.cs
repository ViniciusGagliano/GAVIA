using Entity;
using Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Service.Models;

namespace Service.Controllers
{
    [RoutePrefix("basico")]
    public class RepresentanteController : ApiController
    {
        private readonly RepresentanteBusiness business;

        public RepresentanteController()
        {
            business = new RepresentanteBusiness();
        }

        [HttpPost]
        [Route("representantes")]
        public HttpResponseMessage Insert(RepresentanteModel model)
        {
            try
            {
                business.Insert(ModelToEntity(model));
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message.ToString());
            }
        }

        [HttpGet]
        [Route("representantes")]
        public HttpResponseMessage GetAll()
        {
            try
            {
                return Request.CreateResponse(HttpStatusCode.OK, business.GetAll());
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message.ToString());
            }
        }

        [HttpGet]
        [Route("representantes/{id}")]
        public HttpResponseMessage GetById(int id)
        {
            try
            {
                return Request.CreateResponse(HttpStatusCode.OK, business.GetById(id));
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message.ToString());
            }
        }

        [HttpPut]
        [Route("representantes/{id}")]
        public HttpResponseMessage Update(int id, RepresentanteModel model)
        {
            try
            {
                RepresentanteEntity entity = ModelToEntity(model);
                entity.Id = id;
                business.Update(entity);
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message.ToString());
            }
        }

        [HttpDelete]
        [Route("representantes/{id}")]
        public HttpResponseMessage Delete(int id)
        {
            try
            {
                business.Delete(id);
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message.ToString());
            }
        }

        private RepresentanteEntity ModelToEntity(RepresentanteModel model)
        {
            return new RepresentanteEntity()
            {
                Nome = model.Nome,
                CNPJ = model.CNPJ
            };
        }
    }
}

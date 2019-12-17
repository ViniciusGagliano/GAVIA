using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Business;
using Entity;
using Service.Models;

namespace Service.Controllers
{
    [RoutePrefix("basico")]
    public class PatrocinioController : ApiController
    {
        private readonly PatrocinioBusiness business;

        public PatrocinioController()
        {
            business = new PatrocinioBusiness();
        }

        [HttpPost]
        [Route("patrocinios")]
        public HttpResponseMessage Insert(PatrocinioModel model)
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
        [Route("patrocinios")]
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
        [Route("patrocinios/{id}")]
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
        [Route("patrocinios/{id}")]
        public HttpResponseMessage Update(int id, PatrocinioModel model)
        {
            try
            {
                PatrocinioEntity patrocinio = ModelToEntity(model);
                patrocinio.Id = id;
                business.Update(patrocinio);
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message.ToString());
            }
        }

        [HttpDelete]
        [Route("patrocinios/{id}")]
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

        private PatrocinioEntity ModelToEntity(PatrocinioModel model)
        {
            return new PatrocinioEntity()
            {
                Seguradora = new SeguradoraEntity() { Id = model.SeguradoraId },
                Representante = new RepresentanteEntity() { Id = model.RepresentanteId }
            };
        }
    }
}

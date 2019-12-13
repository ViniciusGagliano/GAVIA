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
    public class TipoSinistroController : ApiController
    {
        [HttpPost]
        [Route("tiposinistros")]
        public HttpResponseMessage Insert(TipoSinistroModel model)
        {
            try
            {
                new TipoSinistroBusiness().Insert(new TipoSinistroEntity()
                {
                    Nome = model.Nome
                });
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpGet]
        [Route("tiposinistros")]
        public HttpResponseMessage GetAll()
        {
            try
            {
                return Request.CreateResponse(HttpStatusCode.OK, new TipoSinistroBusiness().GetAll());
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpGet]
        [Route("tiposinistros/{id}")]
        public HttpResponseMessage GetById(int id)
        {
            try
            {
                return Request.CreateResponse(HttpStatusCode.OK, new TipoSinistroBusiness().GetById(id));
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpPut]
        [Route("tiposinistros/{id}")]
        public HttpResponseMessage Update(int id, TipoSinistroModel model)
        {
            try
            {
                new TipoSinistroBusiness().Update(new TipoSinistroEntity()
                {
                    Id = id,
                    Nome = model.Nome
                });
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpDelete]
        [Route("tiposinistros/{id}")]
        public HttpResponseMessage Delete(int id)
        {
            try
            {
                new TipoSinistroBusiness().Delete(id);
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }
    }
}

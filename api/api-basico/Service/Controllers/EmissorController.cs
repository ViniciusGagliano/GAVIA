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
    public class EmissorController : ApiController
    {
        [HttpPost]
        [Route("emissores")]
        public HttpResponseMessage Insert(EmissorModel model)
        {
            try
            {
                new EmissorBusiness().Insert(new EmissorEntity()
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
        [Route("emissores")]
        public HttpResponseMessage GetAll()
        {
            try
            {
                return Request.CreateResponse(HttpStatusCode.OK, new EmissorBusiness().GetAll());
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpGet]
        [Route("emissores/{id}")]
        public HttpResponseMessage GetById(int id)
        {
            try
            {
                return Request.CreateResponse(HttpStatusCode.OK, new EmissorBusiness().GetById(id));
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpPut]
        [Route("emissores/{id}")]
        public HttpResponseMessage Update(int id, EmissorModel model)
        {
            try
            {
                new EmissorBusiness().Update(new EmissorEntity()
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
        [Route("emissores/{id}")]
        public HttpResponseMessage Delete(int id)
        {
            try
            {
                new EmissorBusiness().Delete(id);
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }
    }
}

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
    public class CentroCustoController : ApiController
    {
        [HttpPost]
        [Route("centroscustos")]
        public HttpResponseMessage Insert(CentroCustoModel model)
        {
            try
            {
                new CentroCustoBusiness().Insert(new CentroCustoEntity()
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
        [Route("centroscustos")]
        public HttpResponseMessage GetAll()
        {
            try
            {
                return Request.CreateResponse(HttpStatusCode.OK, new CentroCustoBusiness().GetAll());
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpGet]
        [Route("centroscustos/{id}")]
        public HttpResponseMessage GetById(int id)
        {
            try
            {
                return Request.CreateResponse(HttpStatusCode.OK, new CentroCustoBusiness().GetById(id));
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpPut]
        [Route("centroscustos/{id}")]
        public HttpResponseMessage Update(int id, CentroCustoModel model)
        {
            try
            {
                new CentroCustoBusiness().Update(new CentroCustoEntity()
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
        [Route("centroscustos/{id}")]
        public HttpResponseMessage Delete(int id)
        {
            try
            {
                new CentroCustoBusiness().Delete(id);
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }
    }
}

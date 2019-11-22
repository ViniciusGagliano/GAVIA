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
    [RoutePrefix("api")]
    public class SeguradoraController : ApiController
    {
        [HttpPost]
        [Route("seguradoras")]
        public HttpResponseMessage Insert(SeguradoraEntity seguradora)
        {
            try
            {
                return Request.CreateResponse(HttpStatusCode.OK, new SeguradoraBusiness().Insert(seguradora));
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message.ToString());
            }
        }

        [HttpGet]
        [Route("seguradoras")]
        public HttpResponseMessage GetAll()
        {
            try
            {
                List<SeguradoraEntity> lista = new List<SeguradoraEntity>();
                Dictionary<string, List<SeguradoraEntity>> seguradoras = new Dictionary<string, List<SeguradoraEntity>>();
                
                lista = new SeguradoraBusiness().GetAll();
                seguradoras.Add("ativos", lista.Where(s => s.Ativo == true).ToList());
                seguradoras.Add("inativos", lista.Where(s => s.Ativo == false).ToList());

                return Request.CreateResponse(HttpStatusCode.OK, seguradoras);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message.ToString());
            }
        }

        [HttpGet]
        [Route("seguradoras/{id}")]
        public HttpResponseMessage GetById(int id)
        {
            try
            {
                return Request.CreateResponse(HttpStatusCode.OK, new SeguradoraBusiness().GetById(id));
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message.ToString());
            }
        }

        [HttpPut]
        [Route("seguradoras/{id}")]
        public HttpResponseMessage Update(SeguradoraEntity seguradora)
        {
            try
            {
                new SeguradoraBusiness().Update(seguradora);
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message.ToString());
            }
        }

        [HttpDelete]
        [Route("seguradoras/{id}")]
        public HttpResponseMessage Delete(int id)
        {
            try
            {
                new SeguradoraBusiness().Delete(id);
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message.ToString());
            }
        }
    }
}

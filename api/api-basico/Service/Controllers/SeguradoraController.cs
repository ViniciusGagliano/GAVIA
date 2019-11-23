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
    public class SeguradoraController : ApiController
    {
        private readonly SeguradoraBusiness business;

        public SeguradoraController()
        {
            business = new SeguradoraBusiness();
        }

        [HttpPost]
        [Route("seguradoras")]
        public HttpResponseMessage Insert(SeguradoraModel seguradora)
        {
            try
            {
                business.Insert(ModelToEntity(seguradora));
                return Request.CreateResponse(HttpStatusCode.OK);
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
                List<SeguradoraEntity> lista = business.GetAll();
                Dictionary<string, List<SeguradoraEntity>> seguradoras = new Dictionary<string, List<SeguradoraEntity>>
                {
                    { "ativos", lista.Where(s => s.Ativo == true).ToList() },
                    { "inativos", lista.Where(s => s.Ativo == false).ToList() }
                };

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
                return Request.CreateResponse(HttpStatusCode.OK, business.GetById(id));
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message.ToString());
            }
        }

        [HttpPut]
        [Route("seguradoras/{id}")]
        public HttpResponseMessage Update(int id, SeguradoraModel seguradora)
        {
            try
            {
                SeguradoraEntity entity = ModelToEntity(seguradora);
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
        [Route("seguradoras/{id}")]
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

        private SeguradoraEntity ModelToEntity(SeguradoraModel model)
        {
            return new SeguradoraEntity()
            {
                Nome = model.Nome,
                CNPJ = model.CNPJ,
                Antecipacao = model.Antecipacao
            };
        }
    }
}

using Service.Models.Acompanhamento;
using Entity.Acompanhamento;
using Business.Acompanhamento;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Service.Controllers.Acompanhamento
{
    [RoutePrefix("basico")]
    public class FechamentoController : ApiController
    {
        [HttpPost]
        [Route("fechamentos")]
        public HttpResponseMessage Insert(FechamentoModel model)
        {
            try
            {
                new FechamentoBusiness().Insert(new FechamentoEntity()
                {
                    DataFechamento = model.DataFechamento,
                    Remessa = model.Remessa,
                    DolarRemessa = model.DolarRemessa,
                    Emissor = new Entity.EmissorEntity() { Id = model.EmissorId }
                });
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpGet]
        [Route("fechamentos")]
        public HttpResponseMessage GetAll()
        {
            try
            {
                return Request.CreateResponse(HttpStatusCode.OK, new FechamentoBusiness().GetAll());
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpGet]
        [Route("fechamentos/{id}")]
        public HttpResponseMessage GetById(int id)
        {
            try
            {
                return Request.CreateResponse(HttpStatusCode.OK, new FechamentoBusiness().GetById(id));
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpPut]
        [Route("fechamentos/{id}")]
        public HttpResponseMessage Update(int id, FechamentoModel model)
        {
            try
            {
                new FechamentoBusiness().Update(new FechamentoEntity()
                {
                    Id = id,
                    DataFechamento = model.DataFechamento,
                    Remessa = model.Remessa,
                    DolarRemessa = model.DolarRemessa,
                    Emissor = new Entity.EmissorEntity() { Id = model.EmissorId }
                });
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpDelete]
        [Route("fechamentos/{id}")]
        public HttpResponseMessage Delete(int id)
        {
            try
            {
                new FechamentoBusiness().Delete(id);
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }
    }
}

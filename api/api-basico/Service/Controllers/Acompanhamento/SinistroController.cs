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
    public class SinistroController : ApiController
    {
        [HttpGet]
        [Route("impsinistros/{id}")]
        public HttpResponseMessage GetAllImportacao(int id)
        {
            try
            {
                return Request.CreateResponse(HttpStatusCode.OK, new SinistroBusiness().GetAllImportacao(id));
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }
    }
}

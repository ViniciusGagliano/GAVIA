using Business.Financeiro;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Service.Controllers.Financeiro
{
    [RoutePrefix("basico")]
    public class TipoLancamentoController : ApiController
    {
        [HttpGet]
        [Route("tiposlancamentos")]
        public HttpResponseMessage GetAll()
        {
            try
            {
                return Request.CreateResponse(HttpStatusCode.OK, new TipoLancamentoBusiness().GetAll());
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }
    }
}

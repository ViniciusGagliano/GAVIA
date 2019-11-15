using Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Service.Controllers
{
    [RoutePrefix("importacao")]
    public class ImportacaoController : ApiController
    {
        [HttpPost]
        [Route("insert")]
        public HttpResponseMessage ImportarArquivo()
        {
            try
            {
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }
    }
}

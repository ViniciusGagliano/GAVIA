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
    public class CategoriaController : ApiController
    {
        [HttpPost]
        [Route("categorias")]
        public HttpResponseMessage Insert(CategoriaModel model)
        {
            try
            {
                new CategoriaBusiness().Insert(new CategoriaEntity()
                {
                    Nome = model.Nome,
                    TipoLancamento = new TipoLancamento() { Id = model.TipoLancamentoId }
                });
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpGet]
        [Route("categorias")]
        public HttpResponseMessage GetAll()
        {
            try
            {
                return Request.CreateResponse(HttpStatusCode.OK, new CategoriaBusiness().GetAll());
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpGet]
        [Route("categorias/{id}")]
        public HttpResponseMessage GetById(int id)
        {
            try
            {
                return Request.CreateResponse(HttpStatusCode.OK, new CategoriaBusiness().GetById(id));
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpPut]
        [Route("categorias/{id}")]
        public HttpResponseMessage Update(int id, CategoriaModel model)
        {
            try
            {
                new CategoriaBusiness().Update(new CategoriaEntity()
                {
                    Id = id,
                    Nome = model.Nome,
                    TipoLancamento = new TipoLancamento() { Id = model.TipoLancamentoId }
                });
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpDelete]
        [Route("categorias/{id}")]
        public HttpResponseMessage Delete(int id)
        {
            try
            {
                new CategoriaBusiness().Delete(id);
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }
    }
}

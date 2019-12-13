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
    public class ImportacaoController : ApiController
    {
        [HttpPost]
        [Route("importacoes")]
        public HttpResponseMessage Insert(ImportacaoModel model)
        {
            try
            {
                new ImportacaoBusiness().Insert(new ImportacaoEntity()
                {
                    NomeArquivo = model.NomeArquivo,
                    CaminhoArquivo = model.CaminhoArquivo,
                    Antecipacao = model.Antecipacao,
                    Seguradora = new SeguradoraEntity() { Id = model.SeguradoraId }
                });
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpGet]
        [Route("importacoes")]
        public HttpResponseMessage GetAll()
        {
            try
            {
                return Request.CreateResponse(HttpStatusCode.OK, new ImportacaoBusiness().GetAll());
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpGet]
        [Route("importacoes/{id}")]
        public HttpResponseMessage GetById(int id)
        {
            try
            {
                return Request.CreateResponse(HttpStatusCode.OK, new ImportacaoBusiness().GetById(id));
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpPut]
        [Route("importacoes/{id}")]
        public HttpResponseMessage Update(int id, ImportacaoModel model)
        {
            try
            {
                new ImportacaoBusiness().Update(new ImportacaoEntity()
                {
                    Id = id,
                    NomeArquivo = model.NomeArquivo,
                    CaminhoArquivo = model.CaminhoArquivo,
                    Antecipacao = model.Antecipacao,
                    Seguradora = new SeguradoraEntity() { Id = model.SeguradoraId }
                });
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpDelete]
        [Route("importacoes/{id}")]
        public HttpResponseMessage Delete(int id)
        {
            try
            {
                new ImportacaoBusiness().Delete(id);
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }
    }
}

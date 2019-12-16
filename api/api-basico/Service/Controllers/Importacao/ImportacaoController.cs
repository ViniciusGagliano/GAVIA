using Service.Models;
using Entity;
using Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web;
using System.IO;

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

        [HttpPost]
        [Route("arquivos")]
        public HttpResponseMessage SalvarArquivo(int seguradoraId, bool antecipacao)
        {
            try
            {
                HttpFileCollection fileCollection = HttpContext.Current.Request.Files;
                if (fileCollection.Count == 0)
                    return Request.CreateResponse(HttpStatusCode.BadRequest, "Sem arquivo");

                string pathService = HttpContext.Current.Server.MapPath("~/ArquivosImportacao/");
                if (!Directory.Exists(pathService))
                    Directory.CreateDirectory(pathService);
                
                foreach (string fileName in fileCollection)
                {
                    HttpPostedFile file = fileCollection[fileName];
                    string pathFile = pathService + file.FileName;
                    if (File.Exists(pathFile))
                        File.Delete(pathFile);

                    file.SaveAs(pathFile);
                    new ImportacaoBusiness().Insert(new ImportacaoEntity()
                    {
                        Antecipacao = antecipacao,
                        Seguradora = new SeguradoraEntity() { Id = seguradoraId },
                        NomeArquivo = file.FileName.Trim(),
                        CaminhoArquivo = pathFile.Trim()
                    });
                }
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }
    }
}

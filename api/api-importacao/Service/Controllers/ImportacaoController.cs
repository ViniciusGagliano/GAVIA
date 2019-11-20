using Business;
using Entity;
using Service.Models;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.OleDb;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace Service.Controllers
{
    [RoutePrefix("importacao")]
    public class ImportacaoController : ApiController
    {
        public ImportacaoBusiness Business { get; set; }

        public ImportacaoController()
        {
            Business = new ImportacaoBusiness();
        }

        [HttpPost]
        [Route("insert")]
        public HttpResponseMessage ImportarArquivoAsync(int seguradoraId, int antecipacao)
        {
            try
            {
                HttpFileCollection files = HttpContext.Current.Request.Files;

                if (files.Count == 0)
                    return Request.CreateResponse(HttpStatusCode.BadRequest, "Sem arquivo");

                string pathService = HttpContext.Current.Server.MapPath("~/ArquivosImportacao/");

                //var provider = new MultipartMemoryStreamProvider();
                //await Request.Content.ReadAsMultipartAsync(provider);
                //foreach (var file in provider.Contents)
                //{
                //    var fileName = file.Headers.ContentDisposition.FileName.Trim('\"');
                //    var buffer = await file.ReadAsByteArrayAsync();
                //}

                foreach (string fileName in files)
                {
                    HttpPostedFile file = files[fileName];
                    file.SaveAs(pathService + file.FileName);
                    Business.InserirImportacao(new Importacao()
                    {
                        SeguradoraId = seguradoraId,
                        Antecipacao = Convert.ToBoolean(antecipacao),
                        NomeArquivo = file.FileName.ToString(),
                        CaminhoArquivo = pathService + file.FileName.ToString()
                    });
                }

                return Request.CreateResponse(HttpStatusCode.OK);
                //HttpFileCollection files = HttpContext.Current.Request.Files;
                //if (files.Count > 0)
                //{
                //    foreach (string file in files)
                //    {
                //        string name = files[file].FileName;
                //        if (!string.IsNullOrEmpty(name))
                //        {
                //            //Obtendo caminho do arquivo
                //            new ImportacaoBusiness().InserirImportacao(name, HttpContext.Current.Server.MapPath("~/" + name));
                //        }
                //        else
                //            continue;
                //    }
                //    return Request.CreateResponse(HttpStatusCode.OK);
                //}
                //else
                //{
                //    return Request.CreateResponse(HttpStatusCode.NoContent, "Sem arquivo");
                //}
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpGet]
        [Route("getall")]
        public HttpResponseMessage GetAll()
        {
            try
            {
                return Request.CreateResponse(HttpStatusCode.OK, new ImportacaoBusiness());
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpGet]
        [Route("getbyid")]
        public HttpResponseMessage GetById (int id)
        {
            try
            {
                new ImportacaoBusiness().GetById(id);
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }
    }
}

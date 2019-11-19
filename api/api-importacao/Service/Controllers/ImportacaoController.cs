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
        public HttpResponseMessage ImportarArquivo(int seguradoraId, int antecipacao)
        {
            try
            {
                Business.InserirImportacao(new Importacao()
                {
                    SeguradoraId = seguradoraId,
                    Antecipacao = Convert.ToBoolean(antecipacao),
                    CaminhoArquivo = HttpContext.Current.Request.FilePath
                });

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

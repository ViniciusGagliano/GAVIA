using Business;
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
        [HttpPost]
        [Route("insert")]
        public HttpResponseMessage ImportarArquivo()
        {
            try
            {
                HttpFileCollection files = HttpContext.Current.Request.Files;
                if (files.Count > 0)
                {
                    foreach (string name in files)
                    {
                        HttpPostedFile file = files[name];
                        //Obtendo caminho do arquivo
                        string filePath = HttpContext.Current.Server.MapPath("~/" + file.FileName);
                        string path = Path.GetDirectoryName(filePath);

                        //Criando a pasta
                        string directory = $@"{path}\ArquivosImportacao";
                        if (!Directory.Exists(directory))
                            Directory.CreateDirectory(directory);

                        //Nova pasta
                        string newDirectory = $@"{directory}\{Path.GetFileName(path)}";

                        if (!string.IsNullOrEmpty(filePath))
                        {
                            //Movendo o arquivo
                            //File.Move(filePath, newDirectory);
                            //Lendo o arquivo
                            var con = $@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source={filePath};Extended Properties=""Excel 8.0 Xml;HDR=YES""";
                            //
                            using (var conn = new OleDbConnection(con))
                            {
                                conn.Open();
                                var cmd = conn.CreateCommand();
                                cmd.CommandText = $"SELECT * FROM [Sinistros$]";

                                using (var rdr = cmd.ExecuteReader())
                                {
                                    var a = rdr.Cast<DbDataRecord>();
                                }
                            }
                        }
                    }
                }
                else
                {
                    return Request.CreateErrorResponse(HttpStatusCode.NoContent, "Sem arquivo");
                }
                var httpRequest = HttpContext.Current.Request;
                if (httpRequest.Files.Count > 0)
                {
                    var docfiles = new List<string>();
                    foreach (string file in httpRequest.Files)
                    {
                        var postedFile = httpRequest.Files[file];
                        var filePath = HttpContext.Current.Server.MapPath("~/" + postedFile.FileName);
                        postedFile.SaveAs(filePath);
                        docfiles.Add(filePath);
                    }
                }
                new ImportacaoBusiness().InserirImportacao();
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }
    }
}

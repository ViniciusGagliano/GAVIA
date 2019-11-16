﻿using Repository;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.OleDb;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Office.Interop.Excel;
using _Excel = Microsoft.Office.Interop.Excel;
using IronXL;
using ExcelDataReader;
using ClosedXML.Excel;

namespace Business
{
    public class ImportacaoBusiness
    {
        public _Application Excel { get; set; }
        public Workbook Wb { get; set; }
        public Worksheet Ws { get; set; }
        private readonly string path = $@"C:\inetpub\wwwroot\github\GAVIA";
        public void InserirImportacao(string fileName, string filePath)
        {
            try
            {
                //this.OleDbAccess(filePath);
                this.LerExcel(fileName, filePath);
                //new ImportacaoRepository().Insert();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private void LerExcel(string name, string caminho)
        {
            //XLWorkbook wb = new XLWorkbook(caminho);
            //IXLWorksheet worksheet = wb.Worksheet(1);
            //var row = worksheet.FirstRowUsed().RowBelow();

            //foreach (var cell in worksheet.Cells())
            //{
            //    var a = cell.Value;
            //    var b = cell.GetValue<string>();
            //}

            //WorkBook wb = WorkBook.Load(caminho);
            //WorkSheet ws = wb.WorkSheets.First();
            //foreach (var cell in ws["A1:Z11"])
            //{
            //    var a = cell.Value;
            //}

            //using (var stream = File.Open(caminho, FileMode.Open, FileAccess.Read))
            //{
            //    IExcelDataReader reader;
            //    reader = ExcelDataReader.ExcelReaderFactory.CreateReader(stream);
            //    var conf = new ExcelDataSetConfiguration
            //    {
            //        ConfigureDataTable = _ => new ExcelDataTableConfiguration
            //        {
            //            UseHeaderRow = true
            //        }
            //    };
            //    var dataSet = reader.AsDataSet(conf);
            //    var dataTable = dataSet.Tables[0];
            //    for (int i = 0; i < dataTable.Rows.Count; i++)
            //    {
            //        for (int j = 0; j < dataTable.Columns.Count; j++)
            //        {
            //            var b = dataTable.Rows[i][j];
            //        }
            //    }
            //    reader.Close();
            //}

            //Excel = new _Excel.Application();
            //Wb = Excel.Workbooks.Open($@"{path}\{name}");
            //Ws = Wb.Worksheets[1];
            //var c = Ws.Cells.Value2;
        }

        private void OleDbAccess(string filePath)
        {
            string path = Path.GetDirectoryName(filePath);

            //Criando a pasta
            string directory = $@"{path}\ArquivosImportacao";
            if (!Directory.Exists(directory))
                Directory.CreateDirectory(directory);

            //Nova pasta
            string newDirectory = $@"{directory}\{Path.GetFileName(path)}";

            //Movendo o arquivo
            //File.Move(filePath, newDirectory);
            //Lendo o arquivo
            var con = $@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source={filePath};Extended Properties=""Excel 12.0 Xml;HDR=YES""";
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

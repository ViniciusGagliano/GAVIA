using Repository;
using Entity;
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
using System.Data;
using System.Collections;

namespace Business
{
    public class ImportacaoBusiness
    {
        public ImportacaoRepository Repository { get; set; }
        public _Application Excel { get; set; }
        public Workbook Wb { get; set; }
        public Worksheet Ws { get; set; }
        private readonly string path = $@"C:\inetpub\wwwroot\github\GAVIA";

        public ImportacaoBusiness()
        {
            Repository = new ImportacaoRepository();
        }

        public void InserirImportacao(Importacao importacao)
        {
            try
            {
                Repository.Insert(importacao);
                //this.OleDbAccess(filePath);
                //this.LerExcel(fileName, filePath);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void GetAll()
        {
            try
            {
                new ImportacaoRepository().GetAll();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void GetById(int id)
        {
            try
            {
                new ImportacaoRepository().GetById(id);
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

            WorkBook wb = WorkBook.Load(caminho);
            WorkSheet ws = wb.WorkSheets.First();
            var table = ws.ToDataTable(true);
            DataRow[] rows = table.Select();
            IEnumerable<DataRow> ts = from processo in table.AsEnumerable() select processo;

            foreach (DataRow dr in ts)
            {
                var dt = dr.Field<DateTime>(8);
            }

            foreach (DataRow r in rows)
            {
                var e = r.Field<Double>(0);
            }

            foreach (DataRow row in table.Rows)
            {
                var f = row["CIAS"];
            }

            foreach (var cell in ws[ws.RangeAddressAsString])
            {
                var a = cell.Value;
            }

            //using (var stream = File.Open(caminho, FileMode.Open, FileAccess.Read))
            //{
            //    IExcelDataReader reader = ExcelDataReader.ExcelReaderFactory.CreateReader(stream);
            //    var conf = new ExcelDataSetConfiguration
            //    {
            //        ConfigureDataTable = _ => new ExcelDataTableConfiguration
            //        {
            //            UseHeaderRow = false
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

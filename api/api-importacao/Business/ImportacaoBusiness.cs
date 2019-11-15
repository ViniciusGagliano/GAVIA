using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class ImportacaoBusiness
    {
        public void InserirImportacao()
        {
            try
            {
                new ImportacaoRepository().Insert();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}

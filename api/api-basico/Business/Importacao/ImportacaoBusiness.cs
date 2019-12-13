using Repository;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class ImportacaoBusiness
    {
        public void Insert(ImportacaoEntity importacao) => new ImportacaoRepository().Insert(importacao);

        public Dictionary<string, List<ImportacaoEntity>> GetAll()
        {
            try
            {
                List<ImportacaoEntity> importacaos = new ImportacaoRepository().GetAll();
                return new Dictionary<string, List<ImportacaoEntity>>()
                {
                    {"ativos", importacaos.Where(i => i.Ativo == true).ToList() },
                    {"inativos", importacaos.Where(i => i.Ativo == false).ToList() }
                };
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public ImportacaoEntity GetById(int id) => new ImportacaoRepository().GetById(id);

        public void Update(ImportacaoEntity importacao) => new ImportacaoRepository().Update(importacao);

        public void Delete(int id) => new ImportacaoRepository().Delete(id);
    }
}

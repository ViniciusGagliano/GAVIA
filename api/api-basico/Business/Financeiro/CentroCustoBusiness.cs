using Entity;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class CentroCustoBusiness
    {
        public void Insert(CentroCustoEntity centroCusto) => new CentroCustoRepository().Insert(centroCusto);

        public Dictionary<string, List<CentroCustoEntity>> GetAll()
        {
            try
            {
                List<CentroCustoEntity> entities = new CentroCustoRepository().GetAll();
                return new Dictionary<string, List<CentroCustoEntity>>()
                {
                    {"ativos", entities.Where(cc => cc.Ativo == true).ToList() },
                    {"inativos", entities.Where(cc => cc.Ativo == false).ToList() }
                };
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public CentroCustoEntity GetById(int id) => new CentroCustoRepository().GetById(id);

        public void Update(CentroCustoEntity centroCusto) => new CentroCustoRepository().Update(centroCusto);

        public void Delete(int id) => new CentroCustoRepository().Delete(id);
    }
}

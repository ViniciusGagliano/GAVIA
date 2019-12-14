using Repository.Acompanhamento;
using Entity.Acompanhamento;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Acompanhamento
{
    public class FechamentoBusiness
    {
        public void Insert(FechamentoEntity fechamento) => new FechamentoRepository().Insert(fechamento);

        public List<FechamentoEntity> GetAll() => new FechamentoRepository().GetAll();
        
        public FechamentoEntity GetById(int id) => new FechamentoRepository().GetById(id);
        
        public void Update(FechamentoEntity fechamento) => new FechamentoRepository().Update(fechamento);

        public void Delete(int id) => new FechamentoRepository().Delete(id);
    }
}

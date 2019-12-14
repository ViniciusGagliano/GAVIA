using Repository.Financeiro;
using Entity.Financeiro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Financeiro
{
    public class LancamentoBusiness
    {
        public void Insert(LancamentoEntity lancamento) => new LancamentoRepository().Insert(lancamento);

        public Dictionary<string, List<LancamentoEntity>> GetAll()
        {
            try
            {
                List<LancamentoEntity> lancamentos = new LancamentoRepository().GetAll();
                return new Dictionary<string, List<LancamentoEntity>>()
                {
                    {"ativos", lancamentos.Where(l => l.Ativo == true).ToList() },
                    {"inativos", lancamentos.Where(l => l.Ativo == false).ToList() }
                };
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public LancamentoEntity GetById(int id) => new LancamentoRepository().GetById(id);

        public void Update(LancamentoEntity lancamento) => new LancamentoRepository().Update(lancamento);
        
        public void Delete(int id) => new LancamentoRepository().Delete(id);
    }
}

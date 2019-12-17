using Repository.Financeiro;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Financeiro
{
    public class TipoLancamentoBusiness
    {
        public List<TipoLancamento> GetAll() => new TipoLancamentoRepository().GetAll();
    }
}

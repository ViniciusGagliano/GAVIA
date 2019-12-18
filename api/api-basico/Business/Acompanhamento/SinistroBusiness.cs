using Repository.Acompanhamento;
using Entity.Acompanhamento;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Acompanhamento
{
    public class SinistroBusiness
    {
        public List<SinistroEntity> GetAllImportacao(int id) => new SinistroRepository().GetAllImportacao(id);
    }
}

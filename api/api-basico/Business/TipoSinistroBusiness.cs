using Repository;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class TipoSinistroBusiness
    {
        public void Insert(TipoSinistroEntity tipoSinistro) => new TipoSinistroRepository().Insert(tipoSinistro);

        public Dictionary<string, List<TipoSinistroEntity>> GetAll()
        {
            try
            {
                List<TipoSinistroEntity> tiposSinistros = new TipoSinistroRepository().GetAll();
                return new Dictionary<string, List<TipoSinistroEntity>>()
                {
                    {"ativos", tiposSinistros.Where(ts => ts.Ativo == true).ToList() },
                    {"inativos", tiposSinistros.Where(ts => ts.Ativo == false).ToList() }
                };
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public TipoSinistroEntity GetById(int id) => new TipoSinistroRepository().GetById(id);

        public void Update(TipoSinistroEntity tipoSinistro) => new TipoSinistroRepository().Update(tipoSinistro);

        public void Delete(int id) => new TipoSinistroRepository().Delete(id);
    }
}

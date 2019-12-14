using Repository.Importacao;
using Entity.Importacao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Importacao
{
    public class RegistroBusiness
    {
        public void Insert(RegistroEntity registro) => new RegistroRepository().Insert(registro);

        public List<RegistroEntity> GetAll() => new RegistroRepository().GetAll();

        public RegistroEntity GetById(int id) => new RegistroRepository().GetById(id);

        public void Update(RegistroEntity registro) => new RegistroRepository().Update(registro);

        public void Delete(int id) => new RegistroRepository().Delete(id);
    }
}

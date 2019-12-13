using Repository;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class SeguradoBusiness
    {
        public void Insert(SeguradoEntity segurado) => new SeguradoRepository().Insert(segurado);

        public Dictionary<string, List<SeguradoEntity>> GetAll()
        {
            try
            {
                List<SeguradoEntity> segurados = new SeguradoRepository().GetAll();
                return new Dictionary<string, List<SeguradoEntity>>()
                {
                    {"ativo", segurados.Where(s => s.Ativo == true).ToList() },
                    {"inativo", segurados.Where(s => s.Ativo == false).ToList() }
                };
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public SeguradoEntity GetById(int id) => new SeguradoRepository().GetById(id);

        public void Update(SeguradoEntity segurado) => new SeguradoRepository().Update(segurado);

        public void Delete(int id) => new SeguradoRepository().Delete(id);
    }
}

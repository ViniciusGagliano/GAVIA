using Repository;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class EmissorBusiness
    {
        public void Insert(EmissorEntity emissor) => new EmissorRepository().Insert(emissor);

        public Dictionary<string, List<EmissorEntity>> GetAll()
        {
            try
            {
                List<EmissorEntity> emissores = new EmissorRepository().GetAll();
                return new Dictionary<string, List<EmissorEntity>>()
                {
                    {"ativos", emissores.Where(e => e.Ativo == true).ToList() },
                    {"inativos", emissores.Where(e => e.Ativo == false).ToList() }
                };
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public EmissorEntity GetById(int id) => new EmissorRepository().GetById(id);

        public void Update(EmissorEntity emissor) => new EmissorRepository().Update(emissor);

        public void Delete(int id) => new EmissorRepository().Delete(id);
    }
}

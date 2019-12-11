using Entity;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class ContaBancariaBusiness
    {
        public void Insert(ContaBancariaEntity contaBancaria) => new ContaBancariaRepository().Insert(contaBancaria);

        public Dictionary<string, List<ContaBancariaEntity>> GetAll()
        {
            try
            {
                List<ContaBancariaEntity> entities = new ContaBancariaRepository().GetAll();
                return new Dictionary<string, List<ContaBancariaEntity>>()
                {
                    {"ativos", entities.Where(e => e.Ativo == true).ToList() },
                    {"inativos", entities.Where(e => e.Ativo == false).ToList() }
                };
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public ContaBancariaEntity GetById(int id) => new ContaBancariaRepository().GetById(id);

        public void Update(ContaBancariaEntity contaBancaria) => new ContaBancariaRepository().Update(contaBancaria);

        public void Delete(int id) => new ContaBancariaRepository().Delete(id);
    }
}

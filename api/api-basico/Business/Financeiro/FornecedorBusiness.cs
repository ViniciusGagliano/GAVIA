using Repository;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class FornecedorBusiness
    {
        public void Insert(FornecedorEntity fornecedor) => new FornecedorRepository().Insert(fornecedor);

        public Dictionary<string, List<FornecedorEntity>> GetAll()
        {
            try
            {
                List<FornecedorEntity> fornecedors = new FornecedorRepository().GetAll();
                return new Dictionary<string, List<FornecedorEntity>>()
                {
                    {"ativos", fornecedors.Where(f => f.Ativo == true).ToList() },
                    {"inativos", fornecedors.Where(f => f.Ativo == false).ToList() }
                };
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public FornecedorEntity GetById(int id) => new FornecedorRepository().GetById(id);

        public void Update(FornecedorEntity fornecedor) => new FornecedorRepository().Update(fornecedor);

        public void Delete(int id) => new FornecedorRepository().Delete(id);
    }
}

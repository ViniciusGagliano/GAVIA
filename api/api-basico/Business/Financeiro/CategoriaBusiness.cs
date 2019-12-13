using Repository;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class CategoriaBusiness
    {
        public void Insert(CategoriaEntity categoria) => new CategoriaRepository().Insert(categoria);

        public Dictionary<string, List<CategoriaEntity>> GetAll()
        {
            try
            {
                List<CategoriaEntity> categorias = new CategoriaRepository().GetAll();
                return new Dictionary<string, List<CategoriaEntity>>()
                {
                    {"ativos", categorias.Where(c => c.Ativo == true).ToList() },
                    {"inativos", categorias.Where(c => c.Ativo == false).ToList() }
                };
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public CategoriaEntity GetById(int id) => new CategoriaRepository().GetById(id);

        public void Update(CategoriaEntity categoria) => new CategoriaRepository().Update(categoria);

        public void Delete(int id) => new CategoriaRepository().Delete(id);
    }
}

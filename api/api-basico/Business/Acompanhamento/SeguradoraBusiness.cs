using Entity;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class SeguradoraBusiness
    {
        private readonly SeguradoraRepository repository;

        public SeguradoraBusiness()
        {
            repository = new SeguradoraRepository();
        }

        public void Insert(SeguradoraEntity seguradora) => repository.Insert(seguradora);

        public Dictionary<string, List<SeguradoraEntity>> GetAll()
        {
            try
            {
                List<SeguradoraEntity> seguradoras = repository.GetAll();
                return new Dictionary<string, List<SeguradoraEntity>>
                {
                    { "ativos", seguradoras.Where(s => s.Ativo == true).ToList() },
                    { "inativos", seguradoras.Where(s => s.Ativo == false).ToList() }
                };
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
        }

        public SeguradoraEntity GetById(int _id) => repository.GetById(_id);

        public void Update(SeguradoraEntity seguradora) => repository.Update(seguradora);

        public void Delete(int id) => repository.Delete(id);
    }
}

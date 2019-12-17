using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;
using Repository;

namespace Business
{
    public class PatrocinioBusiness
    {
        private readonly PatrocinioRepository repository;

        public PatrocinioBusiness()
        {
            repository = new PatrocinioRepository();
        }

        public void Insert(PatrocinioEntity patrocinio) => repository.Insert(patrocinio);

        public List<PatrocinioEntity> GetAll() => repository.GetAll();

        public PatrocinioEntity GetById(int id) => repository.GetById(id);

        public void Update(PatrocinioEntity patrocinio) => repository.Update(patrocinio);

        public void Delete(int id) => repository.Delete(id);
    }
}

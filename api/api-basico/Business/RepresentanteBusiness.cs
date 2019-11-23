using Entity;
using Repository;
using DBConnectionControl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class RepresentanteBusiness
    {
        private readonly RepresentanteRepository repository;

        public RepresentanteBusiness()
        {
            repository = new RepresentanteRepository();
        }

        public void Insert(RepresentanteEntity representante)
        {
            try
            {
                if (string.IsNullOrEmpty(representante.Nome) || string.IsNullOrEmpty(representante.CNPJ))
                {
                    throw new ArgumentNullException("Nome ou CNPJ devem ser preenchidos");
                }
                repository.Insert(representante);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
        }
        
        public List<RepresentanteEntity> GetAll()
        {
            try
            {
                return repository.GetAll();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
        }
        
        public RepresentanteEntity GetById(int id)
        {
            try
            {
                return repository.GetById(id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
        }
        
        public void Update(RepresentanteEntity representante)
        {
            try
            {
                repository.Update(representante);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
        }

        public void Delete(int id)
        {
            try
            {
                repository.Delete(id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
        }
    }
}

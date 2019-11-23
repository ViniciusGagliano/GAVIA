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

        public void Insert(PatrocinioEntity patrocinio)
        {
            try
            {
                if (patrocinio.Seguradora.Id.GetValueOrDefault(0) == 0 || patrocinio.Representante.Id.GetValueOrDefault(0) == 0)
                {
                    throw new ArgumentNullException("Valores nulo ou vazio");
                }
                repository.Insert(patrocinio);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
        }

        public List<PatrocinioEntity> GetAll()
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

        public PatrocinioEntity GetById(int id)
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

        public void Update(PatrocinioEntity patrocinio)
        {
            try
            {
                if (patrocinio.Seguradora.Id.GetValueOrDefault(0) == 0 && patrocinio.Representante.Id.GetValueOrDefault(0) == 0)
                {
                    throw new ArgumentNullException("Valroes nulo ou vazio");
                }
                repository.Update(patrocinio);
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

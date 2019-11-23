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

        public void Insert(SeguradoraEntity seguradora)
        {
            try
            {
                if (string.IsNullOrEmpty(seguradora.Nome) || string.IsNullOrEmpty(seguradora.CNPJ))
                {
                    throw new ArgumentNullException("Nome ou CNPJ devem ser preenchidos");
                }
                repository.Insert(seguradora);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
        }

        public List<SeguradoraEntity> GetAll()
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

        public SeguradoraEntity GetById(int _id)
        {
            try
            {
                return repository.GetById(_id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
        }

        public void Update(SeguradoraEntity seguradora)
        {
            try
            {
                repository.Update(seguradora);
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

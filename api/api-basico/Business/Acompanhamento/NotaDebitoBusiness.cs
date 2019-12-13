using Repository;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class NotaDebitoBusiness
    {
        public void Insert(NotaDebitoEntity notaDebito) => new NotaDebitoRepository().Insert(notaDebito);

        public Dictionary<string, List<NotaDebitoEntity>> GetAll()
        {
            try
            {
                List<NotaDebitoEntity> notasDebitos = new NotaDebitoRepository().GetAll();
                return new Dictionary<string, List<NotaDebitoEntity>>()
                {
                    {"ativos", notasDebitos.Where(nd => nd.Ativo == true).ToList() },
                    {"inativos", notasDebitos.Where(nd => nd.Ativo == false).ToList() }
                };
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public NotaDebitoEntity GetById(int id) => new NotaDebitoRepository().GetById(id);

        public void Update(NotaDebitoEntity notaDebito) => new NotaDebitoRepository().Update(notaDebito);

        public void Delete(int id) => new NotaDebitoRepository().Delete(id);
    }
}

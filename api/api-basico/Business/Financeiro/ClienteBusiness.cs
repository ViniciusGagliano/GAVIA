using Entity;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class ClienteBusiness
    {
        public void Insert(ClienteEntity cliente) => new ClienteRepository().Insert(cliente);

        public Dictionary<string, List<ClienteEntity>> GetAll()
        {
            try
            {
                List<ClienteEntity> clientes = new ClienteRepository().GetAll();
                return new Dictionary<string, List<ClienteEntity>>()
                {
                    {"ativos", clientes.Where(c => c.Ativo == true).ToList() },
                    {"inativos", clientes.Where(c => c.Ativo == false).ToList() }
                };
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public ClienteEntity GetById(int id) => new ClienteRepository().GetById(id);

        public void Update(ClienteEntity cliente) => new ClienteRepository().Update(cliente);

        public void Delete(int id) => new ClienteRepository().Delete(id);
    }
}

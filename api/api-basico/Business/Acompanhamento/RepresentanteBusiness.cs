﻿using Entity;
using Repository;
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
                    throw new ArgumentNullException("Nome e CNPJ devem ser preenchidos");
                }
                repository.Insert(representante);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
        }
        
        public Dictionary<string, List<RepresentanteEntity>> GetAll()
        {
            try
            {
                List<RepresentanteEntity> representantes = repository.GetAll();
                return new Dictionary<string, List<RepresentanteEntity>>()
                {
                    {"ativos", representantes.Where(r => r.Ativo == true).ToList() },
                    {"inativos", representantes.Where(r => r.Ativo == false).ToList() }
                };
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
        }

        public RepresentanteEntity GetById(int id) => repository.GetById(id);
        
        public void Update(RepresentanteEntity representante)
        {
            try
            {
                if (string.IsNullOrEmpty(representante.Nome) && string.IsNullOrEmpty(representante.CNPJ))
                {
                    throw new ArgumentNullException("Nome ou CNPJ devem ser preenchidos");
                }
                repository.Update(representante);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
        }

        public void Delete(int id) => repository.Delete(id);
    }
}

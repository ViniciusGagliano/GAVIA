using Service.Models.Financeiro;
using Entity.Financeiro;
using Business.Financeiro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Entity;

namespace Service.Controllers.Financeiro
{
    [RoutePrefix("basico")]
    public class LancamentoController : ApiController
    {
        [HttpPost]
        [Route("lancamentos")]
        public HttpResponseMessage Insert(LancamentoModel model)
        {
            try
            {
                new LancamentoBusiness().Insert(new LancamentoEntity()
                {
                    Descricao = model.Descricao,
                    Valor = model.Valor,
                    DataLancamento = model.DataLancamento,
                    CustoFixo = model.CustoFixo,
                    Categoria = new CategoriaEntity() { Id = model.CategoriaId },
                    CentroCusto = new CentroCustoEntity() { Id = model.CentroCustoId },
                    Cliente = new ClienteEntity() { Id = model.ClienteId },
                    ContaBancaria = new ContaBancariaEntity() { Id = model.ContaBancariaId },
                    Fornecedor = new FornecedorEntity() { Id = model.FornecedorId },
                    Fechamento = new Entity.Acompanhamento.FechamentoEntity() { Id = model.FechamentoId }
                });
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpGet]
        [Route("lancamentos")]
        public HttpResponseMessage GetAll()
        {
            try
            {
                return Request.CreateResponse(HttpStatusCode.OK, new LancamentoBusiness().GetAll());
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpGet]
        [Route("lancamentos/{id}")]
        public HttpResponseMessage GetById(int id)
        {
            try
            {
                return Request.CreateResponse(HttpStatusCode.OK, new LancamentoBusiness().GetById(id));
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpPut]
        [Route("lancamentos/{id}")]
        public HttpResponseMessage Update(int id, LancamentoModel model)
        {
            try
            {
                new LancamentoBusiness().Update(new LancamentoEntity()
                {
                    Id = id,
                    Descricao = model.Descricao,
                    Valor = model.Valor,
                    DataLancamento = model.DataLancamento,
                    CustoFixo = model.CustoFixo,
                    Categoria = new CategoriaEntity() { Id = model.CategoriaId },
                    CentroCusto = new CentroCustoEntity() { Id = model.CentroCustoId },
                    Cliente = new ClienteEntity() { Id = model.ClienteId },
                    ContaBancaria = new ContaBancariaEntity() { Id = model.ContaBancariaId },
                    Fornecedor = new FornecedorEntity() { Id = model.FornecedorId },
                    Fechamento = new Entity.Acompanhamento.FechamentoEntity() { Id = model.FornecedorId }
                });
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpDelete]
        [Route("lancamentos/{id}")]
        public HttpResponseMessage Delete(int id)
        {
            try
            {
                new LancamentoBusiness().Delete(id);
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }
    }
}
